using System;
using System.Collections.Generic;

namespace NabavkeSolutionCore.Models.DB
{
    public partial class Opstina
    {
        public Opstina()
        {
            Nabavke = new HashSet<Nabavke>();
            NabavkeUpdate = new HashSet<NabavkeUpdate>();
        }

        public int IdOpstine { get; set; }
        public string Naziv { get; set; }

        public ICollection<Nabavke> Nabavke { get; set; }
        public ICollection<NabavkeUpdate> NabavkeUpdate { get; set; }
    }
}
