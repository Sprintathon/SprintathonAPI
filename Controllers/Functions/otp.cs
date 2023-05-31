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

        [HttpPost]
        public string GetNumericOTP()
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
    }
}