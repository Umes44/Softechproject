using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Softech.Models.DataModels
{
    [Table("tblUserRoles")]
    public class UserRolesDTO
    {
        [Key,Column(Order =0)]
        public int UserId { get; set; }
        [Key, Column(Order = 1)]
        public int RolesId { get; set; }
        [ForeignKey("UserId")]
        public virtual  AccountDTO Account{ get; set; }
        [ForeignKey("RolesId")]
        public virtual RolesDTO Role { get; set; }
    }
}