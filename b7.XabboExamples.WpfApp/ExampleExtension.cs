using System;
using System.Text;
using System.Windows.Input;

using GalaSoft.MvvmLight.Command;

using Xabbo.Messages;
using Xabbo.Interceptor;
using Xabbo.GEarth;

namespace b7.XabboExamples.WpfApp
{
    public class ExampleExtension : GEarthExtension
    {
        /* Properties must be implemented with this pattern
         * in order to utilise the INotifyPropertyChanged interface,
         * which notifies the UI of changes to be reflected */

        private bool _manipulatePackets = false;
        public bool TestPacketManipulation
        {
            get => _manipulatePackets;
            set => Set(ref _manipulatePackets, value);
        }

        private bool _testPacketBlocking = false;
        public bool TestPacketBlocking
        {
            get => _testPacketBlocking;
            set => Set(ref _testPacketBlocking, value);
        }

        private StringBuilder _log = new();
        public string LogText
        {
            get => _log.ToString();
            set => Set(ref _log, new StringBuilder(value));
        }

        public ICommand TestPacketInjectionCommand { get; }

        public ExampleExtension(GEarthOptions options, int port)
            : base(options, port)
        {
            TestPacketInjectionCommand = new RelayCommand(TestPacketInjectionExecuted);
        }

        private void Log(string message)
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
                + $"         Host: {e.Host}\r\n"
                + $"         Port: {e.Port}\r\n"
                + $"       Client: {e.ClientType}\r\n"
                + $"      Version: {e.Version}\r\n"
                + $"     Messages: {e.MessagesPath}\r\n"
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

        private void TestPacketInjectionExecuted()
        {
            SendToClientAsync(In.Chat, 0, "Hello from the Xabbo.GEarth extension example!", 0, 0, 0, 0);
            Log($"Sent chat packet to client.");
        }

        [InterceptIn(nameof(Incoming.Chat), nameof(Incoming.Shout))]
        private void OnInterceptChat(InterceptArgs e)
        {
            // Changes incoming shout messages to upper-case,
            // and incoming chat messages to lower-case.
            if (TestPacketManipulation)
            {
                // Read a string after the first int (4 bytes) in the packet
                string message = e.Packet.ReadString(4);

                bool isShout = e.Packet.Header == In.Shout;
                Log($"Modifying incoming {(isShout ? "shout" : "chat")} packet: \"{message}\"");
                message = isShout ? message.ToUpper() : message.ToLower();

                // Replace the string after the first int in the packet
                e.Packet.ReplaceString(message, 4);
            }
        }

        [InterceptOut(nameof(Outgoing.Move))]
        private void OnInterceptMove(InterceptArgs e)
        {
            if (TestPacketBlocking)
            {
                e.Block();

                int x = e.Packet.ReadInt(),
                    y = e.Packet.ReadInt();

                Log($"Blocked move packet to ({x}, {y}).");
            }
        }
    }
}
