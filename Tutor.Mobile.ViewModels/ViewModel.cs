using CommunityToolkit.Mvvm.ComponentModel;
using System.Runtime.CompilerServices;

namespace Tutor.Mobile.ViewModels;

public partial class ViewModel : ObservableObject
{
    [ObservableProperty]
    private string _title;
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    private bool _isBusy;
    public bool IsNotBusy => IsBusy;

    private readonly object _isBusyLock = new();
    protected bool CheckIsBusy()
    {
        lock (_isBusyLock)
        {
            if (IsBusy)
            {
                return true;
            }

            IsBusy = true;
            return false;
        }
    }
}
