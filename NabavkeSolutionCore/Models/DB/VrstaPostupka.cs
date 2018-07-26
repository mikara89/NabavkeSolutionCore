using System;
using System.Collections.Generic;

namespace NabavkeSolutionCore.Models.DB
{
    public partial class VrstaPostupka
    {
        public VrstaPostupka()
        {
            Nabavke = new HashSet<Nabavke>();
            NabavkeUpdate = new HashSet<NabavkeUpdate>();
        }

        public int IdVrstaPostupka { get; set; }
        public string Naziv { get; set; }

        public ICollection<Nabavke> Nabavke { get; set; }
        public ICollection<NabavkeUpdate> NabavkeUpdate { get; set; }
    }
}
