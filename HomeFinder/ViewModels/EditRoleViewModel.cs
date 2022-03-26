using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HomeFinder.Models
{
    public class EditRoleViewModel
    {

        public string Id { get; set; }

        [Required(ErrorMessage ="Detta fält kan inte vara tomt")]
        public string RoleName { get; set; }

        public List<string> Users { get; set; }

        public EditRoleViewModel()
        {
            Users = new List<string>();
        }
    }
}
