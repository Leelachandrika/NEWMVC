namespace CargoManagement
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("product")]
    public partial class product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public product()
        {
            bookingCargoes = new HashSet<bookingCargo>();
        }

        [Key]
        public int product_id { get; set; }

        [StringLength(20)]
        public string product_name { get; set; }

        [StringLength(20)]
        public string product_type { get; set; }

        public int? product_price { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bookingCargo> bookingCargoes { get; set; }
    }
}
