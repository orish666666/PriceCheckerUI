using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PriceCheckerUI.Services;
using System.Net;

public class IndexModel : PageModel
{
    private readonly ApiService apiService;
    public IndexModel(ApiService apiService)
    {
        this.apiService = apiService;
    }

    [BindProperty]
    public string CategoryId { get; set; }
    public string Message { get; set; }

    public void OnGet() { }

    public async Task<IActionResult> OnPostAsync()
    {
        if (CategoryId != null)
        {
            var resp = await apiService.PredictCategory(CategoryId);
            if (resp.StatusCode == HttpStatusCode.OK)
            {
                Message = "Category will be predicted shortly.";
            }
            else
            {
                Message = "Failed to set prediction for the provided category.";
            }
        }
        return Page();
    }
}
