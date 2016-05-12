using System;
using System.Collections.Generic;
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
            try
            {

                //Sort from small to bigger to ensure that childs find their parents
                jsonMessages.messages = jsonMessages.messages.OrderBy(x => (int)x.id).ToList();

                //Change to dic to shorter access
                Dictionary<int, JSONMessage> messagesDic = jsonMessages.messages.ToDictionary(x => (int)x.id);


                //Transformation
                foreach (KeyValuePair<int, JSONMessage> item in messagesDic)
                {
                    //Content and id to new format
                    completeMessage = new CompleteMessage();
                    parent = new CompleteMessage();
                    completeMessage.Value = item.Value.content;
                    completeMessage.Id = (int)item.Value.id;

                    //search for parent
                    if ((int)item.Value.parent != 0)
                    {
                        parent = FindParent(0, (int)item.Value.parent, completeMessages);

                        //if parent found, add child
                        if (parent != null)
                        {
                            completeMessage.Parent = parent;
                            parent.Childs.Add(completeMessage);
                        }
                    }
                    // If parent doesn't exist
                    else
                    {
                        completeMessage.Parent = null;
                        completeMessages.Add(completeMessage);
                    }
                }
                System.Diagnostics.Debug.Write(completeMessages.ToString());
                return completeMessages;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
                return null;
            }
        }

        public async void PostMessage(CompleteMessage message)
        {
            var jsonMessage = TransformCompleteToJSON(message);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(REST_URI);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.PostAsJsonAsync(GET_ALL_URI, jsonMessage);

                if (response.IsSuccessStatusCode)
                    MessageBox.Show("Nachricht gepostet mit Code:" + response.StatusCode, "Neuer Post", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                    MessageBox.Show("Nachricht gepostet mit Code:" + response.StatusCode, "Fehler bei Post", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private JSONMessage TransformCompleteToJSON(CompleteMessage message)
        {
            JSONMessage jsonMessage = new JSONMessage();
            jsonMessage.parent = message.Parent.Id;
            jsonMessage.content = message.Value;
            return jsonMessage;
        }

        //An inefficent way to find the parent
        private CompleteMessage FindParent(int counter, int parentId, Collection<CompleteMessage> completeMessages)
        {
            CompleteMessage parent;

            //Breaks, if list is at the end
            if (counter < completeMessages.Count)
            {
                //If current node is the parent
                if (completeMessages[counter].Id == parentId)
                    return completeMessages[counter];

                //Search in childs, if existing
                else if (completeMessages[counter].Childs.Count > 0)
                {
                    parent = FindParent(0, parentId, completeMessages[counter].Childs);
                    //If parent found in childs, return
                    if (parent != null)
                        return parent;
                }
                    //else search in neighbours
                    else
                        return FindParent(counter + 1, parentId, completeMessages);
            }
            return null;
        }
    }
}
