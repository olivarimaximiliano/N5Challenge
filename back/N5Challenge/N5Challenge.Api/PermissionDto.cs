namespace N5Challenge.Api
{
    public class PermissionDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public DateTime PermissionDate { get; set; }
        public int PermissionTypeId { get; set; }
    }
}