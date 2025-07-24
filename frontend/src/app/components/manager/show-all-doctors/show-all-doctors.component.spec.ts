import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowAllDoctorsComponent } from './show-all-doctors.component';

describe('ShowAllDoctorsComponent', () => {
  let component: ShowAllDoctorsComponent;
  let fixture: ComponentFixture<ShowAllDoctorsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ShowAllDoctorsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShowAllDoctorsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
