import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';

import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { NabavkeComponent } from './components/nabavke/nabavke.component';
import { SearchComponent } from './components/search/search.component';
import { FocusDirective } from './directive/focus.directive';
import { NabavkeCardComponent } from './components/nabavke-card/nabavke-card.component';
import { NavmenuComponent } from './components/navmenu/navmenu.component';
import { NabavkeService } from './services/nabavke.service';
import { DataService } from './services/data.service';

@NgModule({
    declarations: [
        AppComponent,
        NavmenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        NabavkeComponent,
        SearchComponent,
        FocusDirective,
        NabavkeCardComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'nabavke/радови', pathMatch: 'full' },
            { path: 'nabavke/:vrsta', component: NabavkeComponent },
            { path: '**', redirectTo: 'home' }
        ]), 
        
    ], providers: [NabavkeService, DataService]
})
export class AppModuleShared {
}
