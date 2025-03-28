﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIO.Series.Interfaces
{
	public interface IRepository<T>
	{
		List<T> GetAll();
		T GetId(int id);
		void Insert(T entity);
		void Delete(int id);
		void Update(int id, T entity);
		int NextId();
	}
}
