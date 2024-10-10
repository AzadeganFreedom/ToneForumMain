import { Routes } from '@angular/router';
import { StartComponent } from './components/start/start.component';
import { BandComponent } from './components/band/band.component';
import { UserComponent } from './components/user/user.component';
import { RegisterComponent } from './components/register/register.component';
import { LoginComponent } from './components/login/login.component';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';
import { ProfileComponent } from './components/profile/profile.component';
import { AdminGuard } from './admin/admin.guard';
import { ArtistComponent } from './components/artist/artist.component';
import { CollectionComponent } from './components/collection/collection.component';
import { SubmitArtistComponent } from './components/submit-artist/submit-artist.component';
import { SubmitReleaseComponent } from './components/submit-release/submit-release.component';
import { WantlistComponent } from './components/wantlist/wantlist.component';
import { ReleaseComponent } from './components/released/release.component';
import { EditReleaseComponent } from './components/edit-release/edit-release.component';
import { EditArtistComponent } from './components/edit-artist/edit-artist.component';

export const routes: Routes = [
    {path: 'Start', component: StartComponent},
    {path: 'Band/:id', component: BandComponent},
    {path: 'Release/:id', component: ReleaseComponent},
    {path: 'User', component: UserComponent, canMatch: [AdminGuard]},
    {path: 'EditRelease/:id', component: EditReleaseComponent},
    {path: 'EditArtist/:id', component: EditArtistComponent},
    {path: 'not-authorized', component: PageNotFoundComponent},
    {path: 'Login', component: LoginComponent},
    {path: 'Register', component: RegisterComponent},
    {path: 'Profile', component: ProfileComponent},
    {path: 'Artist', component: ArtistComponent},
    {path: 'Collection/:id', component: CollectionComponent},
    {path: 'Wantlist/:id', component: WantlistComponent},
    {path: 'SubmitArtist', component: SubmitArtistComponent},
    {path: 'SubmitRelease/:id', component: SubmitReleaseComponent},
    {path: '', redirectTo: '/Start', pathMatch: 'full'},
    {path: '**', component: PageNotFoundComponent}
];
