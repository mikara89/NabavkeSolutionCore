import { Http } from '@angular/http';
import {Injectable, EventEmitter} from "@angular/core";    

@Injectable()
export class DataService {
  onGetData= new EventEmitter();
  constructor(private http: Http){}
  getData() {
    this.http.post('/params',null).map(res => {
      this.onGetData.emit(res.json());
    });
  }
}