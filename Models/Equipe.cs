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

        /// <summary>
        /// metodo construtor
        /// </summary>
        public Equipe(){
            CreateFolderAndFile(PATH);
        }

        /// <summary>
        /// metodo para alterar uma equipe
        /// </summary>
        /// <param name="e"></param>
        public void Update(Equipe e)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == e.IdEquipe.ToString());
            linhas.Add( PrepararLinha(e) );
            RewriteCSV(PATH, linhas);
        }

        /// <summary>
        /// metodo para criar uma nova equipe 
        /// </summary>
        /// <param name="e"></param>
        public void Create(Equipe e)
        {
            string[] linha = { PrepararLinha(e) };
            File.AppendAllLines(PATH, linha);
        }
        private string PrepararLinha(Equipe e){
            return $"{e.IdEquipe};{e.NomeEquipe};{e.ImagemEquipe}";
        }

        /// <summary>
        /// metodo para ler e escrever no csv
        /// </summary>
        /// <returns></returns>
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
        
        /// <summary>
        /// metodo para excluit uma equipe do csv
        /// </summary>
        /// <param name="id">id da equipe</param>
        public void Delete(int id)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == id.ToString());
            RewriteCSV(PATH, linhas);
        }
    }
}