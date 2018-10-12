
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asela.Samples.Wpf.Entities.Entities
{
    public class BaseEntity
    {
        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }

        public string Remarks { get; set; }
    }
}
