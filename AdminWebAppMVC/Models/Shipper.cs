﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminWebAppMVC.Models
{
    public class Shipper
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
    }
}
