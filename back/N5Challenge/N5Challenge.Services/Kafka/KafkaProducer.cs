using Confluent.Kafka;
using Microsoft.Extensions.Options;

namespace N5Challenge.Services.Kafka
{
    public class KafkaProducer : IKafkaProducer
    {
        private readonly IOptions<KafkaSetting> _settings;
        public KafkaProducer(IOptions<KafkaSetting> settings)
        {
            _settings = settings;
        }

        public async Task PublishAsync(KafkaDto kafkaDto)
        {
            try
            {
                var config = new ProducerConfig
                {
                    BootstrapServers = _settings.Value.Url,
                };

                var producer = new ProducerBuilder<string, string>(config).Build();

                var topic = _settings.Value.Topic;

                var message = new Message<string, string>
                {
                    Key = kafkaDto.Key.ToString(),
                    Value = Newtonsoft.Json.JsonConvert.SerializeObject(kafkaDto),
                };

                await producer.ProduceAsync(topic, message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}