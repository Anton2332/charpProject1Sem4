using DAL.Model;
using Dapper;
using Microsoft.Data.SqlClient;
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
    public class PostRepository : GenericRepository<PostRespons>, IPostRepository
    {
        public PostRepository(IDbTransaction transaction) : base("posts", transaction)
        {
        }

        public async Task<IEnumerable<PostRespons>> GetAllByOrderIdAsync(long id)
        {
            var posts = await Connection.QueryAsync<PostRespons, user, PostRespons>(
                "select * from posts p inner join AspNetUsers u on p.userId = u.Id where p.OrderId = @ID",
                (post,user) =>
                {
                    post.user = user;
                    return post;
                },
                param:new {ID = id},
                transaction: Transaction
                );
            return posts;
        }

        public async Task<IEnumerable<PostRespons>> GetAllByOrderIdProcAsync(long id)
        {
            var posts = await Connection.QueryAsync<PostRespons, user, PostRespons>(
                sql: "GetAllByOrderIdProc",
                (post, user) =>
                {
                    post.user = user;
                    return post;
                },
                param: new { Id = id },
                commandType:CommandType.StoredProcedure,
                transaction: Transaction
                );


            return posts;
        }


        public async Task<IEnumerable<PostRespons>> GetAllByOrderIdProcAdoAsync(long id)
        {
            using (SqlConnection sql = new SqlConnection(Connection.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetAllByOrderIdProc", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("Id", id));
                    var response = new List<PostRespons>();
                    await sql.OpenAsync();
                    
                    using(var reader = await cmd.ExecuteReaderAsync())
                    {
                        while(await reader.ReadAsync())
                        {
                            response.Add(MapToValue(reader));
                        }
                    }
                    return response;
                }
            }
        }

        private PostRespons MapToValue(SqlDataReader reader)
        {
            return new PostRespons()
            {
                Id = reader.GetInt32("Id"),
                body = reader.GetString("body"),
                created_at = reader.GetDateTime("created_at"),
                OrderId = reader.GetInt32("OrderId"),
                userId = reader.GetInt32("user_id"),
            };
        }



    }

}
