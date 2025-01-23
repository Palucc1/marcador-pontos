import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Partida } from '../entities/partida';
import { ResultadosDto } from '../dtos/resultado-dto';

@Injectable({
  providedIn: 'root'
})
export class PartidaService {
  private apiUrl = 'http://localhost:5062/api/partidas';

  constructor(private http: HttpClient) {}

  salvarPartida(partida: Partida): Observable<Partida> {
    console.log(partida);
    return this.http.post<Partida>(this.apiUrl, partida);
  }

  recuperarResultados(): Observable<ResultadosDto>{
    var result = this.http.get<ResultadosDto>(this.apiUrl);

    return result;
  }
}