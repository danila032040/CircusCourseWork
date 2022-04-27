using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CircusCourseWork.ViewModels.Base
{
    public abstract class ViewModel : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        private readonly Dictionary<string, List<Error>> _errors;

        protected ViewModel()
        {
            _errors = new Dictionary<string, List<Error>>();
        }

        public bool HasErrors => _errors.Sum(k => k.Value.Count) != 0;

        public IEnumerable GetErrors([CallerMemberName] string? propertyName = null)
        {
            if (propertyName == null) throw new ArgumentNullException(nameof(propertyName));
            return _errors[propertyName];
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void OnErrorsChanged([CallerMemberName] string? propertyName = null)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        protected void AddError(Error error, [CallerMemberName] string? propertyName = null)
        {
            if (propertyName == null) throw new ArgumentNullException(nameof(propertyName));
            if (!_errors.ContainsKey(propertyName)) _errors[propertyName] = new List<Error>();

            _errors[propertyName].Add(error);
        }

        protected void ClearErrors([CallerMemberName] string? propertyName = null)
        {
            if (propertyName == null) throw new ArgumentNullException(nameof(propertyName));
            if (!_errors.ContainsKey(propertyName)) _errors[propertyName] = new List<Error>();

            _errors[propertyName].Clear();
        }
    }
}