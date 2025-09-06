using ivana.data;
using ivana.Domain.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ivana.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IvanaController : ControllerBase
    {
        private readonly IvanaDbcontext dbContext;

        public IvanaController(IvanaDbcontext dbcontext)
        {
            this.dbContext = dbcontext;
        }
        [HttpPost]
        public IActionResult Saveuser(UserDto userDto)
        {
            var user = new User();
            user.Name = userDto.Name;
            user.Email = userDto.Email;
            user.Password = userDto.Password;
            dbContext.User.Add(user);
            dbContext.SaveChanges();
            return Ok(user);
        }

        [HttpGet]
        public IActionResult GetUser()
        {
            var user = dbContext.User;
            return Ok(user);
        }

        //[HttpGet]
        //public IActionResult Getuser()
        //{
        //    var user = dbContext.User.ToList();
        //    List<UserDto> list= new List<UserDto>();
        //    foreach (var item in list)
        //    {
        //        list.Add(new UserDto()
        //        {
        //            Name = item.Name,
        //            Email = item.Email,
        //            Password = item.Password,
        //        });
        //    }

        //    return Ok(user);
        //}





        [HttpGet]
        [Route("{id:int}")]

        public IActionResult GetbyId(int id)
        {
            var user = dbContext.User.FirstOrDefault(p => p.Id == id);
            return Ok(user);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateUser([FromRoute]int id, [FromBody] UserDto userDto)
        {
            var user = dbContext.User.FirstOrDefault(u => u.Id == id);
            user.Name = userDto.Name;
            user.Email = userDto.Email;
            user.Password = userDto.Password;
            dbContext.SaveChanges();
            return Ok("User done");
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteUser([FromRoute]int id)
        {
            var user = dbContext.User.FirstOrDefault(u => u.Id == id);
            dbContext.User.Remove(user);
            dbContext.SaveChanges();
            return Ok("User deleted");
        }




    }
}
    



    

