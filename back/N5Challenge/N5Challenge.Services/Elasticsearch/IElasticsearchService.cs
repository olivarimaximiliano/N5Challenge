using Elastic.Clients.Elasticsearch;

namespace N5Challenge.Services.Elasticsearch
{
    public interface IElasticsearchService
    {
        public ElasticsearchClient GetClient();

        public void IndexDocument<T>(T document, string id) where T : class;
    }
}