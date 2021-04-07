﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BeautySaloonDatabaseImplement.Models
{
    public class Visit
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public int? DistributionId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [ForeignKey("VisitId")]
        public virtual List<ProcedureVisit> ProcedureVisit { get; set; }

        public virtual Client Client { get; set; }

        public virtual Distribution Distribution { get; set; }
    }
}