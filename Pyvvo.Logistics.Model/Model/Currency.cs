using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pyvvo.Logistics.Model
{
    public class Currency
    {
        [Required, Key] public long Id { get; set; }
        [Required] public long CreatedById { get; set; }
        [Required] public long StatusId { get; set; }
        public string Name { get; set; }
        [Required] public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int Precision { get; set; }
        public string Format { get; set; }
        public string CurrencySymbol { get; set; }
        public double ExchangeRate { get; set; }
        [Required] public Status Status { get; set; }
        [Required] public User CreatedBy { get; set; }
    }
}