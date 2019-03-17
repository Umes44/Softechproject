using Softech.Models.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Softech.Models.ViewModels
{
    public class UserImageVM
    {
        public UserImageVM()
        {

        }
        public UserImageVM(UserImageDTO row)
        {
            ImageId = row.ImageId;
            ImagePath = row.ImagePath;
            Title = row.Title;
          
        }
        public int ImageId { get; set; }
        public string Title { get; set; }
        [DisplayName("Upload Image")]
        public string ImagePath { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
    }
}