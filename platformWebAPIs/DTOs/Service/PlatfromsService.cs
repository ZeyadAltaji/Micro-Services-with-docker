using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Service
{
    public class PlatfromsService
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Publisher { get; set; } = string.Empty;
        [Required]
        public string Cost { get; set; } = string.Empty;
    }
}
