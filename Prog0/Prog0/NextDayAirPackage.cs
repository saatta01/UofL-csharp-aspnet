using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Sara Attarzadeh
// Program 1A
// Due Date 10/11/16
// Course Section: 200-01
//Description: This class, derived from air package, adds an express fee into its calc cost method
public class NextDayAirPackage : AirPackage 
 {
    private decimal expressFee;
    
  

    // Precondition:  All dimensions and weights are > 0 and fees are >= 0
    // Postcondition: The NextDayAirPackage is created with the specified values for
    //                origin address, destination address, length in inches(positive double), width in inches(positive double), 
    //                 height in inches(positive double), and the weight in pounds(positive double) and the express fee (non-negative decimal), 
    //                  in dollars

    public NextDayAirPackage(Address originAddress, Address destAddress,
        double lengthInInches, double widthInInches, double heightInInches, double weightInPounds, decimal expressFee)
        : base(originAddress, destAddress, lengthInInches, widthInInches, heightInInches, weightInPounds)
    {

    }

    //property for ExpressFee
    public decimal ExpressFee
    {
        // Precondition:  None
        // Postcondition: The NextDayAirPackages ExpressFee (variable, to be set in constructor) has been returned
        get
        {
            return expressFee;

        }

    }

    // Precondition:  None
    // Postcondition: The NextDayAirPackage's cost has been returned. Factors in extra charges for being heavy or large.
    public override decimal CalcCost()
    {
        const decimal BASE_DIM = .40m;   //number to multiply w/ the dimensions if not large/heavy
        const decimal BASE_WEIGHT = .3m; //Number to multiply w/ the weight if not large/heavy
        const decimal HEAVY_RATE = .25m;
        const decimal LARGE_RATE = .25m;
        decimal decimalLength = (decimal)Length; //cast to utilize
        decimal decimalWidth = (decimal)Width;
        decimal decimalHeight = (decimal)Height;
        decimal decimalWeight = (decimal)Weight;
        decimal weightCharge = HEAVY_RATE * decimalWeight; //extra cost calc for heavy items
        decimal sizeCharge = LARGE_RATE * (decimalLength + decimalWidth + decimalHeight); //extra cost calc for large itms
        decimal baseCost = BASE_DIM * (decimalLength + decimalWidth + decimalHeight) + BASE_WEIGHT * (decimalWeight) + ExpressFee;
        
        if (IsHeavy() == true && IsLarge() == true)
        {
            return baseCost + weightCharge + sizeCharge;
        }
        else if (IsHeavy() == true)
        {
            return baseCost + weightCharge;
        }
        else if (IsLarge() == true)
        {
            return baseCost + sizeCharge;
        }
        else
        {
            return baseCost;
        }
    }

    // Precondition:  None
    // Postcondition: A String with the NextDayAirPackage's data has been returned
    public override string ToString()
    {
        return $"GroundPackage{Environment.NewLine}{base.ToString()}";
    }


}

