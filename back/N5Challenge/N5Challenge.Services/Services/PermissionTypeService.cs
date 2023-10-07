using N5Challenge.DataAccess.Interfaces;
using N5Challenge.Domain.Models;
using N5Challenge.Services.Interfaces;
using N5Challenge.Services.Kafka;

namespace N5Challenge.Services.Services
{
    public class PermissionTypeService : IPermissionTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IKafkaProducer _kafka;

        public PermissionTypeService(IUnitOfWork unitOfWork, IKafkaProducer kafka)
        {
            _unitOfWork = unitOfWork;
            _kafka = kafka;
        }

        public async Task<IEnumerable<PermissionType>> Get()
        {
            await _kafka.PublishAsync(new KafkaDto(Guid.NewGuid(), "get"));
            return await _unitOfWork.PermissionTypeRepository.GetAllAsync();
        }

        public async Task<PermissionType> Get(int id)
        {
            await _kafka.PublishAsync(new KafkaDto(Guid.NewGuid(), "get"));
            return await _unitOfWork.PermissionTypeRepository.GetAsync(p => p.Id == id);
        }
    }
}