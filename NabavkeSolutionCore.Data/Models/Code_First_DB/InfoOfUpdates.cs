using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NabavkeSolutionCore.Data.Models.Code_First_DB
{
    public class InfoOfUpdates
    {
        public DateTime? LastUpdated { get; set; }

        public int Radovi { get; set; }
        public int Usluge { get; set; }
        public int Dobra { get; set; }

    }
}