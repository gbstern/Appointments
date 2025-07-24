import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowAllAppointmentsComponent } from './show-all-appointments.component';

describe('ShowAllAppointmentsComponent', () => {
  let component: ShowAllAppointmentsComponent;
  let fixture: ComponentFixture<ShowAllAppointmentsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ShowAllAppointmentsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShowAllAppointmentsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
