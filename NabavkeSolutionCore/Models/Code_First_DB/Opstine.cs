using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NabavkeSolutionCore.Models.Code_First_DB
{
    [Table("Opstina")]
    public class Opstina
    {
        //public Opstina()
        //{
        //    Nabavke = new HashSet<Nabavka>();
        //}
        [Key] //This isn't technically needed, but I prefer to be explicit.
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdOpstine { get; set; }
        public string Naziv { get; set; }
        //public ICollection<Nabavka> Nabavke { get; set; }
        public override string ToString()
        {
            return Naziv;
        }
    }
}
