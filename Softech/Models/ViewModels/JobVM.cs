using Softech.Models.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Softech.Models.ViewModels
{
    public class JobVM
    {
        public JobVM()
        {

        }
        public JobVM(JobDTO row)
        {
            PersonId = row.PersonId;
            ClientName = row.ClientName;
            Address = row.Address;
            DeployDate = row.DeployDate;
            SoftwareName = row.SoftwareName;
            Description = row.Description;
            Other = row.Other;
            
        }
        public int PersonId { get; set; }
        [Required]
        public string ClientName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public DateTime DeployDate { get; set; }
        [Required]
        public string SoftwareName { get; set; }
        [Required]
        public string Description { get; set; }
        public string Other { get; set; }

    }
}