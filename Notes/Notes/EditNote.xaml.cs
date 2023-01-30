using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace Notes
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class EditNote : Page
    {
        public int index =-1;
        public EditNote()
        {
            this.InitializeComponent();

            ApplicationView.PreferredLaunchViewSize = new Size(1280, 720);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            //this.DataContext = e.Parameter as NoteViewModel;
            if (e.Parameter != null)
            //if (false)
            {
            Note note = (Note)e.Parameter;

            this.DataContext = note;
            
                
            if (note.Id != null)
                index = note.Id;
 
            //textBoxTitle.Text = note.Title;
            //textBoxDescrition.Text = note.Description;
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (index ==  -1)
            {
                (this.DataContext as NoteViewModel)?.AddNoteList(new Note(0, textBoxTitle.Text, textBoxDescrition.Text));

            }
            else
            {
                (this.DataContext as NoteViewModel)?.EditNotes(new Note(index, textBoxTitle.Text, textBoxDescrition.Text));
            }

            this.Frame.GoBack();
  

            
            //this.DataContext as NoteViewModel)?.add(noteNew);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();

        }
    }
}
