import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SubmitReleaseComponent } from './submit-release.component';

describe('SubmitReleaseComponent', () => {
  let component: SubmitReleaseComponent;
  let fixture: ComponentFixture<SubmitReleaseComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SubmitReleaseComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SubmitReleaseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
