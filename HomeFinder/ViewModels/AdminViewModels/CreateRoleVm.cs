using System.ComponentModel.DataAnnotations;

namespace HomeFinder.Models
{
    public class CreateRoleVm
    {
        [Required]
        public string RoleName { get; set; }
    }
}
