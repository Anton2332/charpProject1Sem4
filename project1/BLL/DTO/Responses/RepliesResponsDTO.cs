namespace WEBAPI.BLL.DTO.Responses
{
    public class RepliesResponsDTO
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string Body { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public double Rating { get; set; }
    }
}
