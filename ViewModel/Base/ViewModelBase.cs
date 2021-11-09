using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FitnessWPF.ViewModel.Base
{
    internal class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Генерирует событие при изменении свойства
        /// </summary>
        /// <param name="PropertyName">[CallerMemberName] Если метод вызывается без параметров
        /// - то компилятор автоматом подставляет имя метода из которого вызвана процедура</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
        /// <summary>
        /// Обновляет значение свойства
        /// Разрешает кольцевые изменения свойств 1 обновляет 2 -> 2 обновляет 3-> 3 обновляет 1
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="field"> ссылка на поле в котором свойство хранит свои данные</param>
        /// <param name="value">новое значение </param>
        /// <param name="PropertyName">имя свойства переданного в OnPropertyChanged</param>
        /// <returns></returns>
        protected virtual bool Set<T>(ref T fild, T value, [CallerMemberName] string PropertyName = null)
        {
            if (Equals(fild, value)) return false;
            fild = value;
            OnPropertyChanged(PropertyName);
            return true;
        }
    }
}