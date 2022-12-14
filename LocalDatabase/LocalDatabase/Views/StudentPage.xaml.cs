using LocalDatabase.Models;
using LocalDatabase.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LocalDatabase.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudentPage : ContentPage
    {
        public StudentPage()
        {
            InitializeComponent();
            this.BindingContext = new StudentViewModel();
        }
        public StudentPage(Student student)
        {
            InitializeComponent();
            this.BindingContext = new StudentViewModel(student);
        }
    }
}