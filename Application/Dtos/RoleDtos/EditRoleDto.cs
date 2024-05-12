namespace Application.Dtos.RoleDtos
{
    public class EditRoleDto : IRoleInfoDto
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? NormalizedName { get; set; }
    }
}
