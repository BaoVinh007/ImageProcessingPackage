using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace imageCsharp
{
    class Complex
    {
        public double real;
        public double imaginary;

        // Constructor. 
        public Complex()
        { 
            real = 0.0;
            imaginary = 1;
        }
        
        public Complex(double real, double imaginary)
        {
            this.real = real;
            this.imaginary = imaginary;
        }

        public double magnitude()
        {
            return Math.Sqrt( real * real + imaginary * imaginary);
        }

        public double phase()
        {
            if (real != 0)
            {
                return Math.Atan(imaginary / real);
            }
            else 
            {
                return Math.Atan(imaginary);
            }
            
        }
       
       
        public static Complex operator +(Complex c1, Complex c2)
        {
            return new Complex(c1.real + c2.real, c1.imaginary + c2.imaginary);
        }

        public static Complex operator -(Complex c1, Complex c2)
        {
            return new Complex(c1.real - c2.real, c1.imaginary - c2.imaginary);
        }

        public static Complex operator *(Complex c1, Complex c2)
        {            
            return new Complex(c1.real * c2.real - c1.imaginary * c2.imaginary, c1.real * c2.imaginary + c1.imaginary * c2.real);
        }        
        
        public static Complex operator /(Complex c1, Complex c2)
        {
            double denominator = c1.real * c2.real + c1.imaginary * c2.imaginary;
            return new Complex((c1.real * c2.real + c1.imaginary * c2.imaginary)/denominator,
                (c1.imaginary * c2.real - c1.real * c2.imaginary)/denominator);
        }

        public static Complex operator +(Complex c1, double c2)
        {
            return new Complex(c1.real + c2, c1.imaginary);
        }

        public static Complex operator -(Complex c1, double c2)
        {
            return new Complex(c1.real - c2, c1.imaginary);
        }

        public static Complex operator *(Complex c1, double c2)
        {
            return new Complex(c1.real * c2, c1.imaginary * c2);
        }

        public static Complex operator /(Complex c1, double c2)
        {
            return new Complex(c1.real / c2, c1.imaginary / c2);
        }

        public static Complex operator +( double c2, Complex c1)
        {
            return new Complex(c1.real + c2, c1.imaginary);
        }

        public static Complex operator -( double c2, Complex c1)
        {
            return new Complex(c2 - c1.real , c1.imaginary);
        }

        public static Complex operator *( double c2, Complex c1)
        {
            return new Complex(c2 * c1.real, c2 * c1.imaginary);
        }

        public static Complex operator /( double c2, Complex c1)
        {
            return new Complex(c1.real / c2, c1.imaginary / c2);
        }

        public static bool operator ==(Complex c2, Complex c1)
        {
            return c1.real == c2.real && c1.imaginary == c2.imaginary;            
        }

        public static bool operator !=(Complex c2, Complex c1)
        {
            return c1.real != c2.real || c1.imaginary != c2.imaginary;
        }

        public static bool operator ==(Complex c1, double c2)
        {
            return c1.real == c2 && c1.imaginary == 0.0;
        }

        public static bool operator !=(Complex c1, double c2)
        {
            return c1.real != c2 || c1.imaginary != 0;
        }

        // Override the ToString() method to display a complex number  
        // in the traditional format: 
        public override string ToString()
        {
            return (System.String.Format("{0} + {1}i", real, imaginary));
        }
    }
}
