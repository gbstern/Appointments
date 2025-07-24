import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManagerNavigationComponent } from './manager-navigation.component';

describe('ManagerNavigationComponent', () => {
  let component: ManagerNavigationComponent;
  let fixture: ComponentFixture<ManagerNavigationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ManagerNavigationComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ManagerNavigationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
