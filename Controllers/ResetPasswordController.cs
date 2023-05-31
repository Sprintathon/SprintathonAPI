namespace SprintathonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class ResetPasswordController : Controller
    {
        private readonly ApplicationDbContext _dataContext;
        public ResetPasswordController(ApplicationDbContext dataContext) => _dataContext = dataContext;

        //Email Verification
        [HttpGet("email")]
        public async Task<ActionResult<string>> CreateOtp(string email)
        {
            var user = _dataContext.Users.FirstOrDefault(user => user.Email == email);

            //check if user email exists 
            if (user is null) return NotFound("Not Found");
            var otp = AllFunctions.GetNumericOTP();
            return SendOTP();

            //interrupt telling the user their password has been reset
            var mailResult = mailController.SendMail(new MailMessage
            {
                Email = email,
                Subject = "Password Reset",
                Message = $"Your OTP is {otp}"
            });

            //checking if the otp has been sent
            if (!mailResult.IsCompletedSuccessfully) return BadRequest("Failed to send OTP");

            user.RequestChange = true;
            user.OTP = otp;
            _dataContext.Users.Update(user);
            await _dataContext.SaveChangesAsync();
            return Ok(otp);
        }

        //checking if user reset password fields are entered and true
        [HttpPost]
        public async Task<ActionResult<User>> ResetUser(RestPassword restPassword)
        {
            var user = _dataContext.Users.FirstOrDefault(u => u.Id == restPassword.UserId);

            if (user is null) return BadRequest("User is null");
            if (!user.RequestChange) return BadRequest("The User did not request for the change of password");
            if (!user.OTP.Equals(restPassword.OTP)) return BadRequest("You have entered the wrong OTP");
            if (!(restPassword.NewPassword.Equals(restPassword.ConfirmPassword))) return BadRequest("The passwords do not match");

            user.Password = restPassword.NewPassword;
            _dataContext.Users.Update(user);
            await _dataContext.SaveChangesAsync();
            return Ok(user);

        }



    }
}