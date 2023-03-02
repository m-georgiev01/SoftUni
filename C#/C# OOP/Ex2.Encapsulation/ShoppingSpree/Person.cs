using System.Diagnostics.Metrics;

namespace ShoppingSpree
{
	public class Person
	{
		private string name;
		private decimal money;
		private List<Product> products;

		public Person(string name, decimal money)
		{
			Name = name;
			Money = money;
			products = new();
		}

		public string Name
		{
			get => name;
			private set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException("Name cannot be empty");
				}

				name = value;
			}
		}

		public decimal Money
		{
			get => money;
			private set
			{
				if (value < 0)
				{
					throw new ArgumentException("Money cannot be negative");
				}

				money = value;
			}
		}

		public IReadOnlyList<Product> Products => products.AsReadOnly();

		public string BuyProduct(Product product)
		{
            if (Money - product.Cost < 0)
			{
                return $"{Name} can't afford {product.Name}";
            }

            Money -= product.Cost;
			products.Add(product);

            return $"{Name} bought {product.Name}";
        }

		public override string ToString()
		{
			if (!Products.Any())
			{
				return $"{Name} - Nothing bought";
			}

			return $"{Name} - {string.Join(", ", Products)}";
		}
	}
}
