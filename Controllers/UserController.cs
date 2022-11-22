using Microsoft.AspNetCore.Mvc;
using QuizMarket.Models.DB;
using QuizMarket.Models.Request;

namespace QuizMarket.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]

    public class UserContoller : ControllerBase
    {
        private IConfiguration _configuration;
        private QuizWorldDbContext _dbContext;
        public UserContoller(QuizWorldDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }
        //put, post, get, delete
        //put - update
        //post - create
        //get - read (ne moje da ima parametri)
        //delete - delete

        //linq - any - returns bool
        //     - where - returns list
        //     - select - returns collection(from one type to another type)
        [HttpPost]
        public ActionResult Register(UserRegisterRequest request)
        {

            if (request.Username.Length < 6 && request.Username.Length > 30)
            {
                return BadRequest("username lenght");
            }
            if (_dbContext.Users.Any(x => x.Username == request.Username))
            {
                return BadRequest("username doblicated");
            }
            if (request.Password.Length < 7 && request.Password.Length > 20)
            {
                return BadRequest("password lenght");
            }

            User userToAdd = new User()
            {
                Username = request.Username,
                Password = request.Password,
                Email = request.Email,
            };
            _dbContext.Users.Add(userToAdd);
            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public string Login(UserLoginRequest request)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Username == request.Username && x.Password == request.Password);
            if (user == null)
            {
                return "invalid information";
            }

            return "Ok";
        }
    }
}
