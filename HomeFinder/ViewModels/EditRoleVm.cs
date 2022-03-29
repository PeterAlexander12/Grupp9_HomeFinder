using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HomeFinder.Models
{
    public class EditRoleVm
    {

        public string Id { get; set; }

        [Required(ErrorMessage ="Detta fält kan inte vara tomt")]
        public string RoleName { get; set; }

        public List<string> Users { get; set; }

        public EditRoleVm()
        {
            Users = new List<string>();
        }
    }
}
