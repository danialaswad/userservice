using System.ComponentModel.DataAnnotations;

namespace UserService.Dtos
{
    public class UserReadDto
    {
        public int Id{ get; set; }
        
        public string FullName{ get; set; }

        public string Email{ get; set;}

        public string Phone{ get; set;}

        public int Age{ get; set;}
    }
}