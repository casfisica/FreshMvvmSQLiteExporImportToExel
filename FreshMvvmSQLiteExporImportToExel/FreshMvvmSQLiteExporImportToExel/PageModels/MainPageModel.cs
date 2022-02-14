using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using FreshMvvm;
using Xamarin.Forms;

namespace FreshMvvmSQLiteExporImportToExel.PageModels
{
    internal class MainPageModel : FreshBasePageModel
    {
        public ICommand GoToListPage
        {
            get
            {
                return new Command(async () => {
                    if (true)
                    {
                        await CoreMethods.PushPageModel<ListPageModel>();
                    }
                });
            }

        }
    }
}
