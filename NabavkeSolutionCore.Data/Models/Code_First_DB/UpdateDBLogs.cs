using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NabavkeSolutionCore.Data.Models.Code_First_DB
{
    public class UpdateDBLogs
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public int Old { get; set; }
        public DateTime? End { get; set; }
        public int New { get; set; }
        public string StatusMessage { get; set; } 
    }
}