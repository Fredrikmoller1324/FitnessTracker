namespace FitnessTracker.Data
{
    public static class StringEncryption
    {
        public static string Decrypt(string encryptedString)
        {
            var b = Convert.FromBase64String(encryptedString);
            var decrypted = System.Text.Encoding.ASCII.GetString(b);

            return decrypted;
        }

        public static string Encrypt(string stringToEncrypt)
        {
            byte[] b = System.Text.Encoding.ASCII.GetBytes(stringToEncrypt);
            string encrypted = Convert.ToBase64String(b);
            return encrypted;
        }
    }
}
