using project1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class PostRespons
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string body { get; set; }
        public DateTime created_at { get; set; }
        public int userId { get; set; }
        public user user { get; set; }
        
    }
}
