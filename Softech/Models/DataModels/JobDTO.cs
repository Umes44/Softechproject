using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Softech.Models.DataModels
{
    [Table("tbljob")]
    public class JobDTO
    {
        [Key]
        public int PersonId { get; set; }
        public string ClientName { get; set; }
        public string Address { get; set; }
        public DateTime DeployDate { get; set; }
        public string SoftwareName { get; set; }
        public string Description { get; set; }
        public string Other { get; set; }
    }
}