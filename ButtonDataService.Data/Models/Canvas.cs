using System.ComponentModel.DataAnnotations;

namespace ButtonDataService.Data.Models
{
    public class Canvas
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public int MaxRows { get; set; }
        public int MaxColumns { get; set; }
        public string Category { get; set; }
    }
}
