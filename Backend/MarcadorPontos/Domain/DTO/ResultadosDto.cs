namespace Domain.DTO
{
    public class ResultadosDto
    {
        public DateOnly DataPrimeiroJogo { get; set; }
        public DateOnly DataUltimoJogo { get; set; }
        public int QuantidadePartidas { get; set; }
        public int TotalPontos { get; set; }
        public double MediaPontos { get; set; }
        public ushort MaiorPontuacao { get; set; }
        public ushort MenorPontuacao { get; set; }
    }
}
