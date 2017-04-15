using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Sara Attarzadeh
// Program 1A
// Due Date 10/11/16
// Course Section: 200-01
//Description: This class, derived from air package as well, allows user to select early or saver shipping, and factors the discount for choosing saver shipping into calc cost method
public class TwoDayAirPackage : AirPackage
{
    public enum Delivery {Early, Saver}; //declaration of enum to specificy the delivery type
    private Delivery type;
    // Precondition:  All dimensions and weights are > 0 and delivery is either saver or early
    // Postcondition: specifies the origin address, destination address, length in inches(positive double),
    //width in inches (positive double), height in inches (positive double), 
    //and the weight in pounds (positive double), and delivery type (a Delivery enum value, for Early or Saver).

    public TwoDayAirPackage(Address originAddress, Address destAddress,
        double lengthInInches, double widthInInches, double heightInInches, double weightInPounds, Delivery type)
        : base(originAddress, destAddress, lengthInInches, widthInInches, heightInInches, weightInPounds)
    {

    }

    //Get and set property for DeliveryType (using the Delivery enum)
    public Delivery DeliveryType
    {
        // Precondition:  None
        // Postcondition: Returns the delivery type of the TwoDayAirPackage
        get
        {
            return type;
        }
        // Precondition: user must input early or saver delivery
        // Postcondition: Sets the type to the entered delivery type.
        set
        {
            if (value == Delivery.Early || value == Delivery.Saver)
            {
                type = value;
            }
        }

    }

    // Precondition:  None
    // Postcondition: The TwoDayAirPackage's cost has been returned. Factors in various shipping type costs.
    public override decimal CalcCost()
    {
        const decimal DIM_NUM = .25m;
        const decimal WEIGHT_NUM = .25m;
        const decimal SAVER_RATE = .9m;
        decimal decimalLength = (decimal)Length;
        decimal decimalWidth = (decimal)Width;
        decimal decimalHeight = (decimal)Height;
        decimal decimalWeight = (decimal)Weight;
        decimal baseCost = DIM_NUM * (decimalLength + decimalWidth + decimalHeight) + WEIGHT_NUM * (decimalWeight);

        if (DeliveryType == Delivery.Saver)
        {
            return baseCost * SAVER_RATE;
        }
        else
        {
            return baseCost;
        }
    }

    // Precondition:  None
    // Postcondition: A String with the TwoDayAirPackage's data has been returned
    public override string ToString()
    {
        return $"TwoDayAirPackage{Environment.NewLine} Delivery Type: {DeliveryType}{Environment.NewLine}{base.ToString()}";
    }
}

