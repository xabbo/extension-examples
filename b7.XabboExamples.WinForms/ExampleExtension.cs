using System;
using System.Threading.Tasks;

using Xabbo.Messages;
using Xabbo.Extension;
using Xabbo.GEarth;

namespace b7.XabboExamples.WinForms;

public class ExampleExtension : GEarthExtension
{
    public event Action<string> LogMessage;

    public bool EnablePacketManipulation { get; set; }
    public bool EnablePacketBlocking { get; set; }

    public ExampleExtension(GEarthOptions options)
        : base(options)
    { }

    private void Log(string message) => LogMessage?.Invoke(message);

    protected override void OnInterceptorConnected()
    {
        base.OnInterceptorConnected();
        Log("Connected to G-Earth.");
    }

    protected override void OnConnected(GameConnectedEventArgs e)
    {
        base.OnConnected(e);
        Log("Game connection established.\r\n\r\n"
            + $"               Host: {e.Host}\r\n"
            + $"               Port: {e.Port}\r\n"
            + $"  Client identifier: {e.ClientIdentifier}\r\n"
            + $"        Client type: {e.ClientType}\r\n"
            + $"     Client version: {e.ClientVersion}\r\n"
            + $"      Message infos: {e.Messages.Count:N0}\r\n"
        );
    }

    protected override void OnIntercepted(InterceptArgs e)
    {
        base.OnIntercepted(e);
        // Do something with all intercepted packets here.
    }

    protected override void OnDisconnected()
    {
        base.OnDisconnected();
        Log("Game connection ended.");
    }

    protected override void OnInterceptorDisconnected(DisconnectedEventArgs e)
    {
        base.OnInterceptorDisconnected(e);

        // For a typical extension, the application should shut down upon disconnection with G-Earth.
        // In this example, this is handled by the GEarthFormHandler class.
    }

    /* - Sending packets - */

    public void InjectPacketServer()
    {
        /* 
            Sends a packet to the server to make your avatar wave.
            Message names are based on the Unity client.
            Here we are using Out.Expression, however in the Flash
            client the message is called AvatarExpression.
            The mapping between Unity and Flash message names 
            (ex. Avatar : AvatarExpression) is defined in messages.ini.
         */

        Send(Out.Expression, 1);

        // It is possible to use Flash message names by using a string:
        Send(Out["AvatarExpression"], 1);

        Log("Sent packet to server.");
    }

    public void InjectPacketClient()
    {
        /*
            Sends a Chat packet to the client.
            Use the Send method to send packets to the server or client.
            The destination is determined by the message header; as we are using an
            incoming message header (In.Chat), the packet will be sent to the client.
        */

        Send(In.Chat, -1, "Hello from the Xabbo.GEarth example!", 0, 2, 0, 0);
        Log("Sent chat packet to client.");
    }

    /* - Intercepting packets - */

    // Packets can be intercepted using InterceptIn/Out attributes.
    [InterceptIn(nameof(Incoming.Chat), nameof(Incoming.Shout))]
    private void OnInterceptChat(InterceptArgs e)
    {
        // Changes incoming chat messages to upper-case if enabled.
        if (EnablePacketManipulation)
        {
            // Replaces a string after the first int (4 bytes).
            e.Packet.ReplaceString(e.Packet.ReadString(4).ToUpper(), 4);
        }
    }

    // "MoveAvatar" is used here to specify the Flash message name.
    // The Unity message name would be "Move" or nameof(Outgoing.Move).
    [InterceptOut("MoveAvatar")]
    private void OnInterceptMove(InterceptArgs e)
    {
        if (EnablePacketBlocking)
        {
            // Flags the packet to be blocked, this cannot be reversed.
            e.Block();

            int x = e.Packet.ReadInt(),
                y = e.Packet.ReadInt();

            Log($"Blocked move packet to ({x}, {y}).");
        }
    }

    /* - Sending and receiving packets asynchronously - */
    public async Task RetrieveInfoAsync()
    {
        try
        {
            Log("Retrieving user info...");

            // Send InfoRetrieve to get the user's data.
            await SendAsync(Out.InfoRetrieve);

            // Wait 5000ms to receive the UserObject packet.
            // Specifying block: true will prevent the packet being sent to the client.
            IPacket packet = await ReceiveAsync(In.UserObject, 5000, block: true);

            int userId = packet.ReadInt();
            string userName = packet.ReadString();

            Log($"Received user info\r\nID: {userId}\r\nName: {userName}");
        }
        catch (OperationCanceledException)
        {
            Log("Receive task timed out.");
        }
    }
}
