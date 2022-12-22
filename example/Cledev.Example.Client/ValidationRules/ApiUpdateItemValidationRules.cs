using Cledev.Client.Services;
using Cledev.Example.Shared;

namespace Cledev.Example.Client.ValidationRules;

public class ApiUpdateItemValidationRules : IUpdateItemValidationRules
{
    private readonly ApiService _apiService;

    public ApiUpdateItemValidationRules(ApiService apiService)
    {
        _apiService = apiService;
    }

    public async Task<bool> IsItemNameUnique(Guid id, string name)
    {
        return await _apiService.GetFromJsonAsync<bool>($"api/items/is-name-unique/{name}?id={id}");
    }
}