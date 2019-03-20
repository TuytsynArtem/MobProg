using MvvmHelpers;
using System;
using System.Diagnostics;
using Test.DTO;
using Test.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public ObservableRangeCollection<NoteItem> SourceNotes { get; set; }

        private readonly ApiClient apiClient = new ApiClient();

        public MainPage()
        {
            SourceNotes = new ObservableRangeCollection<NoteItem>()
            {
                new NoteItem()
                {
                    Body = "",
                    Title = "title",
                    Id = 12
                },
                new NoteItem()
                {
                    Body = "",
                    Title = "title",
                    Id = 13
                },
                new NoteItem()
                {
                    Body = "",
                    Title = "title",
                    Id = 14
                },
                new NoteItem()
                {
                    Body = "",
                    Title = "title",
                    Id = 15
                },
            };
            BindingContext = this;
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                var notes = await apiClient.GetAllNotesAsync();

                SourceNotes.ReplaceRange(notes);
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
                //ignore
            }

        }
        private readonly ApiClient apiClient2 = new ApiClient();
        private async void Button_Clicked_2(object sender, System.EventArgs e)
        {
            try
            {
                SourceNotes.Clear();
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
                //ignore
            }

        }
    }
}