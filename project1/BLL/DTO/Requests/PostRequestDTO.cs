namespace WEBAPI.BLL.DTO.Requests
{
    public class PostRequestDTO
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public string Body { get; set; }
        public DateTime Created_at { get; set; }
    }
}
