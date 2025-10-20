using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PriceCheckerUI.Models;
using PriceCheckerUI.Services;
using System.Data;

public class PredictionsModel : PageModel
{
    private readonly ApiService apiService;
    public PredictionsModel(ApiService apiService)
    {
        this.apiService = apiService;
    }

    public string CategoryId { get; set; }
    [BindProperty(SupportsGet = true)]
    public string CategoryName { get; set; }
    [BindProperty(SupportsGet = true)]
    public string Freq { get; set; }
    public string Image_string { get; set; }
    public string Category_image_string { get; set; }

    public async Task OnGetAsync(string categoryId)
    {
        CategoryId = categoryId;
        if (Freq == "" || Freq == null)
        {
            Freq = "h";
        }

        Graph graph = await apiService.GetPredictedPrices(categoryId, Freq);
        CategoryName = graph.CategoryName;
        Image_string = "data:image/png;base64," + graph.GraphImage;
    }
}