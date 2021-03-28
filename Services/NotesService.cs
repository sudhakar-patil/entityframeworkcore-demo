
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using efcoredemo.Interface;
using efcoredemo.Models;
using efcoredemo.Database;

namespace efcoredemo.Services
{
    public class NotesService : INotesService
    {
        private readonly IUnitOfWork<Database.Note> _unitOfWork;
        public NotesService(IUnitOfWork<Database.Note> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddNote(Models.Note note)
        {
            await _unitOfWork.Repository.Add(new Database.Note()
            { Title =  note.Title, Details = note.Details});
            await _unitOfWork.Commit();
        }

        public async Task<List<Models.Note>> GetAll()
        {
           var notes = await _unitOfWork.Repository.All();
           List<Models.Note> notesList= new List<Models.Note>();
           foreach(var note in notes)
           {
                notesList.Add(new Models.Note(){
                     Details = note.Details,
                     Title = note.Title, 
                     Id = note.Id }
                     );
           }
            return notesList;
        }

        public async Task<Models.Note> GetById(int id)
        {
           var note = await _unitOfWork.Repository.GetById(id);
           return new Models.Note()
           {
              Title = note.Title,
              Id= note.Id,
              Details = note.Details
           };
        }
    }
}