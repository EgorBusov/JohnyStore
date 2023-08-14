using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnyStoreData.Models
{
    /// <summary>
    /// Наличие
    /// </summary>
    public class Availability
    {
        public int Id { get; set; }
        [ForeignKey("ModelId")]
        public virtual Sneaker Model { get; set; }
        [ForeignKey("Status35Id")]
        public virtual AvailabilityStatus Status35 { get; set; }
        [ForeignKey("Status36Id")]
        public virtual AvailabilityStatus Status36 { get; set; }
        [ForeignKey("Status37Id")]
        public virtual AvailabilityStatus Status37 { get; set; }
        [ForeignKey("Status38Id")]
        public virtual AvailabilityStatus Status38 { get; set; }
        [ForeignKey("Status39Id")]
        public virtual AvailabilityStatus Status39 { get; set; }
        [ForeignKey("Status40Id")]
        public virtual AvailabilityStatus Status40 { get; set; }
        [ForeignKey("Status41Id")]
        public virtual AvailabilityStatus Status41 { get; set; }
        [ForeignKey("Status42Id")]
        public virtual AvailabilityStatus Status42 { get; set; }
        [ForeignKey("Status43Id")]
        public virtual AvailabilityStatus Status43 { get; set; }
        [ForeignKey("Status44Id")]
        public virtual AvailabilityStatus Status44 { get; set; }
        [ForeignKey("Status45Id")]
        public virtual AvailabilityStatus Status45 { get; set; }
        [ForeignKey("Status46Id")]
        public virtual AvailabilityStatus Status46 { get; set; }
        public bool Visible { get; set; }
    }
}
