using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Softech.Models.DataModels
{
    [Table("tblUserImage")]
    public class UserImageDTO
    {
        [Key]
        public int ImageId { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
    }
}