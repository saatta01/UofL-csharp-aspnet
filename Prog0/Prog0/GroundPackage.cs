using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Sara Attarzadeh
// Program 1A
// Due Date 10/11/16
// Course Section: 200-01
//Description: This Ground package class, derived from package is a concrete class. Implements a unique calc cost method (takes into account dimensions, weight, and zone distance)

public class GroundPackage : Package
 {

    private int zoneDistance;

    // GroundPackage constructor
    // Precondition:  dimensions and weight > 0
    // Postcondition: The letter is created with the specified values for
    //                origin address, destination address, dimensions, and weight

    public GroundPackage(Address originAddress, Address destAddress,
        double lengthInInches, double widthInInches, double heightInInches, double weightInPounds)
        : base(originAddress, destAddress, lengthInInches, widthInInches, heightInInches, weightInPounds)
    {
        
    }

   
    public int ZoneDistance
    {
        // Precondition:  None
        // Postcondition: The GroundPackage's zoneDistance has been returned
        get
        {
            const int FIRSTDIGEXTRACT = 10000; // Denominator to extract 1st digit
                                     // Calculated zone distance

            return Math.Abs(OriginAddress.Zip / FIRSTDIGEXTRACT) - (DestinationAddress.Zip / FIRSTDIGEXTRACT);
            
        }

    }

    // Precondition:  None
    // Postcondition: The Ground package's cost has been returned
    public override decimal CalcCost()
    {
        const decimal DIM_NUM = .20m;   //number to multiply w/ the dimensions
        const decimal WEIGHT_NUM = .05m; //Number to multiply w/ the weight
        decimal decimalLength = (decimal)Length; //cast to utilize
        decimal decimalWidth = (decimal)Width;
        decimal decimalHeight = (decimal)Height;
        decimal decimalWeight = (decimal)Weight;

        return (DIM_NUM * (decimalLength + decimalWidth + decimalHeight) + WEIGHT_NUM * (ZoneDistance + 1) * decimalWeight);
    }

    // Precondition:  None
    // Postcondition: A String with the Ground Package's data has been returned
    public override string ToString()
    {
        return $"GroundPackage{Environment.NewLine}{base.ToString()},{ZoneDistance}";
    }
}

