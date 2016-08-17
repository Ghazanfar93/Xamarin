using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaGuideApp.Models;
using Xamarin.Forms;

namespace PharmaGuideApp.Pages
{

    public partial class MasterPage : ContentPage
    {
        public ListView ListView { get { return list; } }

        public MasterPage()
        {
            InitializeComponent();

            var masterPageItems = new List<MasterPageItem>();
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Home Page",
                // IconSource = "todo.png",
                TargetType = typeof(MainPage),
               
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Contacts Page",
                // IconSource = "contacts.png",
                TargetType = typeof(ContactsPage)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "TodoList Page",
                // IconSource = "todo.png",
                TargetType = typeof(TodoListPage)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Reminder Page",
                //IconSource = "reminders.png",
                TargetType = typeof(ReminderPage)
            });

            list.ItemsSource = masterPageItems;
        }
    }
}
