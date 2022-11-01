namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderDetail")]
    public partial class OrderDetail
    {
        public int OrderId { get; set; }

        [Key]
        public int OrderDeatilId { get; set; }

        public int OrderQty { get; set; }

        public int ProductId { get; set; }

        [Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }

        [Column(TypeName = "money")]
        [Range(0,50)]
        public decimal UnitPriceDiscount { get; set; }

        public int LineTotal { get; set; }

        [Column(TypeName = "date")]
        public DateTime ModifiedDate { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}
