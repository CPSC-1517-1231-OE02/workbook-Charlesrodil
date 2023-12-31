using Microsoft.AspNetCore.Components;
using WestWindSystem.BLL;
using WestWindSystem.Entities;

namespace WestWindWebApp.Pages
{
	public partial class ProductPage
	{
		[Inject]
		ProductServices ProductServices { get; set; }

		[Inject]
		CategoryServices CategoryServices { get; set; }

		[Inject]
		SupplierServices SupplierServices { get; set; }

		[Inject]
		NavigationManager NavigationManager { get; set; }

		[Parameter]
		public int ProductId { get; set; }

		private List<Supplier>? Suppliers { get; set; } = new();
		private List<Category>? Categories { get; set; } = new();

		private Product? Product { get; set; }

		private Dictionary<string, string> Errors { get; set; } = new();
		private string? FeedbackMessage { get; set; }

		/// <summary>
		/// Validate the form controls before processing
		/// </summary>
		/// <returns>True if no errors were found, false otherwise</returns>
		private bool ValidateForm()
		{
			Errors.Clear();

			if (string.IsNullOrWhiteSpace(Product!.ProductName))
			{
				Errors.Add("product-name", "Product name cannot be empty.");
			}

			if (string.IsNullOrWhiteSpace(Product.QuantityPerUnit))
			{
				Errors.Add("quantity", "Quantity per unit cannot be empty.");
			}

			if (Product.UnitPrice <= 0)
			{
				Errors.Add("unit-price", "Unit price must be greater than zero.");
			}

			if (Product.UnitsOnOrder < 0)
			{
				Errors.Add("units-order", "Units on order cannot be negative.");
			}

			if (Product.CategoryId == 0)
			{
				Errors.Add("category", "Must choose a category.");
			}

			if (Product.SupplierId == 0)
			{
				Errors.Add("supplier", "Must choose a supplier.");
			}

			return Errors.Count == 0;
		}

		protected override void OnInitialized()
		{
			Categories = CategoryServices.GetAllCategories();
			Suppliers = SupplierServices.GetAllSuppliers();
			Errors = new Dictionary<string, string>();

			if (ProductId != 0)
			{
				Product = ProductServices.GetProductById(ProductId);

				if (Product == null)
				{
					Errors.Add("init-product", $"No product with the id of {ProductId} was found");
					Product = new Product();
				}
			}
			else
			{
				Product = new Product();
			}

			base.OnInitialized();
		}

		/// <summary>
		/// Process form submission and update or create a new product
		/// </summary>
		private void HandleSaveProduct()
		{
			if (ValidateForm())
			{
				if (ProductId == 0)
				{
					try
					{
						ProductServices.AddProduct(Product!);
						FeedbackMessage = "Product successfully added";
						NavigationManager.NavigateTo($"/product/{Product!.ProductId}");
					}
					catch (Exception ex)
					{
						Errors.Add("product-add", ex.Message);
					}
				}
				else
				{
					try
					{
						ProductServices.UpdateProduct(Product!);
						FeedbackMessage = "Product successfully updated";
					}
					catch (Exception ex)
					{
						Errors.Add("product-update", ex.Message);
					}
				}
			}
		}

		/// <summary>
		/// Handle form submission and discontinue a product
		/// </summary>
		private void HandleDiscontinue()
		{
			if (Product!.ProductId != 0)
			{
				try
				{
					ProductServices.DiscontinueProduct(Product);
					FeedbackMessage = "Product successfully discontinued";
				}
				catch (Exception ex)
				{
					Errors.Add("product-discontinue", ex.Message);
				}
			}
		}
	}
}
