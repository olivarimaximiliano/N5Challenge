namespace N5Challenge.Services.Kafka
{
    public class KafkaDto
    {
        public KafkaDto(Guid key, string operationName)
        {
            Key = key;
            OperationName = operationName;
        }
        public Guid Key { get; set; }
        public string OperationName { get; set; }
    }
}