import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CatsByOwnersGenderComponent } from './cats-by-owners-gender.component';

describe('CatsByOwnersGenderComponent', () => {
  let component: CatsByOwnersGenderComponent;
  let fixture: ComponentFixture<CatsByOwnersGenderComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CatsByOwnersGenderComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CatsByOwnersGenderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
