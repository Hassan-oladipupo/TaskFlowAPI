using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;
using System.Threading.Tasks;
using TaskFlow_API.Repository.IRepository;
using TaskFlowAPI.Model;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TaskFlow_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public TaskController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
       
        [HttpGet]
        public IActionResult GetTasks()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            IEnumerable<MyTask> userTasks = _unitOfWork.MyTask.GetAll()
                .Where(task => task.CreatorId == userId);

            return Ok(userTasks);

            
        }
       
        [HttpGet("{id}")]
        public IActionResult GetTaskById(int id)
        {
            MyTask task = _unitOfWork.MyTask.GetFirstOrDefault(u => u.Id == id);


            if (task == null)
            {
                return NotFound(); 
            }

            return Ok(task); 
        }

        
        [HttpPost]
        public IActionResult CreateTask(MyTask task)
        {
            
                if (task == null)
            {
                return BadRequest("Task data is invalid.");
            }
           

           var   CreatorId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            _unitOfWork.MyTask.Add(task);
            _unitOfWork.Save();

            return CreatedAtAction(nameof(GetTasks), new { id = task.Id }, task);
        }

       
        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, MyTask updatedTask)
        {
            if (updatedTask == null)
            {
                return BadRequest("Task data is invalid.");
            }

            MyTask task = _unitOfWork.MyTask.GetFirstOrDefault(u => u.Id == id);
            if (task == null)
            {
                return NotFound(); 
            }

            // Update properties of the existing task with the properties of the updated task
            task.Title = updatedTask.Title;
            task.Description = updatedTask.Description;
            task.DueDate = updatedTask.DueDate;
            task.CompletionStatus = updatedTask.CompletionStatus;   

            _unitOfWork.MyTask.Update(task);
            _unitOfWork.Save();

            return Ok(task); 
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            MyTask task = _unitOfWork.MyTask.GetFirstOrDefault(u => u.Id == id);

            if (task == null)
            {
                return NotFound(); 
            }

            _unitOfWork.MyTask.Remove(task);
            _unitOfWork.Save();

            return NoContent(); 
        }

        [HttpPost("assign")]
        public IActionResult AssignTask(MyTask task)
        {
            if (task == null)
            {
                return BadRequest("Task data is invalid.");
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            task.CreatorId = userId; 

            _unitOfWork.MyTask.Add(task);
            _unitOfWork.Save();

            return CreatedAtAction(nameof(GetTaskById), new { id = task.Id }, task);
        }




    }
}
