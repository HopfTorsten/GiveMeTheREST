using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace GiveMeTheRESTClient
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public ObservableCollection<CompleteMessage> messages { get; set; }
        private RESTConnection connection;

        public MainWindow()
        {
            InitializeComponent();
            InitializeREST();
            this.DataContext = this;
            
            
            /* Message message3, message2, message1;
             message3 = new Message("Nero", "And I'll burn all down!", "3.1.2016", new List<Message> { });
             message2 = new Message("Brutus", "I'll kill you!", "2.1.2016", new List<Message> { message3 });
             message1 = new Message("Julius Caesar", "Hay folks!", "1.1.2016", new List<Message> { message2 });

             message3.Parent = message2;
             message2.Parent = message1;*/


            //messages.Add(message1);

        }

        private async void InitializeREST()
        {
            connection = new RESTConnection();
            connection.GetMessages();
            RefreshTreeView();
        }

        private void RefreshTreeView()
        {
            tvMessages.Items.Refresh();
        }

        public void NewAnswer_Click(object sender, EventArgs e)
        {
            /*Message item = ((sender as MenuItem).DataContext) as Message;
            item.Childs.Add(new Message("Nero", "And I'll burn all down!", "3.1.2016", new List<Message> { }, item));
             RefreshTreeView();*/
        }

        public void NewComment_Click(object sender, EventArgs e)
        {
            /*Message item = ((sender as MenuItem).DataContext) as Message;
            item.Parent.Childs.Add(new Message("Nero", "And I'll burn all down!", "3.1.2016", new List<Message> { }, item.Parent));
            RefreshTreeView();*/
        }
    }
}
