using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FitnessWPF.Model
{
    /// <summary>
    /// Пользователь
    /// </summary>
    [Serializable]
    public class User : INotifyPropertyChanged
    {

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        public Gender Gender { get; }
        public DateTime BirthDate { get;}

        private double _weight;
            public double Weight
        {
            get => _weight;
            set
            {
                _weight = value;
                OnPropertyChanged("Weight");
            }
        }
        private string _password;
        public string Password

        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }
        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }
        private double _height;
        public double Height
        {
            get => _height;
            set
            {
                _height = value;
                OnPropertyChanged("Height");
            }
        }
        public int Age
        {
            get
            {
                int age = DateTime.Today.Year - BirthDate.Year;
                if (BirthDate > DateTime.Today.AddYears(-age))
                {
                    age--;
                }
                return age;
            }
        }
        public User GetSomeUser()
        {
            return new User("SomeName", Gender.Male, Convert.ToDateTime("21.04.1985"), 127, 180);
        }
        public User(string name,
                    Gender gender,
                    DateTime birthDate,
                    double weight,
                    double hight)
        {
            #region Проверка условий
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым", nameof(name));
            }
            if (birthDate < DateTime.Parse("01.01.1900") || birthDate > DateTime.Now)
            {
                throw new ArgumentException("Дата рождения не может быть выходить за пределы 1900<дата<now", nameof(birthDate));
            }
            if (weight <= 0)
            {
                throw new ArgumentException("Вес не может быть <=0", nameof(weight));
            }
            if (hight <= 0)
            {
                throw new ArgumentException("Вес не может быть меньше 0", nameof(hight));
            }
            #endregion
            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = hight;
        }
        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым", nameof(name));
            }
            Name = name;
        }

        public User()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public override string ToString()
        {
            return Name + " " + Age;
        }
  
    }
}
