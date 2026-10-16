using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Pract4_Taztdinova
{
    public class Student : INotifyPropertyChanged
    {
        private int id;
        private string surname = "";
        private string name = "";
        private string group = "";
        private int math = 2;
        private int russian = 2;
        private int history = 2;

        public int Id
        {
            get => id;
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Surname
        {
            get => surname;
            set
            {
                if (surname != value)
                {
                    surname = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Name
        {
            get => name;
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Group
        {
            get => group;
            set
            {
                if (group != value)
                {
                    group = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Math
        {
            get => math;
            set
            {
                if (value < 2 || value > 5)
                    return;
                if (math != value)
                {
                    math = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(AverageGrade));
                }
            }
        }

        public int Russian
        {
            get => russian;
            set
            {
                if (value < 2 || value > 5)
                    return;
                if (russian != value)
                {
                    russian = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(AverageGrade));
                }
            }
        }

        public int History
        {
            get => history;
            set
            {
                if (value < 2 || value > 5)
                    return;
                if (history != value)
                {
                    history = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(AverageGrade));
                }
            }
        }

        public double AverageGrade => (Math + Russian + History) / 3.0;

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}