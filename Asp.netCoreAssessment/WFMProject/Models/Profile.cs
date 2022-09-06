﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WFMProject.Models
{
    public class Profile
    {
        [Key]
        public int ProfileId { get; set; }
        public string Name { get; set; }
    }
}
