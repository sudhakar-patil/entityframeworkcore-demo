
using System.Collections.Generic;
using System.Threading.Tasks;
using efcoredemo.Models;

namespace efcoredemo.Interface
{
public interface INotesService
    {
        Task<Models.Note> GetById(int id);
        Task<List<Models.Note>> GetAll();
        Task AddNote(Note note);
    }
}