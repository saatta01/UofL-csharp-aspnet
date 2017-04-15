using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//including your name, program number, due date, course section, and description of each file's class
// Sara Attarzadeh
// Program 1A
// Due Date 10/11/16
// Course Section: 200-01
//Description: This package class, derived from parcel is an abstract class that now takes into account the dimensions of a package when calculating cost
public abstract class Package : Parcel
{
    private double length;
    private double width;
    private double height;
    private double weight;



    // Package constructor
    // Precondition: dimensions and weight both > 0
    // Postcondition: The Package is created with the specified values for
    //                origin address, destination address, and dimensions

    public Package(Address originAddress, Address destAddress,
        double lengthInInches, double widthInInches, double heightInInches, double weightInPounds)
        : base(originAddress, destAddress)
    {
        Length= lengthInInches;
        Width = widthInInches;
        Height = heightInInches;
        Weight = weightInPounds;
    }

    //Get and set property for each of the data fields(Length, Width, Height, and Weight).
    public double Length
    {
        // Precondition:  None
        // Postcondition: The Package's length has been returned
        get
        {
            return length;
        }

        // Precondition: value for length > 0
        // Postcondition: The Package's length has been set to specified value
        set
        {
            if (value > 0)
            {
                length = value;
            }
            else
                throw new ArgumentOutOfRangeException("Length", value,
                    "Length must be > 0");
        }
    }

    public double Width
    {
        // Precondition:  None
        // Postcondition: The Package's widgth has been returned
        get
        {
            return width;
        }

        // Precondition:  value for width > 0 
        // Postcondition: The Package's width has been set to the
        //                specified value
        set
        {
            if (value > 0)
            {
                width = value;
            }
            else
                throw new ArgumentOutOfRangeException("Width", value,
                    "Width must be > 0");
        }
    }

    public double Height
    {
        // Precondition:  None
        // Postcondition: The Package's height has been returned
        get
        {
            return height;
        }

        // Precondition:  value for height > 0 
        // Postcondition: The Package's height has been set to the
        //                specified value
        set
        {
            if (value > 0)
            {
                height = value;
            }
            else
                throw new ArgumentOutOfRangeException("Height", value,
                    "Height must be > 0");
        }
    }

    public double Weight
    {
        // Precondition:  None
        // Postcondition: The Package's weight has been returned
        get
        {
            return weight;
        }

        // Precondition:  value for weight > 0
        // Postcondition: The Package's weight has been set to the
        //                specified value
        set
        {
            if (value > 0)
            {
                weight = value;
            }
            else
                throw new ArgumentOutOfRangeException("Weight", value,
                    "Weight must be > 0");
        }
    }

    // Precondition:  None
    // Postcondition: A String with the Packages's data has been returned, including dimensions and weight
    public override string ToString()
    {
        return $"Package{Environment.NewLine}{base.ToString()}, {Length}, {Width}, {Height}, {Weight}";
    }

}

