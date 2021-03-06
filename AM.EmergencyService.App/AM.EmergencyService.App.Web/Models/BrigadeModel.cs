﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AM.EmergencyService.App.Web.Models
{
    public class BrigadeModel : IModel
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Номер расчета")]
        public int BrigadeNumber { get; set; }
    }
}
