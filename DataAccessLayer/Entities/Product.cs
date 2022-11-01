namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int ProductId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string Color { get; set; }

        [Column(TypeName = "money")]
        public decimal StandardCost { get; set; }

        [Column(TypeName = "money")]
        [Range(0, 100000)]
        public decimal UnitPrice { get; set; }

        [Required]
        [StringLength(50)]
        public string Size { get; set; }

        [Required]
        [StringLength(50)]
        [MaxLength(3)]
        public string Weight { get; set; }

        public int ProductCategoryId { get; set; }

        [Column(TypeName = "date")]
        public DateTime SellStartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime SellEndDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime DiscontinuedDate { get; set; }

        [Required]
        [StringLength(50)]
        public string PhotoFileName { get; set; }

        [Column(TypeName = "date")]
        public DateTime ModifiedDate { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
