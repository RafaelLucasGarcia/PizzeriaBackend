﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PizzeriaBackend.Models
{
    public class UploadRequestViewModel
    {
        
        [Required]
        public string Name { get; set; }

        [Required]
        public List<Guid> Ingredients { get; set; }

        [Required]
        public HttpPostedFileBase Image { get; set; }
    
    }
}