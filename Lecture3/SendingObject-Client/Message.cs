using System.Text.Json;

namespace SendingObject_Client {
    class Message {
        public string TimeStamp { get; set; }
        public string MessageBody { get; set; }

        public string AsJson() {
            return JsonSerializer.Serialize(this);
        }
    }
}