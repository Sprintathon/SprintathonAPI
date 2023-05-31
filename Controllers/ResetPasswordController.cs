namespace SprintathonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class ResetPasswordController : Controller
    {
        private readonly ApplicationDbContext _dataContext;
        public ResetPasswordController(ApplicationDbContext dataContext)
        {
               _dataContext = dataContext;
        }
        //Email Verification
        [HttpGet]
     public string Task<ActionResult<User>> GetUser(user Email)
        {
            var result = _dataContext.Users.FirstOrDefaultAsync(user =>user .Id == id);
            //check
            if(user==null){
                return NotFound("User not found");
            }
            else{
                return SendOTP();
            }
            return result;
        }

        //
        //Generating random 4 digit number for OTP
            public ActionResult GetNumericOTP()
        {
            string numbers = "0123456789";
            Random rndm = new Random();
            string otp = string.Empty;
            for (int i=0; i < 4; i++ )
            {
                int tempval = rndm.Next(0, numbers.Length);
                otp += tempval;
            }
            return otp;
        } 
        //Sending Email with OTP
        //Done


    }
}