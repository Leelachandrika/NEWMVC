namespace CargoManagement
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("employee")]
    public partial class employee
    {
        [Key]
        public int emp_id { get; set; }

        [StringLength(20)]
        public string emp_name { get; set; }

        [StringLength(20)]
        public string emp_department { get; set; }

        public int? emp_salary { get; set; }

        [StringLength(20)]
        public string emp_mobile { get; set; }

        [StringLength(10)]
        public string activestatus { get; set; }
    }
}
