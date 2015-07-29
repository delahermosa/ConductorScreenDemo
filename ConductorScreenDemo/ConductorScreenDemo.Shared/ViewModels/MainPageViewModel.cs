using System;
using System.Collections.Generic;
using System.Text;
using Caliburn.Micro;

namespace ConductorScreenDemo.ViewModels
{
    public class MainPageViewModel : Conductor<Screen>
    {
        private readonly Screen1ViewModel _screen1ViewModel;
        private readonly Screen2ViewModel _screen2ViewModel;
        private readonly Screen3ViewModel _screen3ViewModel;

        public MainPageViewModel(Screen1ViewModel screen1ViewModel, Screen2ViewModel screen2ViewModel, Screen3ViewModel screen3ViewModel)
        {
            _screen1ViewModel = screen1ViewModel;
            _screen2ViewModel = screen2ViewModel;
            _screen3ViewModel = screen3ViewModel;
        }

        private int _currentPage;
        protected override void OnInitialize()
        {
            base.OnInitialize();

            _currentPage = 1;
            ActivateItem(_screen1ViewModel);
        }

        public void Next()
        {
            _currentPage++;
            UpdateActiveView();
        }

        public void Back()
        {
            _currentPage--;
            UpdateActiveView();
        }

        private void UpdateActiveView()
        {
            Screen activeScreen = null;
            switch (_currentPage)
            {
                case 1:
                    activeScreen = _screen1ViewModel;
                    break;
                case 2:
                    activeScreen = _screen2ViewModel;
                    break;
                case 3:
                    activeScreen = _screen3ViewModel;
                    break;
                default:
                    _currentPage = 1;
                    activeScreen = _screen1ViewModel;
                    break;
            }
            ActivateItem(activeScreen);
            NotifyOfPropertyChange(() => CanBack);
            NotifyOfPropertyChange(() => CanNext);
        }        

        public bool CanBack
        {
            get { return _currentPage > 1; }
        }

        public bool CanNext
        {
            get { return _currentPage < 3; }
        }
    }
}
