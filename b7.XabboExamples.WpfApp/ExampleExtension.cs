using System;
using System.Text;
using System.Reflection;
using System.Windows.Input;

using GalaSoft.MvvmLight.Command;

using Xabbo.Messages;
using Xabbo.Interceptor;
using Xabbo.GEarth;

namespace b7.XabboExamples.WpfApp
{
    public class ExampleExtension : GEarthExtension
    {
        private static readonly GEarthOptions _options = new GEarthOptions
        {
            Title = "Xabbo.GEarth WPF",
            Description = "an example extension using the Xabbo framework",
            Author = "b7",
            Version = Assembly.GetExecutingAssembly().GetName().Version?.ToString(3) ?? "?",
            ShowEventButton = true
        };

        private bool _enablePacketManipulation = false;
        public bool EnablePacketManipulation
        {
            get => _enablePacketManipulation;
            set => Set(ref _enablePacketManipulation, value);
        }

        private bool _enablePacketBlocking = false;
        public bool EnablePacketBlocking
        {
            get => _enablePacketBlocking;
            set => Set(ref _enablePacketBlocking, value);
        }

        private StringBuilder _log = new();
        public string LogText
        {
            get => _log.ToString();
            set => Set(ref _log, new StringBuilder(value));
        }

        public ICommand InjectPacketClientCommand { get; }
        public ICommand InjectPacketServerCommand { get; }

        public ExampleExtension(int port)
            : base(_options, port)
        {
            InjectPacketClientCommand = new RelayCommand(InjectPacketClientExecuted);
            InjectPacketServerCommand = new RelayCommand(InjectPacketServerExecuted);
        }

        public void Log(string message)
        {
            _log.AppendLine($"[{DateTime.Now:HH:mm:ss.fff}] {message}");
            RaisePropertyChanged(nameof(LogText));
        }

        protected override void OnInterceptorConnected(object? sender, EventArgs e)
        {
            base.OnInterceptorConnected(sender, e);
            Log($"Connected to G-Earth.");
        }

        protected override void OnInterceptorInitialized(object? sender, EventArgs e)
        {
            base.OnInterceptorInitialized(sender, e);
            Log($"Extension initialized by G-Earth.");
        }

        protected override void OnClicked(object? sender, EventArgs e)
        {
            base.OnClicked(sender, e);
            Log($"Extension was clicked in G-Earth.");
        }

        protected override void OnGameConnected(object? sender, GameConnectedEventArgs e)
        {
            base.OnGameConnected(sender, e);
            Log($"Game connection established.\r\n\r\n"
                + $"               Host: {e.Host}\r\n"
                + $"               Port: {e.Port}\r\n"
                + $"  Client identifier: {e.Port}\r\n"
                + $"        Client type: {e.ClientType}\r\n"
                + $"     Client version: {e.ClientVersion}\r\n"
                + $"      Message infos: {e.Messages.Count:N0}\r\n"
            );
        }

        protected override void OnIntercepted(object? sender, InterceptArgs e)
        {
            base.OnIntercepted(sender, e);
            // Do something with all intercepted packets here
        }

        protected override void OnGameDisconnected(object? sender, EventArgs e)
        {
            base.OnGameDisconnected(sender, e);
            Log($"Game connection ended.");
        }

        protected override void OnInterceptorDisconnected(object? sender, EventArgs e)
        {
            base.OnInterceptorDisconnected(sender, e);
            Log($"Connection with G-Earth lost.");
        }

        private void InjectPacketClientExecuted()
        {
            /*
                Sends a Chat packet to the client.
                Use Send to send packets to the server or client.
                The destination is determined by the header.
            */
            Send(In.Chat, -1, "Hello from the Xabbo.GEarth example!", 0, 2, 0, 0);
            Log("Sent chat packet to client.");
        }

        private void InjectPacketServerExecuted()
        {
            // Sends a Chat packet to the server.
            Send(Out.Chat, "Hello, world", 0, -1);
            Log("Sent chat packet to server.");
        }

        [InterceptIn(nameof(Incoming.Chat), nameof(Incoming.Shout))]
        private void OnInterceptChat(InterceptArgs e)
        {
            // Changes incoming messages to upper-case
            if (EnablePacketManipulation)
            {
                // Replace a string after the first int (4 bytes) in the packet using a transform method
                e.Packet.ReplaceString(s => s.ToUpper(), 4);
            }
        }

        [InterceptOut(nameof(Outgoing.Move))]
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
    }
}
