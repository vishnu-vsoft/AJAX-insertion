using System.ComponentModel.DataAnnotations;

namespace MvcCrud.Models
{
    public class UserMaster
    {
        [Key]
        //public int ID { get; set; }
        public string FULLNAME { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
    }
}
