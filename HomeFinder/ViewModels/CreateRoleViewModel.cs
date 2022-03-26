using System.ComponentModel.DataAnnotations;

namespace HomeFinder.Models
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
