using System.ComponentModel.DataAnnotations;

namespace TaskFlowAPI.Model
{
    public class Registration
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }


        [Required]
        public string Password { get; set; }

        [Required]
        public string RepeatPassword { get; set; }

        public int IsActive { get; set; }
    }
}
