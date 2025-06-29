namespace Api.Clinic;
using System.Net.Http.Json;

public class FirebaseService
{
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "https://apiclinic-265cf-default-rtdb.firebaseio.com/";

    public FirebaseService()
    {
        _httpClient = new HttpClient();
    }

    // Add data to Firebase
    public async Task AddDataAsync<T>(string path, T data)
    {
        var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}{path}.json", data);
        response.EnsureSuccessStatusCode();
    }

    // Get data from Firebase
    public async Task<T> GetDataAsync<T>(string path)
    {
        var response = await _httpClient.GetFromJsonAsync<T>($"{BaseUrl}{path}.json");
        return response!;
    }

    // Update data in Firebase
    public async Task UpdateDataAsync<T>(string path, T data)
    {
        var response = await _httpClient.PatchAsJsonAsync($"{BaseUrl}{path}.json", data);
        response.EnsureSuccessStatusCode();
    }

    // Delete data from Firebase
    public async Task DeleteDataAsync(string path)
    {
        var response = await _httpClient.DeleteAsync($"{BaseUrl}{path}.json");
        response.EnsureSuccessStatusCode();
    }
}
