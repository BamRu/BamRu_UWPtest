using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.WindowManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace Notes
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            ApplicationView.PreferredLaunchViewSize = new Size(1280, 720);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;

        }

        

        private async void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            AppWindow appWindow = await AppWindow.TryCreateAsync();

            Frame frame = new Frame();
            this.Frame.Navigate(typeof(EditNote));

            //ElementCompositionPreview.SetAppWindowContent(appWindow, frame);
            
            //this.IsEnabled = false;
            //appWindow.TryShowAsync();
            
            
        }

        private async void TextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
 


            TextBlock text = (TextBlock)e.OriginalSource;

            NoteViewModel NVM = new NoteViewModel();


            Note note = NVM.SearchNote(text.Text);

            this.Frame.Navigate(typeof(EditNote),note);
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            object i = ((FrameworkElement)sender).DataContext;

            //(this.DataContext as NoteViewModel)?.AddNoteList(i as Note);
            (this.DataContext as NoteViewModel)?.RemoveNoteList(i as Note);

        }
    }
}
