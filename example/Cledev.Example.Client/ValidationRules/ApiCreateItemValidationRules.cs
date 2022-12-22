using Cledev.Client.Services;
using Cledev.Example.Shared;

namespace Cledev.Example.Client.ValidationRules;

public class ApiCreateItemValidationRules : ICreateItemValidationRules
{
    private readonly ApiService _apiService;

    public ApiCreateItemValidationRules(ApiService apiService)
    {
        _apiService = apiService;
    }

    public async Task<bool> IsItemNameUnique(string name)
    {
        return await _apiService.GetFromJsonAsync<bool>($"api/items/is-name-unique/{name}");
    }
}