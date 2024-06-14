import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListCarpoolComponent } from './list-carpool.component';

describe('ListCarpoolComponent', () => {
  let component: ListCarpoolComponent;
  let fixture: ComponentFixture<ListCarpoolComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListCarpoolComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ListCarpoolComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
