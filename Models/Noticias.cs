using System;
using System.Collections.Generic;
using System.IO;
using EPlayers_AspNETCore.Interfaces;

namespace EPlayers_AspNETCore.Models
{
    public class Noticias : EPlayersBase, INoticias
    {   
        public int IdNoticia { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public string Imagem { get; set; }

        private const string PATH = "Database/noticias.csv";

        /// <summary>
        /// metodo construtor
        /// </summary>
        public Noticias(){
            CreateFolderAndFile(PATH);
        }

        /// <summary>
        /// metodo para alterar algo na noticia
        /// </summary>
        /// <param name="n"></param>
        public void Update(Noticias n)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == n.IdNoticia.ToString());
            linhas.Add( PrepararLinha(n) );
            RewriteCSV(PATH, linhas);
        }

        /// <summary>
        /// metodo para criar uma nova noticia
        /// </summary>
        /// <param name="n"></param>
        public void Create(Noticias n)
        {
            string[] linha = { PrepararLinha(n) };
            File.AppendAllLines(PATH, linha);
        }

        /// <summary>
        /// metodo de prepara a linha do csv
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private string PrepararLinha(Noticias n){
            return $"{n.IdNoticia};{n.Titulo};{n.Texto};{n.Imagem}";
        }

        /// <summary>
        /// metodo para ler e passar para o csv
        /// </summary>
        /// <returns></returns>
        public List<Noticias> ReadAll()
        {
            List<Noticias> noticias = new List<Noticias>();
            string[] linhas = File.ReadAllLines(PATH);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Noticias noticia = new Noticias();
                noticia.IdNoticia = Int32.Parse(linha[0]);
                noticia.Titulo = linha[1];
                noticia.Texto = linha[2];
                noticia.Imagem = linha[3];

                noticias.Add(noticia);
            }
            return noticias;
        }

        /// <summary>
        /// metodo para excluir uma noticia pelo id
        /// </summary>
        /// <param name="id">id da noticia</param>
        public void Delete(int id)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == id.ToString());
            RewriteCSV(PATH, linhas);
        }

       
    }
}