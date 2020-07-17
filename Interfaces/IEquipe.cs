using System.Collections.Generic;
using EPlayers_AspNETCore.Models;

namespace EPlayers_AspNETCore.Interfaces
{
    public interface IEquipe
    {
        // Criar
        void Create(Equipe e);
        // Ler
        List<Equipe> ReadAll();
        // Alterar
        void Update(Equipe e);
        // Excluir
        void Delete(int IdEquipe);
    }
}