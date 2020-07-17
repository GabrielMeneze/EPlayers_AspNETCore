using System.Collections.Generic;
using EPlayers_AspNETCore.Models;

namespace EPlayers_AspNETCore.Interfaces
{
    public interface INoticias
    {
        // Criar
        void Create(Noticias n);
        // Ler
        List<Noticias> ReadAll();
        // Alterar
        void Update(Noticias n);
        // Excluir
        void Delete(int Noticias);
    }
}