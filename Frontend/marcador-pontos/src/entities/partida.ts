export class Partida {
    id: number; 
    dataPartida: string; 
    recordeQuebrado: boolean;
    pontuacao: number; 

    constructor(
        id: number,
        dataPartida: string,
        recordeQuebrado: boolean = false,
        pontuacao: number
    ) {
        this.id = id;
        this.dataPartida = dataPartida;
        this.recordeQuebrado = recordeQuebrado;
        this.pontuacao = pontuacao;
    }
}