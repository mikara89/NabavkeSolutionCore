using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NabavkeSolutionCore.Data.Models.Code_First_DB
{
    [Table("VrstaPostupka")]
    public class VrstaPostupka
    {
        //public VrstaPostupka()
        //{
        //    Nabavke = new HashSet<Nabavka>();
        //}
        [Key] //This isn't technically needed, but I prefer to be explicit.
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdVrstaPostupka { get; set; } 
        public string Naziv { get; set; }
        //public ICollection<Nabavka> Nabavke { get; set; }
        public override string ToString()
        {
            return Naziv;
        }
    }
}
