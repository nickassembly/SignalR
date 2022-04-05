using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

public class ViewHub : Hub
{
    public static int ViewCount {get; set;} = 0;

    public async Task NotifyWatching()
    {
        ViewCount++;

        // notify Everyone that a new client is watching
        await Clients.All.SendAsync("viewCountUpdate", ViewCount);
    }
}