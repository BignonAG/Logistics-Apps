using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pyvvo.Logistics.Model
{
    public class Variant
    {
        [Required, Key] public long Id { get; set; }
        [Required] public long StatusId { get; set; }
        [Required] public long ParameterId { get; set; }
        [Required] public long ProductId { get; set; }
        [Required] public long TaxeId { get; set; }
        [Required] public long ImageId { get; set; }
        [Required] public long SupplierId { get; set; }
        [Required] public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string ReferenceNumber { get; set; }
        public double AvgSupplyTime { get; set; }
        public int LineNumber { get; set; }
        public string Type { get; set; }
        public bool IsActive { get; set; }
        public bool IsTaxable { get; set; }
        public string Weight { get; set; }
        public double MOQ { get; set; }
        public double InitialStockLevel { get; set; }
        public double InitialStockCost { get; set; }
        public double RetailPrice { get; set; }
        public double SpecialPrice { get; set; }
        public string SKU { get; set; }
        public string SupplierCode { get; set; }
        public string EAN { get; set; }
        public string UPC { get; set; }
        public string ISBN { get; set; }
        public string HSCode { get; set; }
        public string Name { get; set; }
        public Status Status { get; set; }
        public Parameter Parameter { get; set; }
        public Product Product { get; set; }
        public Taxe Taxe { get; set; }
        public Image Image { get; set; }
        public Supplier Supplier { get; set; }
        public List<Option> Options { get; set; }
        public List<PurchaseOrderLineItem> PurchaseOrderLineItems { get; set; }
        public List<StockLevel> StockLevels { get; set; }
        public List<LinkedVariant> Variants { get; set; }
        public List<LinkedVariant> LinkedVariants { get; set; }
       

    }
}
