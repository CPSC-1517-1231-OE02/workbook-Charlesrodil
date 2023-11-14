using Microsoft.AspNetCore.Components;
using WestWindSystem.BLL;
using WestWindSystem.Entities;

namespace WestWindWebApp.Pages
{
    public partial class ProductsPage
    {
        [Inject]
        CategoryServices CategoryServices { get; set; }
        [Inject]
        ProductServices ProductServices { get; set; }
        [Inject]
        NavigationManager NavigationManager { get; set; }

        public string PartialSearch { get; set; } = null;
        public List<Category>? Categories { get; set; } = null;
        public List<Product>? Products { get; set; } = null;

        [Parameter]
        public string? CategoryId { get; set; } = null;

        protected override void OnInitialized()
        {
            Categories = CategoryServices.GetAllCategories();
            if (CategoryId != null)
            {
				Products = ProductServices.GetProductsByCategoryID(int.Parse(CategoryId));

				// Alternatively you can use
				// Products = ProductServices.GetProductsByCategoryID(int.Parse(CategoryId));
			}

            base.OnInitialized();
        }

        private void HandleCategorySelect()
        {
            if (CategoryId != null)
            {
                Products = ProductServices.GetProductsByCategoryID(int.Parse(CategoryId));
                PartialSearch = null;
                NavigationManager.NavigateTo($"/products/{CategoryId}");
            }
        }

        private void HandlePartialSearch()
        {
            if (!string.IsNullOrWhiteSpace(PartialSearch))
            {
                Products = ProductServices.GetProductsByNameOrCategoryName(PartialSearch);
                CategoryId = null;
                NavigationManager.NavigateTo($"/products/{PartialSearch}");

			}
        }


	}
}
