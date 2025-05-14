using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCSharp
{
    internal class Inheritancecls
    {
    }
    class Shape1
    {

        double a_width;
        double a_length;

        // Default constructor
        public Shape1()
        {
            Width = Length = 0.0;
        }

        // Constructor for Shape
        public Shape1(double w, double l)
        {
            Width = w;
            Length = l;
        }

        // Construct an object with 
        // equal length and width
        public Shape1(double y)
        {
            Width = Length = y;
        }

        // Properties for Length and Width
        public double Width
        {
            get
            {
                return a_width;
            }

            set
            {
                a_width = value < 0 ? -value : value;
            }
        }

        public double Length
        {
            get
            {
                return a_length;
            }

            set
            {
                a_length = value < 0 ? -value : value;
            }
        }
        public void DisplayDim()
        {
            Console.WriteLine("Width and Length are "
                         + Width + " and " + Length);
        }
    }

    // A derived class of Shape 
    // for the rectangle.
    class Rectangle1 : Shape1
    {

        string Style;

        // A default constructor. 
        // This invokes the default
        // constructor of Shape.
        public Rectangle1()
        {
            Style = "null";
        }

        // Constructor
        public Rectangle1(string s, double w, double l)
            : base(w, l)
        {
            Style = s;
        }

        // Construct an square.
        public Rectangle1(double y)
            : base(y)
        {
            Style = "square";
        }

        // Return area of rectangle.
        public double Area()
        {
            return Width * Length;
        }

        // Display a rectangle's style.
        public void DisplayStyle()
        {
            Console.WriteLine("Rectangle is  " + Style);
        }
    }

    // Inheriting Rectangle class
    class ColorRectangle : Rectangle1
    {

        string rcolor;

        // Constructor
        public ColorRectangle(string c, string s,
                              double w, double l)
            : base(s, w, l)
        {
            rcolor = c;
        }

        // Display the color.
        public void DisplayColor()
        {
            Console.WriteLine("Color is " + rcolor);
        }
    }
}
