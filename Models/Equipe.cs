using System;
using System.Collections.Generic;
using System.IO;
using EPlayers_AspNETCore.Interfaces;

namespace EPlayers_AspNETCore.Models
{
    public class Equipe : EPlayersBase, IEquipe
    {
        public int IdEquipe { get; set; }
        public string NomeEquipe { get; set; }
        public string ImagemEquipe { get; set; }

        private const string PATH = "Database/equipe.csv";

        public Equipe()
        {
            CreateFolderAndFile(PATH);
        }

        public void Create(Equipe e)
        {
            string[] linha = {Preparar(e)};
            File.AppendAllLines(PATH, linha);
        }
        private string Preparar(Equipe e)
        {
            return $"{e.IdEquipe};{e.NomeEquipe};{e.ImagemEquipe}";
        }

        public void Delete(int IdEquipe)
        {
             List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == IdEquipe.ToString());
            RewriteCSV(PATH, linhas);
        }

        public List<Equipe> ReadAll()
        {
            List<Equipe> equipes = new List<Equipe>();
            string[] linhas = File.ReadAllLines(PATH);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Equipe equipe = new Equipe();
                equipe.IdEquipe = Int32.Parse(linha[0]);
                equipe.NomeEquipe = linha[1];
                equipe.ImagemEquipe = linha[2];

                equipes.Add(equipe);
            }
            return equipes;
        }

        public void Update(Equipe e)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == e.IdEquipe.ToString());
            linhas.Add(Preparar(e));
            RewriteCSV(PATH, linhas);
        }
    }
}