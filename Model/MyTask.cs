using System.ComponentModel.DataAnnotations;

namespace TaskFlowAPI.Model
{
    public class MyTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool CompletionStatus { get; set; }

        public string CreatorId { get; set; }
    }
}
