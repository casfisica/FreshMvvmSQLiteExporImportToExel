using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using FreshMvvm;
using FreshMvvmSQLiteExporImportToExel.Model;
using FreshMvvmSQLiteExporImportToExel.Services;
using Xamarin.Forms;

namespace FreshMvvmSQLiteExporImportToExel.PageModels
{
    internal class ListPageModel : FreshBasePageModel
    {

        private Repository _repository = FreshIOC.Container.Resolve<Repository>();
        private User _selectedUser = null;

        /// <summary>
        /// Una colleccion para mostrar los usuarios en las list view
        /// </summary>
        public ObservableCollection<User> Users { get; private set; }

        /// <summary>
        /// Para ligarla a la propiedad SelectedItem, 
        /// para llamar el commando EditUserCommand 
        /// </summary>
        public User SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                _selectedUser = value;
                if (value != null) EditUserCommand.Execute(value);
            }
        }

        /// <summary>
        /// Command associated with the edit item action.
        /// Navigates to the ItemPageModel with the selected item as the Init object.
        /// </summary>
        public ICommand EditUserCommand
        {
            get
            {
                return new Command(async (item) => {
                    await CoreMethods.PushPageModel<AddUserPageModel>(item);
                });
            }
        }

    }
}
