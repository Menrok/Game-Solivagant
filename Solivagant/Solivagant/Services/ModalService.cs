namespace Solivagant.Services;

public class ModalService
{
    public bool IsAdventureModalOpen { get; private set; }
    public bool IsCharacterModalOpen { get; private set; }

    public event Action? OnChange;

    private void NotifyStateChanged() => OnChange?.Invoke();

    private void CloseAllModals()
    {
        IsAdventureModalOpen = false;
        IsCharacterModalOpen = false;
    }

    public void OpenAdventureModal()
    {
        CloseAllModals();
        IsAdventureModalOpen = true;
        NotifyStateChanged();
    }

    public void OpenCharacterModal()
    {
        CloseAllModals();
        IsCharacterModalOpen = true;
        NotifyStateChanged();
    }

    public void CloseModal()
    {
        CloseAllModals();
        NotifyStateChanged();
    }
}
