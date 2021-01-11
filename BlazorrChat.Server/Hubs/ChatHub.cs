using BlazorChatt.Client.Data;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BlazorrChatt.Server.Hubs
{
    public class ChatHub : Hub
    {
        private static readonly Dictionary<string, string> userLookup = new Dictionary<string, string>();

        public async Task SendMessage(string username, string message)
        {
            await Clients.All.SendAsync(Messages.REVCEIVE, username, message);
        }
        public async Task Register(string username)
        {
            var currentId = Context.ConnectionId;
            if (!userLookup.ContainsKey(currentId))
            {
                userLookup.Add(currentId, username);
                await Clients.AllExcept(currentId).SendAsync(
                    Messages.REVCEIVE,
                    username, $"{username} ist in Chat reingegangen"
                    );
            }
        }
        public override Task OnConnectedAsync()
        {
            Console.WriteLine("Connected");
            return base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception e)
        {
            Console.WriteLine($"Disconncted {e.Message} {Context.ConnectionId}");
            string id = Context.ConnectionId;
            if (!userLookup.TryGetValue(id, out string username))
            {
                username = "[nicht bekannt]";
            }
            userLookup.Remove(id);
            await Clients.AllExcept(Context.ConnectionId).SendAsync(
                Messages.REVCEIVE,
                username, $"{username} has left the chat"
                );
            await base.OnDisconnectedAsync(e);
        }
    }

}