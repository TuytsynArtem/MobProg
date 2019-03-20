using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using Test.Config;
using Test.DTO;

namespace Test.Services
{
    public class ApiClient
    {
        private static HttpClient httpClient = new HttpClient();

        public Task<NoteItem[]> GetAllNotesAsync()
        {
            return RequestAsync<NoteItem[]>($"{Constans.BackEndUrl}/api/notes/getNotes");
        }

        private async Task<T> RequestAsync<T>(string url)
        {
            var response = await httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content);
        }
        private async Task<T> DeleteAsync<T>(string url)
        {
            var response = await httpClient.DeleteAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}
