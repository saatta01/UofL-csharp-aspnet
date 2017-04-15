using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Sara Attarzadeh
// Program 1A
// Due Date 10/11/16
// Course Section: 200-01
//Description: Air package derived from packages looks to see if the weights or sizes are too large, and factors in extra charges in calc cost method


public abstract class AirPackage : Package
 {
   
    // Precondition:  All dimensions and weights are > 0
    // Postcondition: The Air Package is created with the specified values for
    //                origin address, destination address, length in inches(positive double), width in inches(positive double), 
    //                 height in inches(positive double), and the weight in pounds(positive double).

    public AirPackage(Address originAddress, Address destAddress,
        double lengthInInches, double widthInInches, double heightInInches, double weightInPounds)
        : base(originAddress, destAddress, lengthInInches, widthInInches, heightInInches, weightInPounds)
    {

    }

   
    // Precondition:  None
    // Postcondition: Returns a true if Weight is greater or equal to 75, false otherwise.
    public bool IsHeavy()
    {
        double HEAVY = 75;
        if (Weight >= HEAVY)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //Method IsLarge accepts no parameters and returns a boolean.
    //An air package is considered large if the total of its dimensions(Length + Width + Height) is 100 inches or more.
    public bool IsLarge()
    {
        double LARGE = 100;
        if ((Length + Weight + Height) >= LARGE)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

   

    // Precondition:  None
    // Postcondition: A String with the AirPackage's data has been returned
    public override string ToString()
    {
        return $"GroundPackage{Environment.NewLine}{base.ToString()}, IsHeavy:{IsHeavy()}, IsLarge:{IsLarge()}";
    }



}
