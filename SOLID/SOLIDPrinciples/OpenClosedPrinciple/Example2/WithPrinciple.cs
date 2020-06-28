using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace OpenClosedPrincipleEx0.Example2
{
    public interface IFilter<T>
	{
		 IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> specification);
	}

	public interface ISpecification<T>
	{
		 bool IsSatisfied(T t);
	}

	public class NewProductFilter : IFilter<Product>
	{
		public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> specification)
		{
			foreach (var item in items)
				if (specification.IsSatisfied(item))
					yield return item;
		}
	}

	public class ColorSpecification : ISpecification<Product>
	{
		private Color Color;
		public ColorSpecification(Color color)
		{
			Color = color;
		}
		public bool IsSatisfied(Product t)
		{
			return this.Color == t.Color;
		}
	}

	public class SizeSpecification : ISpecification<Product>
	{
		private Size _size;
		public SizeSpecification(Size size)
		{
			_size = size;
		}
		public bool IsSatisfied(Product t)
		{
			return this._size == t.Size;
		}
	}

	public class AndSpecification<T>: ISpecification<T>
	{
		private ISpecification<T> left, right;

		public AndSpecification(
			ISpecification<T> left,
			ISpecification<T> right)
		{
			this.left = left;
			this.right = right;
		}

		public bool IsSatisfied(T t)
		{
			return this.left.IsSatisfied(t)
				&& this.right.IsSatisfied(t);
		}
	}

	public class OrSpecification<T> : ISpecification<T>
	{
		private ISpecification<T> left, right;

		public OrSpecification(
			ISpecification<T> left,
			ISpecification<T> right)
		{
			this.left = left;
			this.right = right;
		}

		public bool IsSatisfied(T t)
		{
			return this.left.IsSatisfied(t)
				|| this.right.IsSatisfied(t);
		}
	}
}
