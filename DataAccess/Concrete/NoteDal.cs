using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class NoteDal : INoteDal
    {
        public void AddNote(Note note)
        {
            using (DataContext context = new DataContext())
            {
                var addedEntity = context.Entry(note);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void DeleteNoteById(int id)
        {
            using (DataContext context = new DataContext())
            {
                var note = context.Notes.FirstOrDefault(n => n.Id == id);   
                if (note != null)
                {
                    context.Notes.Remove(note);
                    context.SaveChanges();
                }
            }
        }

        public List<Note> GetAllNotes (Func<Note, bool> filter = null)
        {
            using (DataContext context = new DataContext())
            {
                return filter == null ?
                context.Set<Note>().ToList() : context.Set<Note>().Where(filter).ToList();
            }
        }

        public void UpdateNote(Note note)
        {

            using (DataContext context = new DataContext())
            {
                var modifiedEntity = context.Entry(note);
                modifiedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public List <Note> GetNotesByDate(DateTime selectedDate)
        {
            using (DataContext context = new DataContext())
            {
                return context.Set<Note>().Where(note => note.NotTarihi.Date == selectedDate.Date).ToList();
            }
        }

        public Note GetNotesById(int Id)
        {
            using (DataContext context = new DataContext())
            {
                return context.Notes.FirstOrDefault(x => x.Id == Id);
            }
        }

        public void IncreasePriority(Note note)
        {
            using (DataContext context = new DataContext())
            {
                note.Oncelik += 1;
                context.Notes.OrderBy(n => n.Oncelik).ToList();
                context.SaveChanges();
            }
        }

        








    }
}
