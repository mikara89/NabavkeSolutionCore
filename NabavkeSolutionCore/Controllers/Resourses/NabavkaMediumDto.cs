using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NabavkeSolutionCore.Controllers.Resourses
{
    public class NabavkaMediumDto
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
        public int PozivZaPodnosenjePonuda { get; set; }
        public int KonkursnaDokumentacija { get; set; }
        public int OdlukaODodeliUgovora { get; set; }
        public int ObavestenjeOPonistenjuPostupka { get; set; }
        public int OdlukaOObustaviPostupka { get; set; }
        public int OdlukaONastavkuPostupka { get; set; }
        public int ObavestenjeOZakljucenomUgovoru { get; set; }

        public int ObavestenjeOProduzenjuRoka { get; set; }
        public int PregovarackiBezPonuda { get; set; }
        public int ObavestenjeOZastitiPrava { get; set; }
    }
}