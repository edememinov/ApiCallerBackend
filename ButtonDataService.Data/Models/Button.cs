using System.ComponentModel.DataAnnotations;

namespace ButtonDataService.Data.Models
{
    public class Button
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public string Colour { get; set; }
        public byte[] Image { get; set; }
        public int Row { get; set; }
        public int Order { get; set; }
        public string Category { get; set; } 
        public Canvas Canvas { get; set; }
        public HTTPMethod HttpMethod { get; set; }
        public string RequestParameters { get; set; }
        public string RequestBody { get; set; }
        public string RequestUrl { get; set; }
        public string ButtonStyle { get; set; }
        public string ContentType { get; set; }
    }

    public enum HTTPMethod
    {
        GET,
        POST,
        DELETE,
        PUT
    }
}
