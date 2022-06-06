namespace WEBAPI.BLL.DTO.Responses
{
    public class PostResponsDTO
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string Body { get; set; }
        public DateTime Created_at { get; set; }
        public string Name { get; set; }
        public double Rating { get; set; }
    }
}
