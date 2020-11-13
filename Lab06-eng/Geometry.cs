using System;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace lab06
{
    
//Define `struct` named Point2D.
//- It contains `public` fields `x`, `y` of type `double`. 
//- Fields are immutable.
//- It contains constructor that takes from 0, 1 or 2 `double`s.
//  In case when number of passed arguments is 0 or 1 then value of not specified coordinates should be set to  0.
//  Order of passed parameters from left to right is: x, y.
//- It allows to provide value for specific coordinate and set other coordinates to 0.
//- When instance is passed as argument to `Console.WriteLine` method it output message in following format: (x, y)
//- Creating instance of `Point2D` with some explicit coordinates should print following message on `Console`
//  "Point2D(x, y) has been created".
//  Remember about 'Do not repeat yourself (DRY)' rule

    public struct Point2D
    {
        public static double x, y ;

        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }

        //public Point2D()
        //{
        //    x = 0;
        //    y = 0;
        //    Console.WriteLine($"Point2D({x}, {y}) hasen created");
        //}
        public Point2D(double _x)
        {
            x = _x;
            y = 0;
            Console.WriteLine($"Point2D({x}, {y}) hasen created");
        }
        public Point2D(double _x, double _y)
        {
            x = _x;
            y = _y;
           // Console.WriteLine(" (x, y) : ");
            Console.WriteLine($"Point2D({x}, {y}) hasen created");
        }
        

    }
//## Stage 2 - 1 point

//    Create static `class` named `Geometry`. It contains 2 public methods:

//`Distance` method that takes two `Point2D` points and returns cartesian distance between them.

//`PolygonCircuit` method that takes variable number of `Point2D`s and calculates circuit of created polygon.
// In case where number of passed points is less than 3 method should return -1.0.

//Both methods are not modifying instance of passed arguments and should be annotated with proper keyword for compiler.


    public static class Geometry
      {
        //public static Point2D A;
        //public static Point2D B;
        public static double Distance(Point2D _A, Point2D _B)
        {
            return Math.Sqrt(Math.Pow((_A.X -_B.X), 2) + Math.Pow(_A.Y-_B.Y, 2));
        }

        public static double PolygonCircuit(Point2D P1, Point2D P2, Point2D P3)
        {

            return  Distance(P1, P2) + Distance(P1,P3) + Distance (P2,P3) ;
        }

        public static double PolygonCircuit(Point2D[] _Point2D)
        {
            double totaldistance=0;

            for (int i = 0; i < _Point2D.Length-1; i++)
            {
                double d = Distance(_Point2D[i], _Point2D[i + 1]);
                totaldistance = totaldistance + d;
            }
            totaldistance = totaldistance + Distance(_Point2D[0],_Point2D[_Point2D.Length -1 ]);

            return totaldistance;
        }


    }

    //    Create abstract `class` named `Shape`. 
    //It contains abstract method `Circuit` that calculates circuit of given shape.

    //Create abstract `class` named `Polygon` that inherits from `Shape` class. 
    //It contains protected constructor that takes variable number of `Point2Ds`. 
    //It contains array of points of given polygon - public field.
    //It provides implementation for `Circuit` method that calculates circuit for any polygon.

    
    public abstract class Shape
    {
       
        public abstract double Circuit (Point2D[] _Point2D);
        
    }

    public  class Polygon: Shape
    {
        
        protected Polygon(Point2D[] _Point2D)
        { }
        public override double Circuit(Point2D[] _Point2D)
        {
            double Distance=0;

            for (int i = 0; i < _Point2D.Length - 1; i++)
            {
                //return Math.Sqrt(Math.Pow((_A.X - _B.X), 2) + Math.Pow(_A.Y - _B.Y, 2));
                double d = Math.Sqrt(Math.Pow((_Point2D[i].X - _Point2D[i + 1].X), 2) + Math.Pow((_Point2D[i].Y - _Point2D[i + 1].Y), 2));

                Distance = Distance + d;
            }
            Distance = Distance + Math.Sqrt(Math.Pow((_Point2D[0].X - _Point2D[_Point2D.Length-1].X), 2) + Math.Pow((_Point2D[0].Y - _Point2D[_Point2D.Length-1].Y), 2));

            return Distance;
        }




    }
    //Create `Rectangle` class that inherits from `Polygon`. `Polygon` has two constructors:
    //- constructor that takes single Point2D as left bottom point and 2 double numbers that represent width and height.
    //- Constructor that takes single Point2D as left bottom point and 1 double number that represents side of square - special case of rectangle.
    //`Rectangle` has public field of type `double` that holds length of rectangle's diagonal.

    //Create `Circle` class that inherits from `Shape`.
    //Constructor takes single `Point2D` as circle center and 1 number that represents length of the radius.
    //Values passed are accesible as public fields.

    //public class Rectangle : Polygon

    //{
    //   // Point2D P;
    //    //double l, h;

    //    public Rectangle(Point2D _P, double _l, double _h):base(_p)
    //    { 
    //    }


    //}


}
