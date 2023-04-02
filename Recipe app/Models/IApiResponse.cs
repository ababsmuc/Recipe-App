using System.Text.Json;
using System.Threading.Tasks;

namespace Recipe_app.Models;

public interface IApiResponse
{

    public Task<JsonDocument> GetRecipe(string uri);
    
}
