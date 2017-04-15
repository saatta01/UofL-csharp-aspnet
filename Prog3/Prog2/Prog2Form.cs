// Program 3
// CIS 200-01
// Fall 2016
// Due: 11/15/2016
// By: C1943

// File: Prog2Form.cs
// This class creates the main GUI for Program 2. It provides a
// File menu with About, Exit, Open, and Save As menu items, an Insert menu with Address and
// Letter items, a Report menu with List Addresses and List Parcels, and a file menu with an
// Address item to edit addresses.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace UPVApp
{
    public partial class Prog2Form : Form
    {
        private UserParcelView upv; // The UserParcelView

        //creates an instance of BinaryFormatter for serializing UPV objects in binary format to a file
        private BinaryFormatter writeformatter = new BinaryFormatter();
        private FileStream output; //the stream for writing to a file

        //creates an instance of BinaryFormatter for deserializing UPV objects from binary format from a file
        private BinaryFormatter readformatter = new BinaryFormatter();
        private FileStream input; //the stream for reading from a file

        // Precondition:  None
        // Postcondition: The form's GUI is prepared for display. A few test addresses are
        //                added to the list of addresses
        public Prog2Form()
        {
            InitializeComponent();

            upv = new UserParcelView();
        }

        // Precondition:  File, About menu item activated
        // Postcondition: Information about author displayed in dialog box
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string NL = Environment.NewLine; // Newline shorthand

            MessageBox.Show($"Program 2{NL}By: Andrew L. Wright{NL}CIS 200{NL}Fall 2016",
                "About Program 2");
        }

        // Precondition:  File, Exit menu item activated
        // Postcondition: The application is exited
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Precondition:  Insert, Address menu item activated
        // Postcondition: The Address dialog box is displayed. If data entered
        //                are OK, an Address is created and added to the list
        //                of addresses
        private void addressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddressForm addressForm = new AddressForm();    // The address dialog box form
            DialogResult result = addressForm.ShowDialog(); // Show form as dialog and store result

            if (result == DialogResult.OK) // Only add if OK
            {
                try
                {
                    upv.AddAddress(addressForm.AddressName, addressForm.Address1,
                        addressForm.Address2, addressForm.City, addressForm.State,
                        int.Parse(addressForm.ZipText)); // Use form's properties to create address
                }
                catch (FormatException) // This should never happen if form validation works!
                {
                    MessageBox.Show("Problem with Address Validation!", "Validation Error");
                }
            }

            addressForm.Dispose(); // Best practice for dialog boxes
        }

        // Precondition:  Report, List Addresses menu item activated
        // Postcondition: The list of addresses is displayed in the addressResultsTxt
        //                text box
        private void listAddressesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder result = new StringBuilder(); // Holds text as report being built
                                                        // StringBuilder more efficient than String
            string NL = Environment.NewLine;            // Newline shorthand

            result.Append("Addresses:");
            result.Append(NL); // Remember, \n doesn't always work in GUIs
            result.Append(NL);

            foreach (Address a in upv.AddressList)
            {
                result.Append(a.ToString());
                result.Append(NL);
                result.Append("------------------------------");
                result.Append(NL);
            }

            reportTxt.Text = result.ToString();

            // Put cursor at start of report
            reportTxt.Focus();
            reportTxt.SelectionStart = 0;
            reportTxt.SelectionLength = 0;
        }

        // Precondition:  Insert, Letter menu item activated
        // Postcondition: The Letter dialog box is displayed. If data entered
        //                are OK, a Letter is created and added to the list
        //                of parcels
        private void letterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LetterForm letterForm; // The letter dialog box form
            DialogResult result;   // The result of showing form as dialog

            if (upv.AddressCount < LetterForm.MIN_ADDRESSES) // Make sure we have enough addresses
            {
                MessageBox.Show("Need " + LetterForm.MIN_ADDRESSES + " addresses to create letter!",
                    "Addresses Error");
                return;
            }

            letterForm = new LetterForm(upv.AddressList); // Send list of addresses
            result = letterForm.ShowDialog();

            if (result == DialogResult.OK) // Only add if OK
            {
                try
                {
                    // For this to work, LetterForm's combo boxes need to be in same
                    // order as upv's AddressList
                    upv.AddLetter(upv.AddressAt(letterForm.OriginAddressIndex),
                        upv.AddressAt(letterForm.DestinationAddressIndex),
                        decimal.Parse(letterForm.FixedCostText)); // Letter to be inserted
                }
                catch (FormatException) // This should never happen if form validation works!
                {
                    MessageBox.Show("Problem with Letter Validation!", "Validation Error");
                }
            }

            letterForm.Dispose(); // Best practice for dialog boxes
        }

        // Precondition:  Report, List Parcels menu item activated
        // Postcondition: The list of parcels is displayed in the parcelResultsTxt
        //                text box
        private void listParcelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder result = new StringBuilder(); // Holds text as report being built
                                                        // StringBuilder more efficient than String
            decimal totalCost = 0;                      // Running total of parcel shipping costs
            string NL = Environment.NewLine;            // Newline shorthand

            result.Append("Parcels:");
            result.Append(NL); // Remember, \n doesn't always work in GUIs
            result.Append(NL);

            foreach (Parcel p in upv.ParcelList)
            {
                result.Append(p.ToString());
                result.Append(NL);
                result.Append("------------------------------");
                result.Append(NL);
                totalCost += p.CalcCost();
            }

            result.Append(NL);
            result.Append($"Total Cost: {totalCost:C}");

            reportTxt.Text = result.ToString();

            // Put cursor at start of report
            reportTxt.Focus();
            reportTxt.SelectionStart = 0;
            reportTxt.SelectionLength = 0;
        }

        // Precondition:  File, save as menu item activated
        // Postcondition: Our upv object is serialized and written to a file specified by the user 
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //var to create dialog box and display it so user can save
            DialogResult result; //var to hold result of saveFileDialog
            string fileName; // var to hold name of file to save the data to

            using (SaveFileDialog specifyFile = new SaveFileDialog())
            {
                specifyFile.CheckFileExists = false; //lets user create the file
                result = specifyFile.ShowDialog(); 
                fileName = specifyFile.FileName; //get name user has chosen as set it as the file name to save data
            }

            if (result == DialogResult.OK) //if user actually clicks the OK/save button
            {
                if(fileName == "") //provide an error when user tries to enter an invalid file name
                {
                    MessageBox.Show("Failure to enter a file name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else //if user entered a valid file name, use the output FileStream to save the file 
                {
                    try
                    {
                        output = new FileStream(fileName, FileMode.Create, FileAccess.Write); //open file and allow to write, fileName used to specify path
                        writeformatter.Serialize(output, upv); //write the upv object to the file 
                    }
                    catch (IOException) //if there's a problem opening the file, show error
                    {
                        MessageBox.Show("Error Opening File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (SerializationException) //if there's a problem serializing the file, show error
                    {
                        MessageBox.Show("Error Writing to File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if(output != null)
                        {
                            try
                            {
                                output.Close(); //close filestream
                            }
                            catch (IOException)
                            {
                                MessageBox.Show("File Cannot be Closed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                        
                    }
                }
            }
        }

        // Precondition:  File, open menu item activated
        // Postcondition: a file containing a upv object is deserialized and read into application, giving user all the addresses/parcels/packages contained in that object 
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //create and show dialog box so user can open their serialized file
            DialogResult result; //var to hold result of openFileDialog
            string fileName; //var to hold name of file that cotains the data

            using (OpenFileDialog specifyFile = new OpenFileDialog()) //helps with disposal
            {
                result = specifyFile.ShowDialog();
                fileName = specifyFile.FileName; //get name user has chosen as set it as the file to open
            }

            //check that user selected OK/open
            if (result == DialogResult.OK)
            {
                if (fileName == "") //show error if they user doesn't choose a valid file name
                {
                    MessageBox.Show("No File Chosen");
                }
                else
                {
                    input = new FileStream(fileName, FileMode.Open, FileAccess.Read); //open file and allow to read, fileName used to specify path

                    try
                    {
                        upv = (UserParcelView)readformatter.Deserialize(input); //read the data from the file and parse it as type UserParcelView and set it equal to our upv instance object
                    }
                    catch (SerializationException) //if there is a problem with deserialization 
                    {
                        input.Close(); // close the FileStream
                        MessageBox.Show("Empty File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (IOException) //input/output error
                    {
                        MessageBox.Show("Error when reading from File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (input != null)
                        {
                            try
                            {
                                input.Close(); //close filestream
                            }
                            catch (IOException)
                            {
                                MessageBox.Show("File Cannot be Closed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }

                    }
                    
                }
            }

        }

        // Precondition:  Edit, Address menu item activated
        // Postcondition: EditAddressForm Dialog box is opened and user can select addresses to update from the upv object addresslist
        // once address selected, a pre-populated address box is opened and editable. Once saved, it inserts the updated address at the index of
        // the original address the user chose
        private void addressToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            List<Address> addresses = upv.AddressList; // create list to hold addresses and set equal to upv object's address list
            DialogResult result; // var to hold user interaction w/ dialog box result 
            EditAddress updateAddressForm = new EditAddress(addresses); //create a new instance of the edit address form and pass in the current list of addresses
            result = updateAddressForm.ShowDialog(); 


            if (upv.AddressCount < EditAddress.MIN_ADDRESSES) // Make sure we have enough addresses
            {
                MessageBox.Show("No Addresses to edit");
                return;
            }

            if(result == DialogResult.OK) //check if user clicked OK
            {
                AddressForm newAddressForm = new AddressForm(); //create instance of the address form so users can actually edit

                int index; //var to hold the index position of the address the user selected
                index = updateAddressForm.AddressIndex; //set index to the index user chose from combo box
                Address a = addresses[index]; //assign the selected index to an address variable

                //first, set original field values to the fields of the address form diag. box that will appear
                newAddressForm.AddressName = a.Name;
                newAddressForm.Address1 = a.Address1;
                newAddressForm.Address2 = a.Address2;
                newAddressForm.City = a.City;
                newAddressForm.State = a.State;
                newAddressForm.ZipText= a.Zip.ToString("d5") ;

                //var to hold result of that new address form dialog interaction result
                DialogResult resultAddressForm = newAddressForm.ShowDialog();
                if (resultAddressForm == DialogResult.OK) // check if user clicked OK
                {
                    //populate upv address List with the updated fields user changed
                    upv.AddressList.RemoveAt(updateAddressForm.AddressIndex); //remove the current address in the upv addressList user has chosen to change

                    Address updatedAddress = new Address(newAddressForm.AddressName, newAddressForm.Address1,
                        newAddressForm.Address2, newAddressForm.City, newAddressForm.State, int.Parse(newAddressForm.ZipText)); //create a new address object

                    upv.AddressList.Insert(updateAddressForm.AddressIndex, updatedAddress); //update that now empty index position with the updated address
                }
                
            }
            

            updateAddressForm.Dispose();
        }
    }
}