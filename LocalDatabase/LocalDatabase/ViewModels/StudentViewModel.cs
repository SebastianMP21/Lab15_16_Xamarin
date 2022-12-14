using LocalDatabase.Models;
using LocalDatabase.Services;
using LocalDatabase.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace LocalDatabase.ViewModels
{
    public class StudentViewModel : BaseViewModel
    {
        #region Services
        private readonly StudentService dataServiceStudents;
        #endregion

        #region Attributes
        Student estudent;
        private string first_name;
        private string last_name;
        private string fecha_nacimiento;
        private int nota;

        
        #endregion

        #region Properties

        private string title = "Agregar";
        public string Title
        {
            get { return this.title; }
            set { SetValue(ref this.title, value); }
        }
        public string FirstName
        {
            get { return this.first_name; }
            set { SetValue(ref this.first_name, value); }
        }

        public string LastName
        {
            get { return this.last_name; }
            set { SetValue(ref this.last_name, value); }
        }

        public string FechaNacimiento
        {
            get { return this.fecha_nacimiento; }
            set { SetValue(ref this.fecha_nacimiento, value); }
        }

        public int Nota
        {
            get { return this.nota; }
            set { SetValue(ref this.nota, value); }
        }

        string estado = "Aprobado";
        public string Aprobado
        {
            get { return estado; }
            set
            {
                if (nota < 13)
                {
                    estado = "Desaprobado";
                }
            }
                
        }


        #endregion

        #region Commands
        public ICommand CreateCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var newStudent = new Student()
                    {

                        FirstName = this.FirstName,
                        LastName = this.LastName,
                        FechaNacimiento = this.FechaNacimiento,
                        Nota = this.Nota,
                        Aprobado = this.Aprobado
                    };

                    if (estudent != null)
                    {
                    

                        newStudent.StudentId = estudent.StudentId;

                        await this.dataServiceStudents.Update(newStudent);
                        this.FirstName = string.Empty;
                        this.LastName = string.Empty;
                        this.FechaNacimiento = string.Empty;
                        this.Nota = 0;

                        await Application.Current.MainPage.Navigation.PushAsync(new StudentsPage());
                        StudentsViewModel studentsViewModel = new StudentsViewModel();
                        studentsViewModel.LoadStudents();

                    }
                    else
                    {
                        if (newStudent != null)
                        {
                            if (this.dataServiceStudents.Create(newStudent))
                            {
                                await Application.Current.MainPage.DisplayAlert("Proceso realizado correctamente",
                                                                                $"Estudiante añadido a la base de Datos",
                                                                                "Aceptar");
                                this.FirstName = string.Empty;
                                this.LastName = string.Empty;
                                this.FechaNacimiento = string.Empty;
                                this.Nota = 0;

                                await Application.Current.MainPage.Navigation.PushAsync(new StudentsPage());
                                StudentsViewModel studentsViewModel = new StudentsViewModel();
                                studentsViewModel.LoadStudents();

                            }
                            else
                                await Application.Current.MainPage.DisplayAlert("Operación Fallida",
                                                                                $"Error al crear el Estudiante, intente nuevamente",
                                                                                "Aceptar");
                        }
                    }
                });
            }
        }
        #endregion Commands

        #region Constructor
        public StudentViewModel()
        {
            this.dataServiceStudents = new StudentService();
        }
        public StudentViewModel(Student student)
        {
            this.dataServiceStudents = new StudentService();
            estudent = student;
            first_name = student.FirstName;
            last_name = student.LastName;
            fecha_nacimiento = student.FechaNacimiento;
            nota = student.Nota;
            Title = "Editar";

        }
        #endregion Constructor

        #region Methods


        #endregion
    }
}
