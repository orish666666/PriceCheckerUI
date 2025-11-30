// Pages/Categories.cshtml.cs
using Microsoft.AspNetCore.Mvc.RazorPages;
using PriceCheckerUI.Models;
using PriceCheckerUI.Services;

public class CategoriesModel : PageModel
{
    private readonly ApiService apiService;
    public CategoriesModel(ApiService apiService)
    {
        this.apiService = apiService;
    }

    public List<CategoryInfo> Categories { get; set; } = new();

    public async Task OnGetAsync()
    {
        Categories = await apiService.GetPredictedCategories();
    }
}
