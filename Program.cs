using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}using System;

public abstract class Vehicle
{
    public int Speed { get; set; }
    public int Capacity { get; set; }

    public Vehicle(int speed, int capacity)
    {
        Speed = speed;
        Capacity = capacity;
    }

    public abstract void Move();
}

public class Human
{
    public int Speed { get; set; }

    public Human(int speed)
    {
        Speed = speed;
    }

    public void Move()
    {
        Console.WriteLine("Walking");
    }
}

public class Car : Vehicle
{
    public Car(int speed, int capacity) : base(speed, capacity) { }

    public override void Move()
    {
        Console.WriteLine("Driving a car");
    }
}

public class Bus : Vehicle
{
    public Bus(int speed, int capacity) : base(speed, capacity) { }

    public override void Move()
    {
        Console.WriteLine("Taking a bus");
    }
}

public class Train : Vehicle
{
    public Train(int speed, int capacity) : base(speed, capacity) { }

    public override void Move()
    {
        Console.WriteLine("Riding a train");
    }
}

public class Route
{
    public string Start { get; set; }
    public string End { get; set; }

    public Route(string start, string end)
    {
        Start = start;
        End = end;
    }
}

public class TransportNetwork
{
    private readonly List<Vehicle> vehicles = new List<Vehicle>();

    public void AddVehicle(Vehicle vehicle)
    {
        vehicles.Add(vehicle);
    }

    public void ControlMovement(Route route)
    {
        foreach (var vehicle in vehicles)
        {
            vehicle.Move();
        }
        Console.WriteLine($"Travelling from {route.Start} to {route.End}");
    }
}

class Program
{
    static void Main()
    {
        Route route = new Route("City A", "City B");
        Human human = new Human(5);
        Car car = new Car(60, 4);
        Bus bus = new Bus(40, 40);
        Train train = new Train(100, 200);

        TransportNetwork network = new TransportNetwork();
        network.AddVehicle(human);
        network.AddVehicle(car);
        network.AddVehicle(bus);
        network.AddVehicle(train);
        network.ControlMovement(route);
    }
}
using System;

public class MathOperations
{
    public static T Add<T>(T a, T b)
    {
        dynamic da = a;
        dynamic db = b;
        return da + db;
    }

    public static T Subtract<T>(T a, T b)
    {
        dynamic da = a;
        dynamic db = b;
        return da - db;
    }

    public static T Multiply<T>(T a, T b)
    {
        dynamic da = a;
        dynamic db = b;
        return da * db;
    }

    public static T Divide<T>(T a, T b)
    {
        dynamic da = a;
        dynamic db = b;
        if (db == 0)
        {
            throw new DivideByZeroException("Division by zero is not allowed");
        }
        return da / db;
    }
}

class Program
{
    static void Main()
    {
        int a = 5, b = 3;
        int result = MathOperations.Add(a, b);
        Console.WriteLine(result);

        double x = 10.0, y = 4.0;
        double doubleResult = MathOperations.Subtract(x, y);
        Console.WriteLine(doubleResult);
    }
}
using System;

public class Quaternion
{
    public double W { get; set; }
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }

    public Quaternion(double w, double x, double y, double z)
    {
        W = w;
        X = x;
        Y = y;
        Z = z;
    }

    public static Quaternion operator +(Quaternion q1, Quaternion q2)
    {
        return new Quaternion(q1.W + q2.W, q1.X + q2.X, q1.Y + q2.Y, q1.Z + q2.Z);
    }

    public static Quaternion operator -(Quaternion q1, Quaternion q2)
    {
        return new Quaternion(q1.W - q2.W, q1.X - q2.X, q1.Y - q2.Y, q1.Z - q2.Z);
    }

    public static Quaternion operator *(Quaternion q1, Quaternion q2)
    {
        double w = q1.W * q2.W - q1.X * q2.X - q1.Y * q2.Y - q1.Z * q2.Z;
        double x = q1.W * q2.X + q1.X * q2.W + q1.Y * q2.Z - q1.Z * q2.Y;
        double y = q1.W * q2.Y - q1.X * q2.Z + q1.Y * q2.W + q1.Z * q2.X;
        double z = q1.W * q2.Z + q1.X * q2.Y - q1.Y * q2.X + q1.Z * q2.W;
        return new Quaternion(w, x, y, z);
    }

    public static bool operator ==(Quaternion q1, Quaternion q2)
    {
        return q1.W == q2.W && q1.X == q2.X && q1.Y == q2.Y && q1.Z == q2.Z;
    }

    public static bool operator !=(Quaternion q1, Quaternion q2)
    {
        return !(q1 == q2);
    }

    public double Norm()
    {
        return Math.Sqrt(W * W + X * X + Y * Y + Z * Z);
    }

    public Quaternion Conjugate()
    {
        return new Quaternion(W, -X, -Y, -Z);
    }

    public Quaternion Inverse()
    {
        double normSquared = Norm() * Norm();
        Quaternion conjugate = Conjugate();
        return new Quaternion(conjugate.W / normSquared, conjugate.X / normSquared, conjugate.Y / normSquared, conjugate.Z / normSquared);
    }

    public Matrix3x3 ToRotationMatrix()
    {
        // Реалізуйте конвертацію кватерніона в матрицю обертання
        return null;
    }
}

