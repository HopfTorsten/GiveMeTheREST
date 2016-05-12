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
            messages =  await connection.GetMessages();
            tvMessages.ItemsSource = messages;
            RefreshTreeView();
        }

        private void RefreshTreeView()
        {
            tvMessages.Items.Refresh();
        }

        public void NewAnswer_Click(object sender, EventArgs e)
        {
            CompleteMessage item = ((sender as MenuItem).DataContext) as CompleteMessage;
            CompleteMessage answer = new CompleteMessage("Nero", "And I'll burn all down!", "3.1.2016", new Collection<CompleteMessage> { }, item);
            item.Childs.Add(answer);
            if (connection != null)
                connection.PostMessage(answer);
            RefreshTreeView();
        }

        public void NewComment_Click(object sender, EventArgs e)
        {
            CompleteMessage item = ((sender as MenuItem).DataContext) as CompleteMessage;
            CompleteMessage comment = new CompleteMessage("Nero", "And I'll burn all down!", "3.1.2016", new Collection<CompleteMessage> { }, item.Parent);
            item.Parent.Childs.Add(comment);
            if (connection != null)
                connection.PostMessage(comment);
            RefreshTreeView();
        }
    }
}
