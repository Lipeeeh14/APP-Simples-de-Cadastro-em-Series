using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIO.Series.Models.Abstracts
{
	public abstract class EntidadeBase
	{
		public int Id { get; private set; }

		protected EntidadeBase(int id)
		{
			Id = id;
		}
	}
}
