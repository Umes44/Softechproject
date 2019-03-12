using Softech.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Softech.Models.ViewModels
{
    public class RolesVM
    {
        public RolesVM()
        {

        }
        public RolesVM(RolesDTO row)
        {
            Id = row.Id;
            Name = row.Name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}