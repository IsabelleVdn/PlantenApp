﻿using System;
using System.Collections.Generic;

namespace PlantenApplicatie.UI.Models
{
    public partial class FenotypeMulti
    {
        public long Id { get; set; }
        public long PlantId { get; set; }
        public string Eigenschap { get; set; }
        public string Maand { get; set; }
        public string Waarde { get; set; }
    }
}
