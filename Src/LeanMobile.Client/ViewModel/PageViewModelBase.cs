using Prism.AppModel;
using Prism.Mvvm;
using Prism.Navigation;

namespace LeanMobile.Client.ViewModel
{
    public abstract class PageViewModelBase : BindableBase, INavigationAware, IApplicationLifecycleAware, IDestructible
    {
        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        public virtual void OnNavigatingTo(INavigationParameters parameters)
        {
        }

        public virtual void OnResume()
        {
        }

        public virtual void OnSleep()
        {
        }

        public virtual void Destroy()
        {
        }
    }
}