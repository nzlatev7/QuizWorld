using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using QuizMarket.Models.DB;
using QuizMarket.Models.Request;
using QuizMarket.Models.Response;
using QuizWorld.Models.Request;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
              {
                  new Claim(ClaimTypes.Name, user.Id.ToString())
              }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"]
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        [HttpDelete]
        public ActionResult Delete(UserDeleteRequest request)
        {
            var userForDlete = _dbContext.Users.Find(request.Id);
            if (userForDlete == null)
            {
                return BadRequest("nqam takowa id");
            }
            _dbContext.Users.Remove(userForDlete);
            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public List<UserGetAllResponce> GetAll()
        {
            return _dbContext.Users.Select(x => new UserGetAllResponce()
            {
                Id = x.Id,
                Username = x.Username,
                Email = x.Email,
            }).ToList();
        }

        [HttpPut]
        public ActionResult Update(UserUpdateRequest request)
        {
            var userForUpdate = _dbContext.Users.Any(x => x.Id == request.Id);
            if (userForUpdate == null)
            {
                return BadRequest("can not find");
            }
            else
            {
                var user = _dbContext.Users.Find(request.Id);
                if (request.Username != "string")
                {
                    user.Username = request.Username;
                }
                if (request.Email != "string")
                {
                    user.Email = request.Email;
                }
                if (request.Password != "string")
                {
                    user.Password = request.Password;
                }
                _dbContext.SaveChanges();
                return Ok();
            }
        }

    }
}