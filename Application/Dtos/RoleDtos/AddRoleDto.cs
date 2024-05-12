namespace Application.Dtos.RoleDtos
{
    public class AddRoleDto : IRoleInfoDto
    {
        public string? Name { get; set; }
        public string? NormalizedName { get; set; }
    }
}
