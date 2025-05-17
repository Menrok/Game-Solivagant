using Solivagant.Models.Characters;

namespace Solivagant.Models.Items;

public class Item
{
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public ItemType Type { get; set; }

    public int Damage { get; set; } = 0;
    public int Defense { get; set; } = 0;
    public int Healing { get; set; } = 0;

    public bool IsConsumable => Type == ItemType.Consumable;
    public Action<Player>? OnUse { get; set; }
}