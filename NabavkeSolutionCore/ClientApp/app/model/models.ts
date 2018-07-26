export interface Vrsta{
    "naziv": string,
    "count": number,
    "color": string,
}
export interface Nabavka{
    "id":number,
    "sifraNabavke": number,
    "nazivDokumenta": string,
    "nazivNarucioca": string,
    "idMesto": number,
    "mesto": {
        "idMesta": number,
        "naziv": string
    },
    "vrstaPredmeta": string,
    "datumPoslednjeIzmene": string,
    "link": string,
    "pozivZaPodnosenjePonuda": number,
    "konkursnaDokumentacija": number,
    "odlukaODodeliUgovora": number,
    "obavestenjeOPonistenjuPostupka": number,
    "odlukaOObustaviPostupka": number,
    "odlukaONastavkuPostupka": number,
    "obavestenjeOZakljucenomUgovoru": number,
    "obavestenjeOProduzenjuRoka": number,
    "pregovarackiBezPonuda": number,
    "obavestenjeOZastitiPrava":number
}