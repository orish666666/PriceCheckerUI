using PriceCheckerUI.Models;

namespace PriceCheckerUI.Services
{
    public class ApiService
    {
        private readonly HttpClient HttpClient;
        public ApiService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<HttpResponseMessage> PredictCategory(string categoryId)
        {
            var response = await HttpClient.GetAsync("/category-to-predict?categoryId="+categoryId);
            return response;
        }

        public async Task<List<CategoryInfo>> GetPredictedCategories()
        {
            var response = await HttpClient.GetFromJsonAsync<List<CategoryInfo>>("/get-predict-categories");
            return response;
        }

        public async Task<Graph> GetPredictedPrices(string categoryId, string freq)
        {
            var response = await HttpClient.GetFromJsonAsync<Graph>("/get-prediction-graph?categoryId=" + categoryId + "&freq=" + freq);
            return response;
        }
    }
}
