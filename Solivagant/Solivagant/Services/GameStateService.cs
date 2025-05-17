using System.Text.Json;
using Blazored.LocalStorage;
using Solivagant.Models.Characters;

namespace Solivagant.Services;

public class GameStateService
{
    private const string SaveKey = "SolivagantSave";

    private readonly ILocalStorageService _localStorage;

    public Player Player { get; private set; } = new();

    public event Action? OnChange;
    private void NotifyStateChanged() => OnChange?.Invoke();

    public GameStateService(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    public async Task InitializeAsync()
    {
        await LoadAsync();
        NotifyStateChanged();
    }

    public async Task SaveAsync()
    {
        await _localStorage.SetItemAsync(SaveKey, Player);
    }

    public async Task LoadAsync()
    {
        var saved = await _localStorage.GetItemAsync<Player>(SaveKey);
        Player = saved ?? new Player();
        NotifyStateChanged();
    }

    public async Task ResetAsync()
    {
        Player = new Player();
        await SaveAsync();
        NotifyStateChanged();
    }
}
