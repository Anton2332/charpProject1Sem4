namespace WEBAPI.BLL.DTO.Requests
{
    public class RepliesRequestDTO
    {
        public int Id { get; set; }
        public int postId { get; set; }
        public int userId { get; set; }
        public string body { get; set; }
        public DateTime createdAt { get; set; }
    }
}
