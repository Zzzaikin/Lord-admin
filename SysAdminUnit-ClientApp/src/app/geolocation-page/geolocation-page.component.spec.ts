import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GeolocationPageComponent } from './geolocation-page.component';

describe('GeolocationPageComponent', () => {
  let component: GeolocationPageComponent;
  let fixture: ComponentFixture<GeolocationPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GeolocationPageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GeolocationPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
