namespace N5Challenge.Services.Kafka
{
    public interface IKafkaProducer
    {
        public Task PublishAsync(KafkaDto kafkaDto);
    }
}