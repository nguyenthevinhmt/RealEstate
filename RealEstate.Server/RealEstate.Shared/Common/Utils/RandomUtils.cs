namespace RealEstate.Shared.Common.Utils
{
    public static class RandomUtils
    {
        public static string GenerateOTP()
        {
            Random random = new Random();
            int otpNumber = random.Next(100000, 1000000); // Sinh số nguyên ngẫu nhiên từ 100000 đến 999999
            return otpNumber.ToString();
        }
    }
}
