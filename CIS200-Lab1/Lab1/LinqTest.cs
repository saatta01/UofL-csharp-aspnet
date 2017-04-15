using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/* GRADING ID: C1943
 LAB1 
due date: 9/11/16
course section: 02
Description of Program: This program creates an array of Invoice objects, then uses LINQ to filter to get specific results in the console. This program contains 5 different queries to demonstrate the capabilities of LINQ. */

namespace Lab1
{
    public class LinqTest
    {
        public static void Main(string[] args)
        {
            // initialize array of invoices
            Invoice[] invoices = {
                new Invoice( 83, "Electric sander", 7, 57.98M ),
                new Invoice( 24, "Power saw", 18, 99.99M ),
                new Invoice( 7, "Sledge hammer", 11, 21.5M ),
                new Invoice( 77, "Hammer", 76, 11.99M ),
                new Invoice( 39, "Lawn mower", 3, 79.5M ),
                new Invoice( 68, "Screwdriver", 106, 6.99M ),
                new Invoice( 56, "Jig saw", 21, 11M ),
                new Invoice( 3, "Wrench", 34, 7.5M ) };

            // Display original array
            Console.WriteLine("Original Invoice Data\n");
            Console.WriteLine("P.Num Part Description     Quant Price"); // Column Headers
            Console.WriteLine("----- -------------------- ----- ------");

            foreach (Invoice inv in invoices)
                Console.WriteLine(inv);

            // *******Part a*******
            // LINQ query that retrieves all Invoice objects and sorts them by PartDescription. Declare partDescriptionSorted variable to hold query results.
            var partDescriptionSorted =
                from inv in invoices
                orderby inv.PartDescription
                select inv;
            // end LINQ query

            // display the partDescriptionSorted results
            Console.WriteLine("\nOriginal invoices array sorted by Part Description:"); //statement of result below
            Console.WriteLine("P.Num Part Description     Quant Price"); // Column Headers
            Console.WriteLine("----- -------------------- ----- ------"); // For clarity
            foreach (var element in partDescriptionSorted) //declare a variable to represent the individual values of partDescriptionSorted result
            {
                Console.WriteLine(element);
            }
            //end WriteLine methods to display results in console.



            // *******Part b*******
            //LINQ query that retrieves all Invoice objects and sorts by Price. Declare priceSorted variable to hold query results.
            var priceSorted =
                from inv in invoices
                orderby inv.Price
                select inv;
            //end LINQ query

            // display the priceSorted results
            Console.WriteLine("\nOriginal invoices array sorted by Price:"); //Statement of result below
            Console.WriteLine("P.Num Part Description     Quant Price"); // Column Headers
            Console.WriteLine("----- -------------------- ----- ------");             
            foreach (var element in priceSorted) //declare a variable to represent the individual values of priceSorted result
            {
                Console.WriteLine(element);
            }
            //end WriteLine methods to display results in console.



            // *******Part c*******
            // LINQ query that retrieves the PartDescription and Quantity of the Invoice objects and then sort by Quantity.
            // Declare descriptionQuantitySorted variable to hold query results.
            var descriptionQuantitySorted =
                from inv in invoices
                orderby inv.Quantity
                select new { inv.PartDescription, inv.Quantity };
            //end LINQ query

            // display the descriptionQuantitySorted results
            Console.WriteLine("\nPartDescription and Quantity of Invoice objects sorted by Quantity:");
            foreach (var element in descriptionQuantitySorted) //declare a variable to represent the individual values of descriptionQuantitySorted result
            {
                Console.WriteLine($"{element}");
            }
            //end WriteLine methods to display results in console.



            // *******Part d*******
            /* Use LINQ to select from each Invoice the PartDescription and the value of the Invoice (i.e., Quantity * Price). 
             * Name the calculated column InvoiceTotal. Order the results by Invoice value. 
             * [Hint: Use let to store the result of Quantity * Price in a new range variable total.] */

            //LINQ query start. Declare descriptionValueSorted variable to hold query results.
            var descriptionValueSorted =
               from inv in invoices
               let total = inv.Quantity * inv.Price //creates a variable to hold invoice value calc
               orderby total
               select new { inv.PartDescription, InvoiceTotal = total };
            //End LINQ query

            // display the descriptionValueSorted results.
            Console.WriteLine("\nPartDescription and InvoiceTotal (Quantity * Price) of Invoice objects sorted by Invoice value:");
            foreach (var element in descriptionValueSorted) //declare a variable to represent the individual values of descriptionValueSorted result
            {
                Console.WriteLine($"{element}");
            }
            //end WriteLine methods to display results in console.




            // *******Part e*******
            //Using the results of the LINQ query in Part d, select the InvoiceTotals in the range $200 to $500." [Note: This should be an inclusive range.]

            //declare two constants to hold the min and max invoiceTotals to be accepted in the query
            const decimal INVTOT_MIN = 200m;
            const decimal INVTOT_MAX = 500m;
            //LINQ query start. Declare invoiceTotalsRange variable to hold query results.
            var invoiceTotalsRange =
                from inv in descriptionValueSorted
                where inv.InvoiceTotal >= INVTOT_MIN && inv.InvoiceTotal <= INVTOT_MAX
                select inv;
            //LINQ query end

            // display the invoiceTotalsRange results.
            Console.WriteLine($"\nInvoices with an InvoiceTotal between ${INVTOT_MIN} and ${INVTOT_MAX}, inclusively:");
            foreach (var element in invoiceTotalsRange) //declare a variable to represent the individual values of invoiceTotalsRange result
            {
                Console.WriteLine($"{element}");
            }

            //end WriteLine methods to display results in console.
        }
    }
}
