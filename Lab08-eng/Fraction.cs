using System;
using System.Net.Sockets;

namespace Lab8
{
    public struct Fraction
    {
        public long Numerator;
        public long Denominator;

     

        public Fraction(long n, long d)
        {
            Numerator = n;
            Denominator = d;
            if (d <= 0)
            {
                throw new ArgumentException("Denominator cannot be zero or negataive.", nameof(d));
            }
            
        }



        // TODO: Implement properties and constructor
        /*
        Your task is to implement Fraction structure.

        It should contain two public properties: Numerator and Denominator.
        For integers represented as fraction the Denominator should be 1.
The Denominator should be always positive - sign of the fraction should be placed in the Numerator.
ArgumentException should be thrown when Denominator is set to 0 or negative number.

The structure has 2 public constructors:
* 2-parameters constructor(long n, long d)
* 1-parameter constructor(long n). For 1-parameter constructor the Denominator is set to 1.*/

        //public Fraction(long n, long d)
        //{
        //    if (d <= 0  )
        //    {
        //        throw new ArgumentException("Denominator cannot be zero or negataive.", nameof(d));
        //    }
        //    Numerator = n;
        //    Denominator = d;
        //}

        public Fraction(long n)
        {
            
            Numerator = n;
            Denominator = 1L;
        }

        public override string ToString()
        {
            var whole = Numerator / Denominator;
            var num = Numerator - whole * Denominator;
            var sign = Numerator > 0;

            var str = string.Empty;
            if (!sign)
            {
                str += "-";
                num = -num;
                whole = -whole;
            }
            if (num == 0)
                str += $"[{whole}]";
            else if (whole != 0)
                str += $"[{whole} {num}/{Denominator}]";
            else
                str += $"[{num}/{Denominator}]";

            return str;
        }
        /* You should implement method to simplify fraction, eg. [2 / 4] -> [1/2], [3/9] -> [1/3]. 
 The helper method to calculate greatest common divisor would be helpful to calculate simplified fraction.
 The fraction should be always smplified(also when Numerator or Denominator changed).
 */

        public Fraction simplifyfraction(Fraction f)
        {
            long gcd = GCD(f.Numerator, f.Denominator);
            return new Fraction(f.Numerator / gcd, f.Denominator / gcd);
        }

        private long GCD(long a, long b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
                      
            for (; ; )
            {
                long remainder = a % b;
                if (remainder == 0) return b;
                a = b;
                b = remainder;
            };
        }

       /* You need to implement Reciprocal() method to invert the fraction, eg. [2 / 3] -> [3/2] ([1 1 / 2]). 
Reciprocal method should return simplified fraction too.*/

        public Fraction Reciprocal()
        {
           return new Fraction(this.Denominator, this.Numerator);
        }

        /*You need to implement 3 converters
        - implicit from long type to Fraction
        - explicit from Fraction to long
        - explicit from Fraction to double */

        public static implicit operator (long, long)(Fraction f)
        {
            return (f.Numerator, f.Denominator);
        }

      

        public static explicit operator long[](Fraction f)
        {
            return new long[] { f.Numerator, f.Denominator };
        }

        public static explicit operator double[](Fraction f)
        {
            return new double[] { f.Numerator, f.Denominator };
        }

        public static explicit operator double(Fraction f)
        {
            return f.Numerator/ f.Denominator;
        }

        public static Fraction operator +(Fraction f) => f;
        public static Fraction operator -(Fraction f) => new Fraction(-f.Numerator, f.Denominator);

        public static Fraction operator +(Fraction a, Fraction b)
            => new Fraction(a.Numerator * b.Denominator + b.Numerator * a.Denominator, a.Denominator * b.Numerator );

        public static Fraction operator -(Fraction a, Fraction b)
            => a + (-b);

        public static Fraction operator *(Fraction a, Fraction b)
            => new Fraction(a.Numerator * b.Numerator, a.Denominator * b.Denominator);

        public static Fraction operator /(Fraction a, Fraction b)
        {
            if (b.Numerator == 0)
            {
                throw new DivideByZeroException();
            }
            return new Fraction(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
        }

        //You need to implement comparison operators == != < > <= >= and override methods related to these operators.


        public static bool operator ==(Fraction f1, Fraction f2)
        {
            return f1.Equals(f2);
        }

        public static bool operator !=(Fraction f1, Fraction f2)
        {
            return !f1.Equals(f2);
        }

        public static bool operator < (Fraction f1, Fraction f2)
        {
            long Y = f1.Numerator * f2.Denominator - f1.Denominator * f2.Numerator;
            return (Y < 0);

           
        }

        public static bool operator >(Fraction f1, Fraction f2)
        {
            long Y = f1.Numerator * f2.Denominator - f1.Denominator * f2.Numerator;
            return (Y > 0);
        }

        public static bool operator <=(Fraction f1, Fraction f2)
        {
            long Y = f1.Numerator * f2.Denominator - f1.Denominator * f2.Numerator;
            return (Y <= 0);


        }

        public static bool operator >=(Fraction f1, Fraction f2)
        {
            long Y = f1.Numerator * f2.Denominator - f1.Denominator * f2.Numerator;
            return (Y >= 0);
        }

        // TODO: Implement all others methods, operators, etc.
    }
}