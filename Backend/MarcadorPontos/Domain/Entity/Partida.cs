namespace Domain.Entity
{
    public class Partida
    {
        #region Properties
        public uint Id { get; set; }
        public DateOnly DataPartida { get; set; }
        public bool RecordeQuebrado { get; set; }
        public ushort Pontuacao { get; set; }
        #endregion

        #region Constructors
        public Partida()
        {
        }
        #endregion
    }
}
