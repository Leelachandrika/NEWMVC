namespace CargoManagement
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("bookingCargo")]
    public partial class bookingCargo
    {
        [Key]
        public int booking_id { get; set; }

        public int? customer_id { get; set; }

        public int? product_id { get; set; }

        [StringLength(20)]
        public string quantity { get; set; }

        public int? total_cost { get; set; }

        public DateTime booking_date { get; set; }

        public virtual customer customer { get; set; }

        public virtual product product { get; set; }
    }
}
