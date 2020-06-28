using System;

namespace PrincipleViolation
{
	public class Rectangle
	{
		public int Height { get; set; }
		public int Width { get; set; }

		public Rectangle()
		{ }

		public Rectangle(int height, int width)
		{
			this.Height = height;
			this.Width = width;
		}

		public override string ToString()
		{
			return $"{nameof(this.Height)}:{Height} x {nameof(this.Width)}:{Width}";
		}
	}

	public class Square : Rectangle
	{
		public new int Height
		{
			set { base.Height = value; base.Width = value; }
		}
		public new int Width
		{
			set { base.Width = value; base.Height = value; }
		}
	}
}

namespace LiskovPrincipleOption1
{
	public class Rectangle
	{
		public virtual int Height { get; set; }
		public virtual int Width { get; set; }

		public Rectangle()
		{ }

		public Rectangle(int height, int width)
		{
			this.Height = height;
			this.Width = width;
		}

		public override string ToString()
		{
			return $"{nameof(this.Height)}:{Height} x {nameof(this.Width)}:{Width}";
		}
	}

	public class Square : Rectangle
	{
		public override int Height
		{
			set { base.Height = value; base.Width = value; }
		}
		public override int Width
		{
			set { base.Width = value; base.Height = value; }
		}
	}
}

namespace LiskovPrincipleOption2
{
	public abstract class Shape
	{
		public virtual int Height { get; set; }
		public virtual int Width { get; set; }
		public abstract int CalculateArea();
	}

	public class Rectangle : Shape
	{
		public override int Height { get;  set ; }
		public override int Width { get; set; }

		public Rectangle(int height, int width)
		{
			this.Height = height;
			this.Width = width;
		}

		public override int CalculateArea()
		{
			return this.Height * this.Width;
		}

		public override string ToString()
		{
			return $"{nameof(this.Height)}:{Height} x {nameof(this.Width)}:{Width}";
		}
	}

	public class Square : Shape
	{
		int _temp;
		public override int Height { get { return _temp; } set { this._temp = value; } }
		public override int Width { get { return _temp; } set { this._temp = value; } }

		public Square(int height)
		{
			_temp = height;
		}

		public override int CalculateArea()
		{
			return this._temp * this._temp;
		}

		public override string ToString()
		{
			return $"{nameof(this.Height)}:{Height} x {nameof(this.Width)}:{Width}";
		}
	}
}

namespace LiskovDesignprincipleEx0
{

	class MainClass
	{
		public static void Main(string[] args)
		{

			//violating the principle
			//LSV states: Derived classes (here it is Square) should be substitutable for their base classes (or interfaces)
			//Methods that use references to base classes (or interfaces) have to be able to use methods of the derived classes
			//without knowing about it or knowing the details.
			PrincipleViolation.Rectangle rectangle = new PrincipleViolation.Square();
			rectangle.Width = 10;

			Console.WriteLine($"output:{rectangle.Height}"); // output = isntead of 10 - output is 0
			Console.WriteLine($"output:{rectangle.ToString()}"); // output =0



			//As per principle - option 1
			//Base reference can be substibute for derived class object and access the properties as like derived class reference
			LiskovPrincipleOption1.Rectangle rectangle1 = new LiskovPrincipleOption1.Square();
			rectangle1.Width = 10;


			//As per principle - option 2
			//Base reference can be substibute for derived class object and access the properties as like derived class reference
			LiskovPrincipleOption2.Shape shape = new LiskovPrincipleOption2.Rectangle(2,2);
			shape.Width = 10;
			Console.WriteLine($"Rectange Area:{shape.CalculateArea()}"); // output = output is 10


			shape = new LiskovPrincipleOption2.Square(22);
			shape.Width = 10;
			Console.WriteLine($"Shape Area:{shape.CalculateArea()}"); 
			Console.WriteLine($"Height:{shape.Height}"); 



			Console.ReadKey();
		}
	}
}

