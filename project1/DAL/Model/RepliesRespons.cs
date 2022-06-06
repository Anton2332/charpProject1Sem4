using project1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class RepliesRespons
    {
        public int Id { get; set; }
        public int postId { get; set; }
        public int userId { get; set; }
        public string body { get; set; }
        public DateTime createdAt { get; set; }
        public user user { get; set; }
    }
}
