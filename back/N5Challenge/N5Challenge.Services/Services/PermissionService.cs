using N5Challenge.DataAccess.Interfaces;
using N5Challenge.Domain.Models;
using N5Challenge.Services.Elasticsearch;
using N5Challenge.Services.Interfaces;
using N5Challenge.Services.Kafka;

namespace N5Challenge.Services.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IKafkaProducer _kafka;
        private readonly IElasticsearchService _elasticsearchService;

        public PermissionService(IUnitOfWork unitOfWork, IKafkaProducer kafka, IElasticsearchService elasticsearchService)
        {
            _unitOfWork = unitOfWork;
            _kafka = kafka;
            _elasticsearchService = elasticsearchService;
        }

        public async Task<Permission> AddAsync(Permission permission)
        {
            await _unitOfWork.PermissionRepository.AddAsync(permission);
            await _unitOfWork.SaveAsync();
            return permission;
        }

        public async Task<IEnumerable<Permission>> Get()
        {
            await _kafka.PublishAsync(new KafkaDto(Guid.NewGuid(), "get"));
            return await _unitOfWork.PermissionRepository.GetAllAsync();
        }

        public async Task<Permission> Get(int id)
        {
            await _kafka.PublishAsync(new KafkaDto(Guid.NewGuid(), "getall"));
            return await _unitOfWork.PermissionRepository.GetAsync(p => p.Id == id);
        }

        public async Task<Permission> Update(Permission permission)
        {
            _unitOfWork.PermissionRepository.Update(permission);
            await _kafka.PublishAsync(new KafkaDto(Guid.NewGuid(), "modify"));
            _elasticsearchService.IndexDocument(permission, permission.Id.ToString());
            await _unitOfWork.SaveAsync();
            return permission;
        }
    }
}