using System.Collections.Generic;

namespace FitnessWPF.Model
{
    internal interface IDataSaver
    {
        void Save<T>(ICollection<T> item) where T : class;
        ICollection<T> Load<T>() where T : class;
        //bool Del<T>(T item) where T : class;
    }
}