import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { DataService } from '../../services/data.service';

@Component({
  selector: 'search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {

  isToggleSearch: boolean;
  search:string;
 @ViewChild('searchRef') private elementRef: ElementRef;

  constructor(private dataService:DataService) { }

  ngOnInit() {
    this.dataService.onGetData.subscribe(res => {
      this.search=res;
  });
  }
  toggleSearch(){
    this.isToggleSearch=!this.isToggleSearch;
    setTimeout(()=> { ///refactor it
      this.ngAfterViewInit();
    }, 200);
    if(!this.isToggleSearch){
      delete this.search;
      this.onSearch()
    }

    
  }
  onSearch(){
    this.dataService.onGetData.emit(this.search);
  }
  ngAfterViewInit() { 

      this.elementRef.nativeElement.focus();          
  }

}
