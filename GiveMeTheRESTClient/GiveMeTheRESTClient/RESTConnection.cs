using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows;

namespace GiveMeTheRESTClient
{
    public class RESTConnection
    {
        private static readonly string REST_URI = "http://schattenhauer.de:8080/GiveMeTheRESTServer/";
        private static readonly string GET_ALL_URI = "rest/msg";


        public async Task<ObservableCollection<CompleteMessage>> GetMessages()
        {
            JSONMessages messages = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(REST_URI);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
                try
                {
                    HttpResponseMessage response = await client.GetAsync(GET_ALL_URI);
                    response.EnsureSuccessStatusCode(); 

                    if (response.IsSuccessStatusCode)
                    {
                        messages = await response.Content.ReadAsAsync<JSONMessages>();
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Folgender Fehler ist aufgetreten:\n" + e.Message, "Fehlermeldung", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            return TransformJSONToCompleteMessages(messages);
        }

        private ObservableCollection<CompleteMessage> TransformJSONToCompleteMessages(JSONMessages jsonMessages)
        {
            ObservableCollection<CompleteMessage> completeMessages = new ObservableCollection<CompleteMessage>();
            CompleteMessage completeMessage;
            CompleteMessage parent;

            foreach (JSONMessage item in jsonMessages.messages)
            {
                completeMessage = new CompleteMessage();
                completeMessage.Value = item.content;
                completeMessage.Id = item.id;

                if (item.parent != null)
                {
                    // TODO: Ausstieg, weil object und int?
                    parent = completeMessages.First(x => x.Id == item.parent);
                    completeMessage.Parent = parent;
                    parent.Childs.Add(completeMessage);
                }
                else
                {
                    completeMessage.Parent = null;
                    completeMessages.Add(completeMessage);
                }
            }
            return completeMessages;
        }
    }
}
