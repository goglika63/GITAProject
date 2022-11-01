namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.CompilerServices;

    [Table("Order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int OrderId { get; set; }

        public int RevisionNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime OrderDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime ShipDate { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        public int OrderNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string OnlineNumberFlag { get; set; }

        public int AccountNumber { get; set; }

        public int CustomerId { get; set; }

        public int ShipToAddressId { get; set; }

        public int BillToAddressId { get; set; }

        [Required]
        [StringLength(50)]
        public string ShipMethod { get; set; }

        [Required]
        [StringLength(50)]
        public string CreditCardApprovalMethod { get; set; }

        public int SubTotal { get; set; }

        [Range(5,25)]
        public int TaxAmt { get; set; }

        [Required]
        [StringLength(50)]
        public string Freight { get; set; }

        [Required]
        [StringLength(50)]
        public string TotalDue { get; set; }

        [Required]
        [StringLength(50)]
        public string Comment { get; set; }

        [Column(TypeName = "date")]
        public DateTime ModifiedDate { get; set; }

        public virtual Address Address { get; set; }

        public virtual Address Address1 { get; set; }

        public virtual Customer Customer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
