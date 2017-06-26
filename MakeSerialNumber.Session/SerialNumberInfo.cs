namespace MakeSerialNumber.Session
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SerialNumber")]
    public partial class SerialNumberInfo
    {
        [Required]
        [StringLength(50)]
        [Key]
        public string Name { get; set; }

        public long Number { get; set; }

        //[Timestamp]
        //public byte[] RowVersion { get; set; }
    }
}
