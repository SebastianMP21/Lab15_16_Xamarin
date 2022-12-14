using LocalDatabase.DataContext;
using LocalDatabase.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalDatabase.Services
{
    public class StudentService
    {
        private readonly AppDbContext _context;

        public StudentService() => _context = App.GetContext();

        public List<Student> Get()


        {
            return _context.Students.ToList();
        }

        public Student GetByID(int ID)
        {
            return _context.Students.Where(x => x.StudentId == ID).FirstOrDefault();
        }

        public bool Create(Student item)
        {
            try
            {
                _context.Students.Add(item);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public void CreateList(List<Student> items)
        {
            _context.Students.AddRange(items);
            _context.SaveChanges();
        }
        
        public async Task Update(Student item)
        {
            var prueba = item;
            _context.Students.Update(item);
            await _context.SaveChangesAsync();
        }
        public void Delete(int ID)
        {
            var model = GetByID(ID);
            _context.Remove(model);
            _context.SaveChanges();
        }

    }
}
