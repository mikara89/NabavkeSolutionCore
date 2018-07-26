using System;
using System.Collections.Generic;

namespace NabavkeSolutionCore.Models.DB
{
    public partial class Nabavke
    {
        public Nabavke()
        {
            //Pracenjes = new HashSet<Pracenjes>();
        }

        public int Id { get; set; }
        public int SifraNabavke { get; set; }
        public string NazivDokumenta { get; set; }
        public string NazivNarucioca { get; set; }
        public int MaticniBroj { get; set; }
        public int Pib { get; set; }
        public int IdMesto { get; set; }
        public int IdOpstina { get; set; }
        public int IdVrstaPostupka { get; set; }
        public string PredmetNabavke { get; set; }
        public string VrstaPredmeta { get; set; }
        public string OpstiRecnikNabavki { get; set; }
        public string KontaktOsoba { get; set; }
        public string Telefon { get; set; }
        public DateTime? DatumPoslednjeIzmene { get; set; }
        public int IdDelatnost { get; set; }
        public int IdOblikOrg { get; set; }
        public int IdOblikSvoj { get; set; }
        public int IdKategorija { get; set; }
        public int PozivZaPodnosenjePonuda { get; set; }
        public int PozivZaPodnosenjePrijava { get; set; }
        public int ObavestenjeOsistemuDinamickeNabavke { get; set; }
        public int PozivZaUcesceNaKonkursZaDizajn { get; set; }
        public int ObavestenjeOpriznavanjuKvalifikacije { get; set; }
        public int ObavestenjeOpriznavanjuKvalifikacijeUrestriktivnomPostupku { get; set; }
        public int PodaciOobjaviIdodeliUgovora { get; set; }
        public int ObavestenjeOzakljucenomOkvirnomSporazumu { get; set; }
        public int ObavestenjeOzakljucenomUgovoru { get; set; }
        public int ObavestenjeOrezultatuKonkursa { get; set; }
        public int ObavestenjeOobustaviPostupkaJavneNabavke { get; set; }
        public int PodaciOizmeniUgovoraOjavnojNabavci { get; set; }
        public int KonkursnaDokumentacija { get; set; }
        public int ObavestenjeOproduzenjuRoka { get; set; }
        public int PregovarackiBezPonuda { get; set; }
        public int ObavestenjeOzastitiPrava { get; set; }
        public int MisljenjeUpraveJn { get; set; }
        public int OdlukaOpriznavanjuKvalifikacije { get; set; }
        public int OdlukaOiskljucenjuKandidata { get; set; }
        public int OdlukaOdodeliUgovora { get; set; }
        public int OdlukaOdodeliOkvirnogSporazuma { get; set; }
        public int ObavestenjeOponistenjuPostupka { get; set; }
        public int OdlukaOobustaviPostupka { get; set; }
        public int OdlukaOnastavkuPostupka { get; set; }
        public int OdlukaKomisijeOzakljucenjuUgovora { get; set; }
        public int ObavestenjeOpriznavanjuKvalifikacijeOpste { get; set; }
        public string Link { get; set; }
        public DateTime? LastUpdated { get; set; }

        public Delatnost IdDelatnostNavigation { get; set; }
        public Kategorija IdKategorijaNavigation { get; set; }
        public Mesto IdMestoNavigation { get; set; }
        public OblikOrg IdOblikOrgNavigation { get; set; }
        public OblikSvoj IdOblikSvojNavigation { get; set; }
        public Opstina IdOpstinaNavigation { get; set; }
        public VrstaPostupka IdVrstaPostupkaNavigation { get; set; }
        //public ICollection<Pracenjes> Pracenjes { get; set; }
    }
}
