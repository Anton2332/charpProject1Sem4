using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1.Model
{
    public class posts
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string? body { get; set; }
        public DateTime created_at { get; set; }
        public int userId { get; set; }
    }
}
