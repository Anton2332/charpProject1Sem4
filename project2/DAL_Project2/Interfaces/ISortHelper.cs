using DAL_Project2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Project2.Interfaces
{
    public interface ISortHelper<TEntity> where TEntity : class
    {
        IQueryable<TEntity> ApplySort(IQueryable<TEntity> entities, QueryStringParameters queryString);
    }
}
