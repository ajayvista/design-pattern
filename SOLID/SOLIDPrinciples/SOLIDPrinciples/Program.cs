using System;

namespace PrincipalViolation
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

namespace LiskovPrincipal
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

namespace LiskovDesignPrincipalEx0
{

	class MainClass
	{
		public static void Main(string[] args)
		{

			//violating the principal
			//LSV states: Derived classes (here it is Square) should be substitutable for their base classes (or interfaces)
			//Methods that use references to base classes (or interfaces) have to be able to use methods of the derived classes
			//without knowing about it or knowing the details.
			PrincipalViolation.Rectangle rectangle = new PrincipalViolation.Square();
			rectangle.Width = 10;

			Console.WriteLine($"output:{rectangle.Height}"); // output = isntead of 10 - output is 0
			Console.WriteLine($"output:{rectangle.ToString()}"); // output =0



			//as per principal
			//base reference is substibute for derived class object and access the properties as like derived class reference
			LiskovPrincipal.Rectangle rectangle1 = new LiskovPrincipal.Square();
			rectangle1.Width = 10;

			Console.WriteLine($"output:{rectangle1.Height}"); // output = output is 10
			Console.ReadKey();
		}
	}
}

