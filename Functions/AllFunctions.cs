namespace SprintathonAPI.Functions
{
    public class AllFunctions
    {

        //Generating random 4 digit number for OTP

        public static string GetNumericOTP()
        {
            string numbers = "0123456789";
            Random rndm = new Random();
            string otp = string.Empty;
            for (int i = 0; i < 4; i++)
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
