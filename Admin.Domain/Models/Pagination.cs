using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Domain.Models
{
    public class Pagination
    {
        public int page { get; set; } = 0;
        public int size { get; set; } = 15;
        public bool asc { get; set; }
    }
}