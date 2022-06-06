using DAL_Project2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Project2.Entitys
{
    public class Entity : IBaseEntity
    {
        public int Id { get; set; }
    }
}
