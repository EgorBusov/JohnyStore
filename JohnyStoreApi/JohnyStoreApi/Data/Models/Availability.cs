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
        public int IdModel { get; set; }
        public int Status35 { get; set; }
        public int Status36 { get; set; }
        public int Status37 { get; set; }
        public int Status38 { get; set; }
        public int Status39 { get; set; }
        public int Status40 { get; set; }
        public int Status41 { get; set; }
        public int Status42 { get; set; }
        public int Status43 { get; set; }
        public int Status44 { get; set; }
        public int Status45 { get; set; }
        public int Status46 { get; set; }
        public bool Visible { get; set; }
    }
}
