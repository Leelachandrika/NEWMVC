namespace CargoManagement
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("customer")]
    public partial class customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public customer()
        {
            bookingCargos = new HashSet<bookingCargo>();
        }

        [Key]
        public int customer_id { get; set; }

        [StringLength(20)]
        public string customer_name { get; set; }

        [StringLength(20)]
        public string customer_address { get; set; }

        [StringLength(20)]
        public string customer_mobile { get; set; }

        [StringLength(20)]
        public string customer_email { get; set; }

        [StringLength(10)]
        public string activestatus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bookingCargo> bookingCargos { get; set; }
    }
}
