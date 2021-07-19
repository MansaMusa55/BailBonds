using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BailBonds.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Member Comment")]
        public string CommentSection { get; set; }

        [DisplayName("Date")]
        public DateTimeOffset Created { get; set; }
        [DisplayName("Team Member")]
        public string UserId { get; set; }
        public int ClientId { get; set; }
        // -- Navigation properties
        public virtual BondsUser User { get; set; }
        public virtual Client Client { get; set; }
    }
}
