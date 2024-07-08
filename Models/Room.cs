using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebDbApp.Models
{
    public class Room
    {
        public enum RoomType
        {
            Regular,
            Relaxation,
            Kitchen,
            Assembly,
            Ballroom,
            Laboratory
        }
        public int Id { get; set; }
        
        public string Name { get; set; }

        public RoomType Type { get; set; } = RoomType.Regular;
    
        public ICollection<Workspace> Workspaces { get; set; }
    }
}