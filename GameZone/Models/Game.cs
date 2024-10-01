using System.ComponentModel.DataAnnotations;
using System.Xml;

namespace GameZone.Models
{
    public class Game :BaseEntity
    {
        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;
        
        [MaxLength(500)]
        public string Cover { get; set; } = string.Empty;

        public Category Category { get; set; } = default;
        public int CategoryId {  get; set; }    
        
        public ICollection<GameDevice> Devices { get;set; }  =new List<GameDevice>();        

    }
}
