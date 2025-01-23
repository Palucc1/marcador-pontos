import { Routes } from '@angular/router';
import { HomeComponent } from '../pages/home/home.component';
import { CadastroPartidaComponent } from '../pages/cadastro-partida/cadastro-partida.component';
import { ResultadosComponent } from '../pages/resultados/resultados.component';

export const routes: Routes = [
    { path: '', redirectTo: 'home', pathMatch: 'full'},
    { path: 'home', component: HomeComponent},
    { path: 'cadastro', component: CadastroPartidaComponent},
    { path: 'resultados', component: ResultadosComponent},
    { path: '**', redirectTo: 'home'},
];
