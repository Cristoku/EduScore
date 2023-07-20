﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduScoreDatabase.CommandsQueries
{
    public class RemovingCommands
    {
        private EduScoreContext _context;

        public RemovingCommands()
        {
            _context = new EduScoreContext();
        }

        public void RemoveData<T>(T data) where T : class
        {
                _context.Set<T>().Remove(data);
                _context.SaveChanges();
        }

        public bool RemoveDataById(int id)
        {
            var dataToRemove = _context.Set<Grade>().FirstOrDefault(item => item.GradeId == id);

            if (dataToRemove == null)
            {
                return false;
            }

            _context.Set<Grade>().Remove(dataToRemove);
            _context.SaveChanges();
            return true;
        }

        public void RemoveData<T>(List<T> dataList) where T : class
        {
            using (var context = _context)
            {
                context.Set<T>().RemoveRange(dataList);
                context.SaveChanges();
            }
        }
    }
}