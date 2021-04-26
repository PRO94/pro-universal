using System.ComponentModel.DataAnnotations;
using Pro.Universal.Data.DataTransferObjects.Base;

namespace Pro.Universal.Data.DataTransferObjects
{
    public class RoleCreateDto : BaseDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
}