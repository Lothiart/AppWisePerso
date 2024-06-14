import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreatecarpoolComponent } from './createcarpool.component';

describe('CreatecarpoolComponent', () => {
  let component: CreatecarpoolComponent;
  let fixture: ComponentFixture<CreatecarpoolComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreatecarpoolComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreatecarpoolComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
