using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using WarnasNewsTestApp.Pages;

namespace WarnasNewsTestApp.ViewModels
{
    class MainViewModel : BindableBase
    {
        public Page MemberTrackPage { get; set; }

        public MainViewModel() 
        {
            
        }

        public ICommand AddNewsButton => new DelegateCommand(() =>
        {
            MemberTrackPage = new AddNewsPage();
        }); // Кнопка для перехода на страницу Wellcome


        public ICommand ShowLastNewsButton => new DelegateCommand(() =>
        {
            MemberTrackPage = new ShowLastNewsPage();
        }); // Кнопка для перехода на страницу Wellcome


    }
}
