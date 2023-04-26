namespace DadJokesBlazorApp.Models
{
    public class Joke
    {
        public string _id { get; set; }
        public string punchline { get; set; }
        public string setup { get; set; }
        public string type { get; set; }
    }

    public class JokeResponse
    {
        public List<Joke> body { get; set; }
        public bool success { get; set; }
    }

    public class JokeCountResponse
    {
        public int body { get; set; }
        public bool success { get; set; }
    }
}
