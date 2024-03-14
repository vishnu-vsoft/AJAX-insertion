namespace MvcCrud.Models
{
    public class myClass
    {
        public string encryptstring(string val)
        {
            byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(val);
            string enval = Convert.ToBase64String(b);
            return enval;
        }
    }
}
