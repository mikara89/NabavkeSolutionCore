using System;
using System.Collections.Generic;

namespace NabavkeSolutionCore.Models.DB
{
    public partial class UpdateDblogs
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public int Old { get; set; }
        public DateTime? End { get; set; }
        public int New { get; set; }
        public string StatusMessage { get; set; }
    }
}
