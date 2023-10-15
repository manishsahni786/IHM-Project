//using System;
//using System.Collections.Generic;
using System.ComponentModel;
//using System.Linq;
using System.Runtime.CompilerServices;
//using System.Text;
//using System.Threading.Tasks;
using MireWpf.Annotations;

namespace MireWpf.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged notification

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
