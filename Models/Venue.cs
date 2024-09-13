using System.ComponentModel.DataAnnotations;

namespace APPR612_Activity2.Models
{
    public class Venue
    {
        [Key]
        public int VenueID { get;set; }
        public string Name {  get; set; }
        public string Address { get; set; }
    }
}
