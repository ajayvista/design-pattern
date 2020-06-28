using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
namespace OpenClosedPrincipleEx0.Example2
{
	public enum Color
	{
		Red,
		Blue,
		Green
	}

	public enum Size
	{
		Small,
		Medium,
		Large,
		ExtraLarge
	}

	public class Product
    {
		public Color Color { get; set; }
		public Size Size { get; set; }
		public string Name { get; set; }

		public Product(string name, Color color, Size size )
		{
			this.Name = name;
			this.Size = size;
			this.Color = color;
		}
    }

	public static class ProductFilter
	{
		public static IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
		{
			foreach (var p in products)
			{
				if (p.Size == size)
					yield return p;
			}
		}

		public static IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color)
		{
			foreach (var p in products)
			{
				if (p.Color == color)
					yield return p;
			}
		}

		public static IEnumerable<Product> FilterByName(IEnumerable<Product> products, string name)
		{
			foreach (var p in products)
			{
				if (p.Name == name)
					yield return p;
			}
		}
	}
}
