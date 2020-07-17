using System;

namespace EPlayers_AspNETCore.Models
{
    public class Partida
    {
        public int IdPartida { get; set; }
        public int IdEquipe { get; set; }
        public int IdEquipe2 { get; set; }
        public DateTime Horario { get; set; }
    }
}