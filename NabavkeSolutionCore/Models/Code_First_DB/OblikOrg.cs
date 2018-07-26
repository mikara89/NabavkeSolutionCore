using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NabavkeSolutionCore.Models.Code_First_DB
{
    [Table("OblikOrg")]
    public class OblikOrg 
    {

        [Key] //This isn't technically needed, but I prefer to be explicit.
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdOblikOrg { get; set; } 
        public string Naziv { get; set; }

        public override string ToString()
        {
            return Naziv;
        }
    }
}
