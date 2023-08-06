using MediaExplorer.Interfaces;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MediaExplorer.Services
{
    internal class NavigationHandler : BindableObject , INavigationHandler
    {
        public static NavigationHandler Instance { get; private set; }

        private readonly Stack<ContentView> store;

        private ContentView _currentView;
        public ContentView CurrentView
        {
            get { return _currentView; }
            private set
            {
                _currentView = value;
                OnPropertyChanged();
                _currentView.Focus();
            }
        }

        public Command Back { get; }

        public NavigationHandler()
        {
            if (Instance != null)
                DependencyService.Get<ILogger>().LogCritical("NAVIGATION HANDLER CREATED MORE THAN ONCE!");
            Instance = this;
            store = new Stack<ContentView>();
            Back = new Command(NavigateBack);
        }



        public void NavigateTo(ContentView content)
        {
            CurrentView = content;
            store.Push(content);
        }

        public void NavigateBack()
        {
            store.Pop();
            CurrentView = store.Peek();
        }
    }
}