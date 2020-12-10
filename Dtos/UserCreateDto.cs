using System.ComponentModel.DataAnnotations;

namespace UserService.Dtos
{
    public class UserCreateDto
    {
        [Required]
        [MaxLength(250)]
        public string FullName{ get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email{ get; set;}

        
        [DataType(DataType.PhoneNumber)]
        public string Phone{ get; set;} = default!;

        public int Age{ get; set;} = 0;
    }
}