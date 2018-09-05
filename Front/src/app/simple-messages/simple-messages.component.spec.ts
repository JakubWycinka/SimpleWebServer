import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SimpleMessagesComponent } from './simple-messages.component';

describe('SimpleMessagesComponent', () => {
  let component: SimpleMessagesComponent;
  let fixture: ComponentFixture<SimpleMessagesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SimpleMessagesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SimpleMessagesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
