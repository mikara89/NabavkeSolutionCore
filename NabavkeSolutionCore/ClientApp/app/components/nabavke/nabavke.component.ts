
import { async } from '@angular/core/testing';
import { Subscription } from "rxjs";
import { Observable} from 'rxjs/Observable';
import { ActivatedRoute } from '@angular/router';
import { Component, OnInit, Inject, HostListener, Input,OnDestroy } from '@angular/core';
import { DOCUMENT } from '@angular/platform-browser';
import 'rxjs/add/observable/combineLatest';
import { DataService } from '../../services/data.service';
import { NabavkeService } from '../../services/nabavke.service';
@Component({
  selector: 'nabavke',
  templateUrl: './nabavke.component.html',
  styleUrls: ['./nabavke.component.css']
})


  export class NabavkeComponent implements OnInit,OnDestroy {
    ngOnDestroy(): void {
        if(this.sub)
            this.sub.unsubscribe();
        if(this.subSearch)
            this.subSearch.unsubscribe();
    }
    subSearch:Subscription;
    sub:Subscription;
    nab: any[]=[];
    oldNab: any[]=[];
    counter:number=0;
    @Input('searchInput')search:string;
    searchTest:string;
    isSearching:boolean;
    inSearch:boolean;
    isToggleSearch:boolean;
    vrsta:any={
        naziv:"",
        loaded:0 ,
        color:"",
    }
    vrste:any[]=[
        {
        naziv:"радови",
        count:0,
        color:"#77D065"
        },
        {
        naziv:"услуге",
        count:0,
        color:"#A66CB2"
        },
        {
        naziv:"добра",
        count:0,
        color:"#FF8C47"
        }
    ];
  isLoading=false;
    constructor(
        private serviceNabavke: NabavkeService, 
        private route: ActivatedRoute,
        private dataService:DataService
    ) {}
    ngOnInit(): void {
        let vrsta;
        this.route.paramMap.subscribe(p=>{
            if(p.get('vrsta')!=this.vrsta.naziv){
            this.vrsta.naziv=p.get('vrsta');
            if(this.sub){
                this.sub.closed;
                this.sub.unsubscribe();
            }
            this.vrsta.loaded=0;
            this.inSearch=false;
            this.isSearching=false;
            this.oldNab=[];
            this.nab=[];
            this.deleteSearch();
            for(let v of this.vrste){
                if(v['naziv']==this.vrsta.naziv)
                    this.vrsta.color=v['color'];
            }
            
            }
            this.populate();
        }); 
        this.dataService.onGetData.subscribe(res => {
            this.search=res;
            if(this.search)
            this.onSearch();
        
        });
    }
    deleteSearch() {
        delete this.search; 
        this.dataService.onGetData.emit(this.search);
    }
      @HostListener("window:scroll", [])
      onScroll(): void {
        if ((window.innerHeight + window.scrollY) >= document.body.offsetHeight) {
            let y=window.scrollY
            if(!this.isLoading){
                if(!this.isSearching){
                    this.populate(y);
                }           
                else {
                    this.populateOnSearch(y);
                }
            }
        }
      }
      
    populate(y?:number){
        this.isLoading=true;
        this.vrsta.loaded++;
        if(this.subSearch)
            this.subSearch.unsubscribe();
        this.sub=this.serviceNabavke.getNabavkeM(this.vrsta.naziv, this.vrsta.loaded).subscribe(n =>{
            if(this.nab.length==0){
                this.nab=n;
            }
            else{
                if(n[0].vrstaPredmeta==this.nab[0].vrstaPredmeta && !this.inSearch){
                    let concat=this.nab.concat(n);
                    this.nab=concat;  
                }
            }
                

            this.counter =this.nab.length;          
            
            if(y!=0){
                window.scroll(undefined,y);
            }
            this.isLoading=false; 
        });
    }
    populateOnSearch(y?:number){
        if(!this.search || this.search.length<5){
            this.searchFaild();
            return;
        }
        if(this.sub)
            this.sub.unsubscribe();
        this.isLoading=true;
        this.vrsta.loaded++;
        
        this.subSearch=this.serviceNabavke.getNabavkeM(this.vrsta.naziv, this.vrsta.loaded, this.search).subscribe(n =>{
            if(n.length==0){
                this.isLoading=false;
                this.vrsta.loaded--;
                if(y!=0){
                    window.scroll(undefined,y);
                }
                return;
            }
                
            if(this.nab.length==0){
                this.nab=n;
            }
            else{                
                let concat=this.nab.concat(n);
                this.nab=concat; 
                }
                

            this.counter =this.nab.length;
            
            
            if(y!=0){
                window.scroll(undefined,y);
            }
            this.isLoading=false; 
        });
    }
     onSearch(){
        if(this.search && this.search.length>=5 && !this.inSearch){

            this.inSearch=true;
 
            setTimeout(()=>{
                if(!this.isSearching){
                    this.oldNab=this.nab;
                }
                this.nab=[];
                this.vrsta.loaded=0;
                this.populateOnSearch();
                this.isSearching=true;
                this.inSearch=false;
            },1200);
            
        }
            else {
                this.searchFaild();
            }    
      }
      searchFaild(){
        this.isSearching=false;
        if(this.oldNab.length!=0){
            this.nab=this.oldNab;
            this.vrsta.loaded=this.nab.length/100;
        } 
      }

  }