using System.ComponentModel.DataAnnotations;

namespace TaskFlowAPI.Model
{
    public class Login
    {
        [Key]
        public int Id { get; set; }

        public string UserName { get; set; }



        [Required]
        public string Password { get; set; }

    }
}
