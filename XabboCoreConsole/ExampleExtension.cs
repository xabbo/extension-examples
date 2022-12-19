using Xabbo;
using Xabbo.Extension;
using Xabbo.GEarth;
using Xabbo.Core.Game;
using Xabbo.Core.GameData;
using Xabbo.Core.Events;
using Xabbo.Core.Extensions;

namespace XabboCoreConsole;

/// <summary>
/// A basic G-Earth extension that uses Xabbo.Core to track room state
/// and list each furni's name and count when entering a room.
/// </summary>
[Title("Xabbo Core Example"), Author("b7")]
public class ExampleExtension : GEarthExtension
{
    // The GameDataManager loads furni, figure, product and text data for a specified hotel.
    private readonly GameDataManager _gameData;
    // The RoomManager manages room, furni & entity state.
    private readonly RoomManager _room;

    public ExampleExtension(GEarthOptions options)
        : base(options)
    {
        _gameData = new GameDataManager();

        _room = new RoomManager(this);
        _room.Entered += OnEnteredRoom;
        _room.Left += OnLeftRoom;
    }

    protected override void OnInterceptorConnected()
    {
        base.OnInterceptorConnected();

        Console.WriteLine("Connected to G-Earth");
    }

    protected override async void OnConnected(GameConnectedEventArgs e)
    {
        base.OnConnected(e);

        Console.WriteLine($"Game connected ({e.Host}:{e.Port})");

        try
        {
            // Load game data for the current hotel
            await _gameData.LoadAsync(Hotel.FromGameHost(e.Host));
            Console.WriteLine("Game data loaded");

            // Initialize Xabbo Core extensions which enables various convenience methods
            // e.g. IItem.GetName() gets the name of an item from the supplied furni data
            XabboCoreExtensions.Initialize(_gameData.Furni!, _gameData.Texts!);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to load game data: {ex.Message}");
        }
    }

    protected override void OnDisconnected()
    {
        base.OnDisconnected();

        Console.WriteLine("Game disconnected");
    }

    protected override void OnInterceptorDisconnected(DisconnectedEventArgs e)
    {
        base.OnInterceptorDisconnected(e);

        Console.WriteLine("Disconnected from G-Earth");
    }

    private void OnEnteredRoom(object? sender, RoomEventArgs e)
    {
        Console.WriteLine($"Entered room: {e.Room.Name} (id:{e.Room.Id})");

        if (_gameData.Furni is null)
        {
            Console.WriteLine("Furni data is not loaded");
            return;
        }

        if (!e.Room.Furni.Any())
        {
            Console.WriteLine("No furni in room");
        }
        else
        {
            Console.WriteLine("- Furni list -");
            foreach (var furniGroup in e.Room.Furni
                .GroupBy(furni => furni.GetDescriptor())
                .OrderByDescending(group => group.Count()))
            {
                Console.WriteLine($"{furniGroup.Count(),6:N0}: {furniGroup.Key.GetName()}");
            }
        }
    }

    private void OnLeftRoom(object? sender, EventArgs e)
    {
        Console.WriteLine("Left room");
    }
}
