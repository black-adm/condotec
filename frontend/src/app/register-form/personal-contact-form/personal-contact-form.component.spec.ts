import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PersonalContactFormComponent } from './personal-contact-form.component';

describe('PersonalContactFormComponent', () => {
  let component: PersonalContactFormComponent;
  let fixture: ComponentFixture<PersonalContactFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PersonalContactFormComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PersonalContactFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
