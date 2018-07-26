using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NabavkeSolutionCore.Models.Code_First_DB
{
    [Table("Nabavke")]
    public class Nabavka
    {
        [Key]
        public int Id { get; set; }
        public int SifraNabavke { get; set; }
        public string NazivDokumenta { get; set; }
        public string NazivNarucioca { get; set; }
        public int MaticniBroj { get; set; }
        public int PIB { get; set; }
        [ForeignKey("Mesto")]
        public int IdMesto { get; set; }
        public Mesto Mesto { get; set; }
        [ForeignKey("Opstina")]
        public int IdOpstina { get; set; }
        public Opstina Opstina { get; set; }
        [ForeignKey("VrstaPostupka")]
        public int IdVrstaPostupka { get; set; }
        public VrstaPostupka VrstaPostupka { get; set; }
        public string PredmetNabavke { get; set; }
        public string VrstaPredmeta { get; set; }
        public string OpstiRecnikNabavki { get; set; }
        public string KontaktOsoba { get; set; }
        public string Telefon { get; set; }
        public DateTime? DatumPoslednjeIzmene { get; set; }
        [ForeignKey("Delatnost")]
        public int IdDelatnost { get; set; }
        public Delatnost Delatnost { get; set; }
        [ForeignKey("OblikOrg")]
        public int IdOblikOrg { get; set; }
        public OblikOrg OblikOrg { get; set; }
        [ForeignKey("OblikSvoj")]
        public int IdOblikSvoj { get; set; }
        public OblikSvoj OblikSvoj { get; set; }
        [ForeignKey("Kategorija")]
        public int IdKategorija { get; set; }
        public Kategorija Kategorija { get; set; } 
        public int PozivZaPodnosenjePonuda { get; set; }
        public int PozivZaPodnosenjePrijava { get; set; }
        public int ObavestenjeOSistemuDinamickeNabavke { get; set; }
        public int PozivZaUcesceNaKonkursZaDizajn { get; set; }
        public int ObavestenjeOPriznavanjuKvalifikacije { get; set; }
        public int ObavestenjeOPriznavanjuKvalifikacijeURestriktivnomPostupku { get; set; }
        public int PodaciOObjaviIDodeliUgovora { get; set; }
        public int ObavestenjeOZakljucenomOkvirnomSporazumu { get; set; }
        public int ObavestenjeOZakljucenomUgovoru { get; set; }
        public int ObavestenjeORezultatuKonkursa { get; set; }
        public int ObavestenjeOObustaviPostupkaJavneNabavke { get; set; }
        public int PodaciOIzmeniUgovoraOJavnojNabavci { get; set; }
        public int KonkursnaDokumentacija { get; set; }
        public int ObavestenjeOProduzenjuRoka { get; set; }
        public int PregovarackiBezPonuda { get; set; }
        public int ObavestenjeOZastitiPrava { get; set; }
        public int MisljenjeUpraveJN { get; set; }
        public int OdlukaOPriznavanjuKvalifikacije { get; set; }
        public int OdlukaOIskljucenjuKandidata { get; set; }
        public int OdlukaODodeliUgovora { get; set; }
        public int OdlukaODodeliOkvirnogSporazuma { get; set; }
        public int ObavestenjeOPonistenjuPostupka { get; set; }
        public int OdlukaOObustaviPostupka { get; set; }
        public int OdlukaONastavkuPostupka { get; set; }
        public int OdlukaKomisijeOZakljucenjuUgovora { get; set; }
        public int ObavestenjeOPriznavanjuKvalifikacijeOpste { get; set; }
        public string Link { get; set; }
        public DateTime? LastUpdated { get; set; } 
        public override string ToString()
        {
            return "\nШифра набавке : " + SifraNabavke +
                "\nНабавка : " +NazivDokumenta +
                "\nНаручилац: "+NazivNarucioca;
        }
    }
}
