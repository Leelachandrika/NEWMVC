namespace CargoManagement
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserRolesMapping")]
    public partial class UserRolesMapping
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int UserID { get; set; }

        public int RoleID { get; set; }

        public virtual Login Login { get; set; }

        public virtual RoleMaster RoleMaster { get; set; }
    }
}
