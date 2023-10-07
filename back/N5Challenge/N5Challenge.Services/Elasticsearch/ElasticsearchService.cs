using Elastic.Clients.Elasticsearch;

namespace N5Challenge.Services.Elasticsearch
{
    public class ElasticsearchService : IElasticsearchService
    {
        private readonly ElasticsearchClient _client;
        private readonly string _index;

        public ElasticsearchService()
        {
            var url = Environment.GetEnvironmentVariable("ELASTICSEARCH_SERVER") ?? throw new ArgumentException("ELASTICSEARCH_SERVER not found.");
            var connectionSettings = new Uri(url);

            _client = new ElasticsearchClient(connectionSettings);

            var index = Environment.GetEnvironmentVariable("ELASTICSEARCH_SERVER") ?? throw new ArgumentException("ELASTICSEARCH_INDEX not found.");
            _index = index;
        }

        public ElasticsearchClient GetClient() => _client;

        public async void IndexDocument<T>(T document, string id) where T : class
        {
            try
            {
                var indexResponse = await _client.IndexAsync(document, idx => idx
                    .Index(_index)
                    .Id(id)
                );

                if (!indexResponse.IsSuccess())
                {
                    throw new Exception($"Indexed document fail: {indexResponse.DebugInformation}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}