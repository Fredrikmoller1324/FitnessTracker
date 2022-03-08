namespace FitnessTracker.Data
{
    public static class StringEncryption
    {
        public static string Decrypt(string encrString)
        {
            var b = Convert.FromBase64String(encrString);
            var decrypted = System.Text.ASCIIEncoding.ASCII.GetString(b);

            return decrypted;
        }

        public static string Encrypt(string stringToEcncrypt)
        {
            byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(stringToEcncrypt);
            string encrypted = Convert.ToBase64String(b);
            return encrypted;
        }
    }
}
