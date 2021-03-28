using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using efcoredemo.Interface;
using efcoredemo.Models;
namespace efcoredemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NoteController : ControllerBase
    {
        private readonly ILogger<NoteController> _logger;
        private readonly INotesService _noteService;
        public NoteController(ILogger<NoteController> logger,
        INotesService noteService)
        {
            _logger = logger;
            _noteService =noteService;
        }
        [HttpGet]
        [Route("getById")]
        public async Task<IActionResult> GetById(int id)
        {
            
            var note = await _noteService.GetById(id);
            if(note == null)
              return NotFound("Resource Not Found");
            return Ok(note);
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAll()
        {
            
            var notes = await _noteService.GetAll();
             
            return Ok(notes);
        }

        [HttpPost]
        [Route("addnote")]
        public async Task<IActionResult> AddNote(Note note)
        {
            
            await _noteService.AddNote(note);            
             
            return Ok();
        }

        [HttpGet]
        [Route("Ping")]
        public string Ping()
        {
            return "I am alive";
        }
    }
}
