import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SubmitArtistComponent } from './submit-artist.component';

describe('SubmitArtistComponent', () => {
  let component: SubmitArtistComponent;
  let fixture: ComponentFixture<SubmitArtistComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SubmitArtistComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SubmitArtistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
