import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EntitySectionComponent } from './entity-section/entity-section.component';
import { GeolocationPageComponent } from './geolocation-page/geolocation-page.component';
import { WeatherPageComponent } from './weather-page/weather-page.component';

const routes: Routes = [
  { path: 'Weather', component: WeatherPageComponent },
  { path: 'SysAdminUnitSection', component: EntitySectionComponent },
  { path: 'Geolocation', component: GeolocationPageComponent },
  { path: '**', redirectTo: 'Weather' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
