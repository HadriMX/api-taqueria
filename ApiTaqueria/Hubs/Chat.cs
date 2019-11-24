using ApiTaqueria.Persistence.Entities;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTaqueria.Hubs
{
    public class Chat : Hub
    {
        public void BroadcastMessage(string name, string message)
        {
            Clients.All.SendAsync("broadcastMessage", name, message);
        }

        public void Echo(string name, string message)
        {
            Clients.Client(Context.ConnectionId).SendAsync("echo", name, message + " (echo from server)");
        }

        public async Task ActualizarOrdenes()
        {
            await Clients.All.SendAsync("actualizarOrdenes").ConfigureAwait(false);
        }

        public async Task NotificarNuevaOrden(Ordenes orden)
        {
            await Clients.All.SendAsync("notificarNuevaOrden", orden).ConfigureAwait(false);
        }
    }
}
