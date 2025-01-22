export class Partida {
    id: number; 
    dataPartida: Date; 
    recordeQuebrado: boolean;
    pontuacao: number; 

    constructor(
        id: number,
        dataPartida: Date,
        recordeQuebrado: boolean,
        pontuacao: number
    ) {
        this.id = id;
        this.dataPartida = dataPartida;
        this.recordeQuebrado = recordeQuebrado;
        this.pontuacao = pontuacao;
    }
}