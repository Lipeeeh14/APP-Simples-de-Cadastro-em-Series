using DIO.Series.Interfaces;
using DIO.Series.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIO.Series.Repositories
{
	public class SerieRepository : IRepository<Serie>
	{
		private List<Serie> listSerie = new List<Serie>();

		public void Delete(int id)
		{
			listSerie[id] = null;
		}

		public List<Serie> GetAll()
		{
			return listSerie.Where(x => x != null).ToList();
		}

		public Serie GetId(int id)
		{
			return listSerie.FirstOrDefault(x => x.Id == id);
		}

		public void Insert(Serie entity)
		{
			listSerie.Add(entity);
		}

		public int NextId()
		{
			return listSerie.Count();
		}

		public void Update(int id, Serie entity)
		{
			listSerie[id] = entity;
		}
	}
}
