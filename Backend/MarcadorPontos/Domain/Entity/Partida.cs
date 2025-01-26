namespace Domain.Entity
{
    public class Partida
    {
        #region Properties
        public uint Id { get; set; }
        public string DataPartida { get; set; }
        public bool RecordeQuebrado { get; set; }
        public ushort Pontuacao { get; set; }
        public DateOnly DataPartidaConvertida { get; set; }
        #endregion

        #region Constructors
        public Partida()
        {
        }
        #endregion
    }
}
