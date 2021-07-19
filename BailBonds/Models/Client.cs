using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BailBonds.Models
{
    public class Client 
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("First Name")]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        [StringLength(50)]
        public string LastName { get; set; }
        [NotMapped]
        [DisplayName("Full Name")]
        public string FullName { get { return $"{FirstName} {LastName}"; } }
        [DataType(DataType.Date)]
        [DisplayName("Start Date")]
        public DateTimeOffset StartDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Start Date")]
        public DateTimeOffset EndDate { get; set; }
        [NotMapped]
        [DataType(DataType.Upload)]
        public IFormFile AvatarFormFile { get; set; }
        public string AvatarFileName { get; set; }
        public byte[] AvatarFileData { get; set; }
        [DisplayName("File Extension")]
        public string AvatarContentType { get; set; }



        //Navigation
        public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();

    }
}