public struct Matrix3x3
{
    // Реалізуйте клас Matrix3x3 для представлення матриці 3x3
    public double M11 { get; set; }
    public double M12 { get; set; }
    public double M13 { get; set; }
    public double M21 { get; set; }
    public double M22 { get; set; }
    public double M23 { get; set; }
    public double M31 { get; set; }
    public double M32 { get; set; }
    public double M33 { get; set; }
}

class Program
{
    static void Main()
    {
        Quaternion q1 = new Quaternion(1, 2, 3, 4);
        Quaternion q2 = new Quaternion(5, 6, 7, 8);
        Quaternion q3 = q1 + q2;
        Quaternion q4 = q1 * q2;

        Console.WriteLine($"{q3.W}, {q3.X}, {q3.Y}, {q3.Z}");
        Console.WriteLine($"{q4.W}, {q4.X}, {q4.Y}, {q4.Z}");
    }
}
using System;
using System.Collections.Generic;

public abstract class GraphicPrimitive
{
    public int X { get; set; }
    public int Y { get; set; }

    public GraphicPrimitive(int x, int y)
    {
        X = x;
        Y = y;
    }

    public abstract void Draw();

    public virtual void Move(int x, int y)
    {
        X += x;
        Y += y;
    }
}

public class Circle : GraphicPrimitive
{
    public int Radius { get; set; }

    public Circle(int x, int y, int radius) : base(x, y)
    {
        Radius = radius;
    }

    public override void Draw()
    {
        Console.WriteLine($"Drawing a circle at ({X}, {Y}) with radius {Radius}");
    }

    public void Scale(float factor)
    {
        Radius = (int)(Radius * factor);
    }
}

public class Rectangle : GraphicPrimitive
{
    public int Width { get; set; }
    public int Height { get; set; }

    public Rectangle(int x, int y, int width, int height) : base(x, y)
    {
        Width = width;
        Height = height;
    }

    public override void Draw()
    {
        Console.WriteLine($"Drawing a rectangle at ({X}, {Y}) with width {Width} and height {Height}");
    }

    public void Scale(float factor)
    {
        Width = (int)(Width * factor);
        Height = (int)(Height * factor);
    }
}

public class Triangle : GraphicPrimitive
{
    public override void Draw()
    {
        Console.WriteLine($"Drawing a triangle at ({X}, {Y})");
    }
}

public class Group : GraphicPrimitive
{
    private List<GraphicPrimitive> primitives = new List<GraphicPrimitive>();

    public Group(int x, int y) : base(x, y) { }

    public void AddPrimitive(GraphicPrimitive primitive)
    {
        primitives.Add(primitive);
    }

    public override void Move(int x, int y)
    {
        base.Move(x, y);
        foreach (var primitive in primitives)
        {
            primitive.Move(x, y);
        }
    }

    public override void Draw()
    {
        foreach (var primitive in primitives)
        {
            primitive.Draw();
        }
    }

    public void Scale(float factor)
    {
        foreach (var primitive in primitives)
        {
            if (primitive is Circle circle)
            {
                circle.Scale(factor);
            }
            else if (primitive is Rectangle rectangle)
            {
                rectangle.Scale(factor);
            }
        }
    }
}

class Program
{
    static void Main()
    {
        Circle circle = new Circle(10, 10, 5);
        Rectangle rectangle = new Rectangle(20, 20, 8, 6);
        Triangle triangle = new Triangle();
        Group group = new Group(0, 0);

        group.AddPrimitive(circle);
        group.AddPrimitive(rectangle);
        group.AddPrimitive(triangle);

        group.Move(5, 5);
        group.Draw();

        // Масштабування всіх кола та прямокутника у групі на 2
        group.Scale(2.0f);
        group.Draw();
    }
}


