using System;
using System.Collections.Generic;
using System.Windows;


namespace GiveMeTheRESTClient
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public List<Message> messages { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = this;
            Message message3 = new Message("Nero", "And I'll burn all down!", "3.1.2016", new List<Message> { });
            Message message2 = new Message("Brutus", "I'll kill you!", "2.1.2016", new List<Message> {message3 });
            Message message1 = new Message("Julius Caesar", "Hay folks!", "1.1.2016", new List<Message> { message2});

            Message message = new Message("Julius Caesar", "Hay folks!", "1.1.2016", new List<Message> { message2 });

            messages = new List<Message>();
            messages.Add(message1);
            messages.Add(message);

        }

        public void NewAnswer_Click(object sender, EventArgs e)
        {
            // TODO
        }

        public void NewComment_Click(object sender, EventArgs e)
        {
            // TODO
        }
    }
}
