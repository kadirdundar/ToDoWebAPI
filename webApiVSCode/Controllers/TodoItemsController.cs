
using ContactsAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace ContactsAPI.Controllers
{
 [Route("api/[controller]/[action]")]
 [ApiController]
 public class TodoItemsController : ControllerBase 
 {

  // Dependency Injection
  
private readonly TodoContext _context;
  // Bir readonly'nin değerini iki yerde verebilirsiniz ilki constructor, diğeri tanımlandığı yerdir.
  // Ayrıca readonly ifadeler bir kez set edilebilir

  public TodoItemsController(TodoContext dbContext) // Constructor
  {
   _context = dbContext; 
  }
  [HttpPost]
public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem todoItem)
{
    _context.TodoItems.Add(todoItem);
    await _context.SaveChangesAsync();

    //    return CreatedAtAction("PostTodoItem", new { id = todoItem.Id }, todoItem);
    return CreatedAtAction(nameof(PostTodoItem), new { id = todoItem.Id }, todoItem);
}
 
  
 }
}