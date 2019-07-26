using System;
using System.Collections.Generic;

namespace DLRegIdentity.Models
{
    public partial class Devicereg
    {
        public int Id { get; set; }
        public int? Recid { get; set; }
        public int? Workerid { get; set; }
        public int? Deviceid { get; set; }
        public DateTime? Time { get; set; }
        public byte? Inout { get; set; }
    }
}
