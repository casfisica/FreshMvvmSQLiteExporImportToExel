using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using FreshMvvm;
using FreshMvvmSQLiteExporImportToExel.Model;
using FreshMvvmSQLiteExporImportToExel.Services;
using Xamarin.Forms;

namespace FreshMvvmSQLiteExporImportToExel.PageModels
{
    internal class AddUserPageModel : FreshBasePageModel
    {

        // Use IoC to get our repository.
        private Repository _repository = FreshIOC.Container.Resolve<Repository>();

        // Backing data model.
        private User _user;


        /// <summary>
        /// 
        /// </summary>
        public string UserUserName 
        {
            get { return _user.UserName; }
            set { _user.UserName = value; RaisePropertyChanged(); } 
        }


        /// <summary>
        /// 
        /// </summary>
        public string UserPassWD
        {
            get { return _user.PassWD; }
            set { _user.PassWD = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 
        /// </summary>
        public int UserIsAdmin
        {
            get { return _user.IsAdmin; }
            set { _user.IsAdmin = value; RaisePropertyChanged(); }
        }


        /// <summary>
        /// Cada ves que se navega hacia la pagina, se llama
        /// se puede usar para pasarle un objato para que se inicie.
        /// FreshMVVM does not provide a RaiseAllPropertyChanged,
        /// so we do this for each bound property, room for improvement.
        /// </summary>
        public override void Init(object initData)
        {
            _user = initData as User;
            if (_user == null) _user = new User();
            base.Init(initData);
            RaisePropertyChanged(nameof(UserIsAdmin));
            RaisePropertyChanged(nameof(UserPassWD));
            RaisePropertyChanged(nameof(UserUserName));
        }

        //public ICommand AddToDataBase
        //{
        //    get { return AddToDataBaseCommand; }
        //}

        //private async Command AddToDataBaseCommand()
        //{
        //    async
        //}

    }
}
