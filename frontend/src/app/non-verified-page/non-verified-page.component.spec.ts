import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NonVerifiedPageComponent } from './non-verified-page.component';

describe('NonVerifiedPageComponent', () => {
  let component: NonVerifiedPageComponent;
  let fixture: ComponentFixture<NonVerifiedPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [NonVerifiedPageComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NonVerifiedPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
