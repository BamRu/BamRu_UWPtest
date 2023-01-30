using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Foundation;

namespace Notes
{
    internal class NoteViewModel
    {
        //public ObservableCollection<Note> NotesList { get { return NotesList; } set { NotesList = value; } } 
        public ObservableCollection<Note> NotesList { get; set; }=
            new ObservableCollection<Note>
        {
            new Note {Id = 2, Title = "111", Description = "Desc"},
            new Note {Id = 1, Title = "UWP List View Overflow with List UWP List View Overflow with List UWP List View Overflow with List UWP List View Overflow with List", Description = "Desc"},
            
            new Note {Id = 3, Title = "2", Description = "Desc"},
            new Note {Id = 4, Title = "3", Description = "Desc"},
            new Note {Id = 5, Title = "4", Description = "Desc"},
            new Note {Id = 6, Title = "5", Description = "Desc"},
            new Note {Id = 7, Title = "6", Description = "Desc"},
            new Note {Id = 8, Title = "7", Description = "Desc"}
        };
/*
        public ICommand RemoveNoteList {get; set; }
        public ICommand AddNoteList {get; set; }
        public ICommand EditNoteList { get; set; }
        
        public NoteViewModel()
        {
            RemoveNoteList = new RelayCommand(() =>
            {

            });
        }*/
        
        public Note SearchNote(string title)
        {
            for (int i = 0; i <NotesList.Count();i++)
            {
                if (NotesList[i].Title == title)
                {
                    return NotesList[i];
                }
            }
            return null;
        }

        public void RemoveNoteList(Note note)
        {
            NotesList.Remove(note);
            
        }

        public void AddNoteList(Note note)
        {
            NotesList.Add(note);
         
        }

       
        public void EditNotes (Note note)
        {
            foreach(Note noteB in NotesList)
            {
                if(noteB.Id == note.Id)
                {
                    NotesList[NotesList.IndexOf(noteB)] = noteB;
                    break;
                }
            }  

        }

      
    }
}
