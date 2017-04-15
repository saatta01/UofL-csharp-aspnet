// Program 3
// CIS 200-01
// Fall 2016
// Due: 11/15/2016
// By: C1943

// File: EditAddress.cs
// This class creates the GUI for choosing addresses to edit from the current list of addresses
//and then taking what the user has edited and replacing the original fields with the updated fields in the 
// upv object addressList
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UPVApp
{
    public partial class EditAddress : Form
    {
        public const int MIN_ADDRESSES = 1; // Minimum number of addresses needed

        private List<Address> addressList;  // List of addresses used to fill combo boxes

        // Precondition:  List addresses is populated from uploaded file with the available
        //                addresses to choose from
        // Postcondition: The form's GUI is prepared for display.
        public EditAddress(List<Address> addresses)
        {
            InitializeComponent();
            addressList = addresses;
        }

        internal int AddressIndex
        {
            // Precondition:  User has selected from selectAddressComboBox
            // Postcondition: The index of the selected address to be edited returned
            get
            {
                return selectAddressComboBox.SelectedIndex;
            }

            // Precondition:  -1 <= value < addressList.Count
            // Postcondition: The specified index is selected in selectAddressComboBox
            set
            {
                if ((value >= -1) && (value < addressList.Count))
                    selectAddressComboBox.SelectedIndex = value;
                else
                    throw new ArgumentOutOfRangeException("AddressIndex", value,
                        "Index must be valid");
            }
        }

        // Precondition:  addressList.Count >= MIN_ADDRESSES
        // Postcondition: The list of addresses is used to populate the
        //                combo box
        private void EditAddress_Load(object sender, EventArgs e)
        {
            if (addressList.Count < MIN_ADDRESSES) // Violated precondition!
            {
                MessageBox.Show("Need " + MIN_ADDRESSES + " addresses to edit!",
                    "Addresses Error");
                this.DialogResult = DialogResult.Abort; // Dismiss immediately
            }
            else
            {
                foreach (Address a in addressList)
                {
                    selectAddressComboBox.Items.Add(a.Name);
                }
            }
        }

        // Precondition:  Focus shifting from one of the address combo boxes
        //                sender is ComboBox
        // Postcondition: If no address selected, focus remains and error provider
        //                highlights the field
        private void addressCbo_Validating(object sender, CancelEventArgs e)
        {
            // Downcast to sender as ComboBox, so make sure you obey precondition!
            ComboBox cbo = sender as ComboBox; // Cast sender as combo box

            if (cbo.SelectedIndex == -1) // -1 means no item selected
            {
                e.Cancel = true;
                errorProvider1.SetError(cbo, "Must select an address");
            }
            
        }

        // Precondition:  Validating of sender not cancelled, so data OK
        //                sender is Control
        // Postcondition: Error provider cleared and focus allowed to change
        private void AllFields_Validated(object sender, EventArgs e)
        {
            Control control = sender as Control; // Cast sender as Control
            // Should always be a Control
            errorProvider1.SetError(control, "");
        }

    
        // Precondition:  User pressed on cancelButton
        // Postcondition: Form closes
        private void cancelButton_MouseDown(object sender, MouseEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        // Precondition:  User clicked on okButton
        // Postcondition: If user inputted invalid field on dialog, keep form open and give first invalid
        //                field the focus. Else return OK and close form.
        private void okButton_Click(object sender, EventArgs e)
        {
            // Raise validating event for all enabled controls on form
            // If all pass, ValidateChildren() will be true and user can successfully choose an address to edit
            if (ValidateChildren())
                this.DialogResult = DialogResult.OK;
        }
    }
}
