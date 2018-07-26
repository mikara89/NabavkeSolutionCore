using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NabavkeSolutionCore.Models.Code_First_DB
{
    [Table("Mesto")]
    public class Mesto
    {

        [Key] 
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdMesta { get; set; }
        public string Naziv { get; set; }
        //public ICollection<Nabavka> Nabavke { get; set; }

        public override string ToString()
        {
            return Naziv;
        }
    }
    
}
