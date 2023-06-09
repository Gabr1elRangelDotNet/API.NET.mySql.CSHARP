using Microsoft.AspNetCore.Mvc;
using mysqlAPI.Model;
using mysqlAPI.Repository;

namespace mySqlAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{    

    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet()]
    public IActionResult GetAll()
    {
        var users = _userRepository.GetAll();
        
        if(users.Count() == 0){
            return NoContent();
        }
        
        return Ok(users);
    }

    [HttpPost()]
    public IActionResult Post(User newUser)
    {
        var response = _userRepository.InsertUser(newUser);
    
        return Ok(response);
    }
    
    [HttpDelete()]
    public IActionResult Delete(int i_cliente_cliente)
    {
        var response = _userRepository.DeleteUser(i_cliente_cliente);
    
        return Ok(response);
    }
    
    [HttpGet("{i_cliente_cliente}")]

    public IActionResult GetName(int i_cliente_cliente)
    {
        var response = _userRepository. GetName(i_cliente_cliente);
    
        return Ok(response);
    }
    
}
