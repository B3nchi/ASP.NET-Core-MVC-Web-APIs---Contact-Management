using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ContactManage.API.DTOs
{
    public class ContactDto
    {
        public Guid Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required, MaxLength(100), Column(TypeName = "NVARCHAR(100)")]
        public string Email { get; set; } = string.Empty;

        [Required, MaxLength(50), Column(TypeName = "NVARCHAR(50)")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required, MaxLength(100), Column(TypeName = "NVARCHAR(100)")]
        public string Address { get; set; } = string.Empty;
    }
}
