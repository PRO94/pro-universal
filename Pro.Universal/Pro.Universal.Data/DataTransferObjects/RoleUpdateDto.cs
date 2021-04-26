using Pro.Universal.Data.DataTransferObjects.Base;

namespace Pro.Universal.Data.DataTransferObjects
{
    public class RoleUpdateDto : BaseDto
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}