using System.ComponentModel;

namespace Deez_Notes_Dm.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        //private PropertyChangedEventHandler? notifyPropertyChanged;

        //public event PropertyChangedEventHandler? PropertyChanged
        //{
        //    add { this.notifyPropertyChanged = (PropertyChangedEventHandler)Delegate.Combine(this.notifyPropertyChanged, value); }
        //    remove { this.notifyPropertyChanged = (PropertyChangedEventHandler)Delegate.Remove(this.notifyPropertyChanged, value); }
        //}
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            //notifyPropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
