using DadJokesBlazorApp.Models;

namespace DadJokesBlazorApp.Data
{
    public interface IDadJokesService
    {
        Task<int> GetJokesCount();
        Task<Joke> GetRandomJoke();

    }
}
