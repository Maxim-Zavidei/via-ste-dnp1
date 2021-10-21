using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace SendingObject_Server {
    class SocketHandlerClient {
        public List<NetworkStream> connectedClients = new List<NetworkStream>();

        public void HandleClient(TcpClient Client) {
            NetworkStream stream = Client.GetStream();
            connectedClients.Add(stream);

            byte[] dataFromClient = new byte[1024];
            while (true) {
                int bytesRead = stream.Read(dataFromClient, 0, dataFromClient.Length);
                string json = Encoding.ASCII.GetString(dataFromClient, 0, bytesRead);
                Message s = JsonSerializer.Deserialize<Message>(json);
                if (s.MessageBody == "exit") break;
                Console.WriteLine(s.MessageBody);

                Broadcast(s.MessageBody);
            }

            connectedClients.Remove(stream);
            Client.Close();
        }

        public void Broadcast(string message) {
            Message m = new Message() {
                TimeStamp = "poop",
                MessageBody = message
            };
            foreach (var client in connectedClients) {
                byte[] dataToClient = Encoding.ASCII.GetBytes(m.AsJson());
                client.Write(dataToClient, 0, dataToClient.Length);
            }
        }
    }
}