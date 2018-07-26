import { ActivatedRoute } from '@angular/router';
import { Component, OnInit, Input } from '@angular/core';
import { NabavkeService } from '../../services/nabavke.service';


@Component({
  selector: 'nav-menu',
  templateUrl: './navmenu.component.html',
  styleUrls: ['./navmenu.component.css']
})
export class NavmenuComponent implements OnInit {

  constructor(
    private serviceNabavke: NabavkeService,
    private route: ActivatedRoute,
   ) {

    }
  @Input()isHover:boolean;
  activVrsta:string;
  hoverOver:string;
  @Input()isFocus:boolean;
  vrste:any[]=[
    {
      naziv:"радови",
      count:0,
      color:"#77D065",
      active:true,
    },
    {
      naziv:"услуге",
      count:0,
      color:"#A66CB2",
      active:false,
    },
    {
      naziv:"добра",
      count:0,
      color:"#FF8C47",
      active:false,
    }
];
  ngOnInit() {
    this.serviceNabavke.getInfo().subscribe(i=>{
        this.vrste['0'].count=i.radovi;
        this.vrste['1'].count=i.usluge;
        this.vrste['2'].count=i.dobra;
    });
  }
}
