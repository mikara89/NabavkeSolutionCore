import { Component, OnInit, Input } from '@angular/core';
import { Nabavka } from '../../model/models';

@Component({
  selector: 'nabavke-card',
  templateUrl: './nabavke-card.component.html',
  styleUrls: ['./nabavke-card.component.css']
})
export class NabavkeCardComponent {
  @Input('nabavka')nabavka:Nabavka;
  @Input('color')color:string;
  constructor() { }

}
