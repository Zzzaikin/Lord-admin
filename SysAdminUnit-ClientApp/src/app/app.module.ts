import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { EntitySectionComponent } from './entity-section/entity-section.component';
import { NavMenuItemComponent } from './nav-menu-item/nav-menu-item.component';
import { WeatherPageComponent } from './weather-page/weather-page.component';
import { GeolocationPageComponent } from './geolocation-page/geolocation-page.component';
import { HttpClientModule } from '@angular/common/http';
import { EffectsModule } from '@ngrx/effects';
import { EntitiesEffects } from './store/entity/entities-effects';
import { StoreModule } from '@ngrx/store';
import { IEntityState } from './store/IEntityState';
import { entitiesReducer } from './store/entity/entities-reducer';
import { environment } from '../environments/environment';
import { EntitiesTableComponent } from './entities-table/entities-table.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    NavMenuItemComponent,
    WeatherPageComponent,
    GeolocationPageComponent,
    EntitySectionComponent,
    EntitiesTableComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    StoreModule.forRoot({ entities: entitiesReducer }),
    EffectsModule.forRoot([EntitiesEffects])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
