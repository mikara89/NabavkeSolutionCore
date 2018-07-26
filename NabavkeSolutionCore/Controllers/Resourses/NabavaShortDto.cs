using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NabavkeSolutionCore.Controllers.Resourses
{
    public class NabavaShortDto
    {
        public int Id { get; set; }
        public int SifraNabavke { get; set; }
        public string NazivDokumenta { get; set; }
        public string NazivNarucioca { get; set; }
        public int IdMesto { get; set; }
        public MestoDto Mesto { get; set; }

        public string VrstaPredmeta { get; set; }

        public DateTime? DatumPoslednjeIzmene { get; set; }

        public string Link { get; set; }

    }
}
