using DIO.Series.Enums;
using DIO.Series.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIO.Series.Models
{
	public class Serie : EntidadeBase
	{
		public Genero Genero { get; private set; }
		public string Titulo { get; private set; }
		public string Descricao { get; private set; }
		public int Ano { get; private set; }

		public Serie(int id, Genero genero, string titulo, string descricao, int ano) :
			base(id)
		{
			Genero = genero;
			Titulo = titulo;
			Descricao = descricao;
			Ano = ano;
		}

		public override string? ToString()
		{
			string retorno = "";
			retorno += "Genero: " + Genero + Environment.NewLine;
			retorno += "Título: " + Titulo + Environment.NewLine;
			retorno += "Descrição: " + Descricao + Environment.NewLine;
			retorno += "Ano de Início: " + Ano + Environment.NewLine;

			return retorno;
		}
	}
}
