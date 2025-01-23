import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { PartidaService } from '../../services/partida.service';
import { Partida } from '../../entities/partida';
import { CommonModule, DatePipe } from '@angular/common';
import { AppMaskDirective } from '../../utils/app-mask.directive';

@Component({
  selector: 'app-cadastro-partida',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule, AppMaskDirective],
  templateUrl: './cadastro-partida.component.html',
  styleUrl: './cadastro-partida.component.scss',
  providers: [DatePipe]
})
export class CadastroPartidaComponent {
  partidaForm: FormGroup;

  constructor(private fb: FormBuilder, private partidaService: PartidaService, private datePipe: DatePipe) {
    this.partidaForm = this.fb.group({
      id: 0,
      dataPartida: ['', [Validators.required]],
      pontuacao: ['', [Validators.required, Validators.pattern('^[0-9]+$')]],
      recordeQuebrado: [false]
    });
  }

  salvar(): void {
    if (this.partidaForm.valid) {
      const partida: Partida = this.partidaForm.value;

      partida.dataPartida = this.formatarData(partida.dataPartida.toString());

      this.partidaService.salvarPartida(partida).subscribe({
        next: (response) => {
          console.log('Partida salva com sucesso:', response);
          alert('Partida salva com sucesso!');
          this.partidaForm.reset();
        },
        error: (err) => {
          console.error('Erro ao salvar partida:', err);
          alert('Erro ao salvar a partida.');
        },
        complete: () => {
          console.log('Requisição completa');
        }
      });
    } else {
      alert('Formulário inválido. Por favor, preencha corretamente.');
    }
  }

  formatarData(data: string): Date {
    var dateStr = this.datePipe.transform(data, 'MM/dd/yyyy')!;
    console.log(dateStr);
    return new Date(dateStr);
  }
}
