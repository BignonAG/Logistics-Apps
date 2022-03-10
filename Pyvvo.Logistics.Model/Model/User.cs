using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pyvvo.Logistics.Model
{
    public class User
    {

        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)] public long Id { get; set; }
        [Required] public long StatusId { get; set; }
        [Required] public long CreatedById { get; set; }
        [Required] public long LocationId { get; set; }
        [Required] public long ContactId { get; set; }
        [Required] public long CompanyId { get; set; }
        public DateTime CreateDon { get; set; }
        [NotMapped] public string CreatedOnLocalTime { get => CreateDon.ToString("dd/MM/yyyy HH:mm:ss"); }
        public DateTime UpdateDon { get; set; }
        [NotMapped] public string UpdateOnLocalTime { get => UpdateDon.ToString("dd/MM/yyyy HH:mm:ss"); }
        public bool IsActive { get; set; }
        public Status Status { get; set; }
        public User CreatedBy { get; set; }
        public Warehouse Location { get; set; }
        public Contact Contact { get; set; }
        public Company Company { get; set; }
        [NotMapped] public Role Role { get; set; }
        public List<Membership> Membership { get; set; }
        public List<AccountLogin> AccountLogins { get; set; }
        public List<Address> Addresses { get; set; }
        public List<Shipment> Shipments { get; set; }
        public List<Processing> Processings { get; set; }
        public List<Return> Returns { get; set; }
        public List<PurchaseOrderReceive> PurchaseOrderReceives { get; set; }
        public List<Note> Notes { get; set; }
        public List<Task> Tasks { get; set; }
        public List<StockAdjustement> StockAdjustements { get; set; }
        public List<StockAdjustementLineItem> StockAdjustementLineItems { get; set; }
        public List<StockTransfer> StockTransfers { get; set; }
        public List<PurchaseOrder> PurchaseOrders { get; set; }
        public List<Team> Teams { get; set; }
        public List<Session> Session { get; set; }
    }

}
