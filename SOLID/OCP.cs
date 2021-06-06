using System;
using System.Collections.Generic;
using static System.Console;

namespace SOLID
{
    public enum Color
    {
        Red,
        Green,
        Blue
    }

    public enum Size
    {
        Small,
        Medium,
        Large,
        Yuge
    }

    public class Product
    {
        public string Name;
        public Color Color;
        public Size Size;

        public Product(string name, Color color, Size size)
        {
            if (name == null)
            {
                throw new ArgumentNullException(paramName: nameof(name));
            }

            Name = name;
            Color = color;
            Size = size;
        }
    }

    public class ProductFilter
    {
        public IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
        {
            foreach (var p in products)
            {
                if (p.Size == size)
                {
                    yield return p;
                }
            }
        }

        public IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color)
        {
            foreach (var p in products)
            {
                if (p.Color == color)
                {
                    yield return p;
                }
            }
        }
    }

    public interface ISpecification<T>
    {
        bool IsSatisfied(T t);
    }
    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
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
            return t.Color == Color;
        }
    }

    public class BetterFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> spec)
        {
            foreach (var item in items)
            {
                if (spec.IsSatisfied(item))
                {
                    yield return item;
                }
            }
        }
    }

    public class SizeSpecification : ISpecification<Product>
    {
        private Size Size;
        public SizeSpecification(Size size)
        {
            Size = size;
        }
        public bool IsSatisfied(Product t)
        {
            return t.Size == Size;
        }
    }

    public class AndSpecification<T> : ISpecification<T>
    {
        private ISpecification<T> First, Second;

        public AndSpecification(ISpecification<T> first, ISpecification<T> second)
        {
            First = first ?? throw new ArgumentNullException(nameof(first));
            Second = second ?? throw new ArgumentNullException(nameof(second));
        }

        public bool IsSatisfied(T t)
        {
            return First.IsSatisfied(t) && Second.IsSatisfied(t);
        }
    }

    public class OCP
    {
        static void MainOCP(string[] args)
        {
            var apple = new Product("apple", Color.Green, Size.Small);
            var tree = new Product("tree", Color.Green, Size.Large);
            var house = new Product("house", Color.Blue, Size.Large);

            Product[] products = { apple, tree, house };
            var pf = new ProductFilter();
            WriteLine("Green products (old): ");

            foreach (var p in pf.FilterByColor(products, Color.Green))
            {
                WriteLine($" - {p.Name} is green");
            }

            var bf = new BetterFilter();
            WriteLine("Green products (new): ");

            foreach (var p in bf.Filter(products, new ColorSpecification(Color.Green)))
            {
                WriteLine($" - {p.Name} is green");
            }

            WriteLine("Large blue items: ");
            var andSpecifcation = new AndSpecification<Product>(new ColorSpecification(Color.Blue), new SizeSpecification(Size.Large));
            foreach (var p in bf.Filter(products, andSpecifcation))
            {
                WriteLine($" - {p.Name} is blue");
            }

            ReadKey();
        }
    }
}
