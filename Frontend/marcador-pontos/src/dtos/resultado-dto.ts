export class ResultadosDto {
    dataPrimeiroJogo: Date; 
    dataUltimoJogo: Date; 
    quantidadePartidas: number;
    totalPontos: number;
    mediaPontos: number;
    maiorPontuacao: number; 
    menorPontuacao: number;
    quantidadeRecordesBatidos: number;

    constructor(
      dataPrimeiroJogo: Date,
      dataUltimoJogo: Date,
      quantidadePartidas: number,
      totalPontos: number,
      mediaPontos: number,
      maiorPontuacao: number,
      menorPontuacao: number,
      quantidadeRecordesBatidos: number
    ) {
      this.dataPrimeiroJogo = dataPrimeiroJogo;
      this.dataUltimoJogo = dataUltimoJogo;
      this.quantidadePartidas = quantidadePartidas;
      this.totalPontos = totalPontos;
      this.mediaPontos = mediaPontos;
      this.maiorPontuacao = maiorPontuacao;
      this.menorPontuacao = menorPontuacao;
      this.quantidadeRecordesBatidos = quantidadeRecordesBatidos;
    }
  }