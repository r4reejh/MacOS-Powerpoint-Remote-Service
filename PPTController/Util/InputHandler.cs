using System;
using AppKit;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace PPTController.Util
{
    public class InputHandler
    {
        internal EventHandler<DataEventArgs> SendStream;
        internal static void Handle(InputHandler handler, string data)
        {
            Console.WriteLine("received: "+data);
            JObject input = JObject.Parse(data);
            var type = input["type"]?.ToString();

            if (!Enum.TryParse(type, true, out InputTypes Type))
                return;
            
            switch (Type)
            {
                case InputTypes.connectRequest:
                    PPTEntry.isConnected = true;
                    PPTEntry.updateUi?.Invoke(handler, new DataEventArgs("Your Phone is Paired, you may now use the app", null));
                    handler?.Send(new JObject
                    {
                        ["type"] = InputTypes.connectRequest.ToString(),
                        ["success"] = true,
                        ["uid"] = "000"
                    }.ToString(Formatting.None));
                    break;
                case InputTypes.inputRequest:
                    var action = input["data"]?.ToString();
                    if (!Enum.TryParse(action, true, out KeySimulations Action))
                        return;
                    ActionSimulator.Simulate(Action);
                    break;
            }
        }

        private void Send(string data)
        {
            SendStream?.Invoke(this, new DataEventArgs(data, null));
        }
    }
}