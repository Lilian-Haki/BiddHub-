//Update the Controller to Send OTP. In your controller, you’ll need to modify the SendEmail method to call the new SendOtpEmailAsync method:
using BiddHub.DTO;
using BiddHub.Models.Authentication.Register;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
//using NETCore.MailKit.Core;
//using System.Dynamic;
using User.Management.Service.Models;
using User.Management.Service.Services;
using BiddHub.Uploads;
using BiddHub.Models.Listings;


namespace BiddHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly UserManager<RegisterUser> _userManager;
        private readonly SignInManager<RegisterUser> _signInManager;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;
        private static List<Products> products = new List<Products>();

        public EmailController(IEmailService emailService, UserManager<RegisterUser> userManager, SignInManager<RegisterUser> signInManager, IConfiguration configuration)//initialized and injected via constructor:
        {
            _emailService = emailService;
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [HttpPost("filesupload")] //api/main/uploadFile
        public IActionResult UploadFile(IFormFile file) {
            return Ok(new UploadHandler().Upload(file));
        }


        // GET: api/products
        //[HttpGet]
        //public ActionResult<IEnumerable<Products>> GetProducts()
        //{
        //    return Ok(products);
        //}

        // GET: api/products/{id}
        //[HttpGet("{id}")]
        //public ActionResult<Products> GetProduct(int id)
        //{
        //    var product = products.FirstOrDefault(p => p.Id == id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(product);
        //}

        // POST: api/products
        [HttpPost("Add-Products")]
        public ActionResult<Products> AddProduct([FromBody] Products product)
        {
            product.Id = products.Count + 1; // Simple Id generation
            products.Add(product);
            return CreatedAtAction(/*nameof(GetProduct),*/ new { id = product.Id }, product);
        }

        private ActionResult<Products> CreatedAtAction(object value, Products product)
        {
            throw new NotImplementedException();
        }


        //[HttpPost("send-otp")]
        //public async Task<IActionResult> SendOtp([FromBody] EmailData emailData)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest("Invalid email data");
        //    }

        //    await _emailService.SendOtpEmailAsync(emailData);// Calling the method
        //    return Ok("OTP sent successfully!");
        //}

        // Registration Endpoint
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO model)
        {
            if (model.Password != model.ConfirmPassword)
            {
                return BadRequest("Passwords do not match.");
            }
            if (ModelState.IsValid)
            {
                var user = new RegisterUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    // Generate OTP for the registered user
                    string otp = GenerateOtp(); // OTP generation logic
                    await _emailService.SendOtpEmailAsync(new EmailData
                    {
                        To = user.Email,
                        Subject = "Your OTP Code",
                        Body = $"Welcome to our platform! Your OTP code is: {otp}"
                    });
                    return Ok(new { Message = "User registered successfully! OTP has been sent to your email." });
                }

                return BadRequest(result.Errors);
            }
            return BadRequest(ModelState);
        }
        private string GenerateOtp()
            {
                // Simple OTP generation logic (e.g., 6 digits)
                var random = new Random();
                return random.Next(100000, 999999).ToString();
            }
        
        // Login Endpoint
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var token = GenerateJwtToken(user);
                return Ok(new { token });
            }

            return Unauthorized("Invalid credentials.");
        }
        private string GenerateJwtToken(RegisterUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Issuer"]
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
