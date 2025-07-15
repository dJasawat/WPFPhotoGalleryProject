using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFPhotoGalleryProject.Models
{
    public class Photo
    {
        [Key] public int Id { get; set; }
        public string FilePath { get; set; }
        public string Tag { get; set; }

        public DateTime AddedOn { get; set; }
    }
}
