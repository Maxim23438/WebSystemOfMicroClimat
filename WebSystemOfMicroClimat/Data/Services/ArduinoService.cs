namespace WebSystemOfMicroClimat.Data.Services
{
    public class ArduinoService
    {
        private readonly AppDbContext _context;
        public ArduinoService(string url,int interval,AppDbContext Context) 
        {
            _url = url;
            _interval = interval;
            _httpClient = new HttpClient();
            _context = Context;
        }
        private string _url;
        private int _interval; 
        private HttpClient _httpClient;
        private async Task Iteration()
        {
            while (true)
            {
                var r = await _httpClient.GetAsync(_url);
                Console.WriteLine(await r.Content.ReadAsStringAsync());
                Thread.Sleep(_interval);
            }
        }
        public void Start()
        {
            Task.Run(Iteration);
        }
    }
}
