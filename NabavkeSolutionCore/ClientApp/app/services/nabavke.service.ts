import { Injectable } from '@angular/core';
import { Http } from "@angular/http";
import  "rxjs/add/operator/map";
import { Observable } from "rxjs/Observable";

@Injectable()
export class NabavkeService {
url1="http://mikara89-001-site1.etempurl.com/";
url2="";
    constructor(private http: Http) {
    }

    getNabavkeM(vrsta:string,serija:number,search?:string):Observable<any[]> {
        if(search!=null){
            return this.http.get( '/api/nabavkem/' + vrsta + '/search/' + search+'/'+serija)
            .map(res => res.json()); 
        }else{
           return this.http.get('/api/nabavkem/' + vrsta + '/' + serija)
            .map(res => res.json());
        }
    }
    getInfo() {
        return this.http.get('/api/nabavkem/info' )
         .map(res => res.json());
 }
}
