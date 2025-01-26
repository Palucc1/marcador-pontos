import { Component, OnInit } from '@angular/core';
import { ResultadosDto } from '../../dtos/resultado-dto';
import { PartidaService } from '../../services/partida.service';
import { CommonModule, DatePipe  } from '@angular/common';

@Component({
  selector: 'app-resultados',
  standalone: true,
  imports: [CommonModule] ,
  templateUrl: './resultados.component.html',
  styleUrl: './resultados.component.scss',
  providers: [DatePipe]
})
export class ResultadosComponent implements OnInit {
  resultados?: ResultadosDto; 
  carregandoResultados = true; 

  constructor(private partidaService: PartidaService, private datePipe: DatePipe) {}

  ngOnInit(): void {
    this.buscarResultados();
  }

  buscarResultados(): void {
    this.partidaService.recuperarResultados().subscribe({
      next: (dados: ResultadosDto) => {
          this.resultados = dados;
          this.carregandoResultados = false; 
      },
      error: (err) => {
        console.error('Erro ao buscar resultados:', err);
          this.carregandoResultados = false; 
      },
      complete: () => {
        console.log('Requisição completa');  
      }
    });
  }

  formatarData(data: string): string {
    return this.datePipe.transform(data, 'dd/MM/yyyy')!;
  }
}
