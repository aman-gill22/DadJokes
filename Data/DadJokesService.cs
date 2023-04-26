using DadJokesBlazorApp.Models;
using RestSharp;

namespace DadJokesBlazorApp.Data
{
    public class DadJokesService:IDadJokesService
    {
        private readonly IConfiguration configuration;
        private readonly RapidAPISettings rapidAPISettings;
        private readonly RestClient client;

        public DadJokesService(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.rapidAPISettings = configuration.GetSection("RapidAPISettings").Get<RapidAPISettings>();
            this.client = new RestClient(rapidAPISettings.BaseUrl);
        }

        public async Task<Joke> GetRandomJoke()
        {
            try
            {
                var request = new RestRequest("/random/joke", Method.Get);
                request.AddHeader("content-type", "application/octet-stream");
                request.AddHeader("X-RapidAPI-Key", rapidAPISettings.APIKey);
                request.AddHeader("X-RapidAPI-Host", rapidAPISettings.APIHost);
                var response = await client.ExecuteAsync<JokeResponse>(request);

                if (response.IsSuccessful && response.Data.success)
                {
                    return response.Data.body.FirstOrDefault();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }

        public async Task<int> GetJokesCount()
        {
            try
            {
                var request = new RestRequest("/joke/count", Method.Get);
                request.AddHeader("content-type", "application/octet-stream");
                request.AddHeader("X-RapidAPI-Key", rapidAPISettings.APIKey);
                request.AddHeader("X-RapidAPI-Host", rapidAPISettings.APIHost);
                var response = await client.ExecuteAsync<JokeCountResponse>(request);

                if (response.IsSuccessful && response.Data.success)
                {
                    return response.Data.body;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
