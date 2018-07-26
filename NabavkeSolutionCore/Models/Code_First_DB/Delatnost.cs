using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NabavkeSolutionCore.Models.Code_First_DB
{
    [Table("Delatnost")]
    public class Delatnost
    {
        //public Delatnost()
        //{
        //    Nabavke = new HashSet<Nabavka>();
        //}
        [Key] //This isn't technically needed, but I prefer to be explicit.
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdDelatnost { get; set; }
        public string Naziv { get; set; }
        //public virtual ICollection<Nabavka> Nabavke { get; set; }
        public override string ToString()
        {
            return Naziv;
        }
    }
}
