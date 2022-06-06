using DAL.Model;
using Dapper;
using project1.Model;
using project1.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1.Repositories
{
    public class RepliesRepository : GenericRepository<RepliesRespons>, IRepliesRepository
    {
        public RepliesRepository( IDbTransaction transaction) : base("replies", transaction)
        {
        }

        public async Task<IEnumerable<RepliesRespons>> GetAllByPostIdAsync(long id)
        {
            var replies = await Connection.QueryAsync<RepliesRespons, user, RepliesRespons>(
                "select * from replies r inner join AspNetUsers u on r.userId = u.Id where r.postId = @ID",
                (replies, user) =>
                {
                    replies.user = user;
                    return replies;
                },
                param: new { ID = id },
                transaction: Transaction
                );

            return replies;
        }


    }
}
