using Solivagant.Models.Items;

namespace Solivagant.Models.Characters;

public class Player
{
    public string Name { get; set; } = "Solivagant";

    public int Health { get; set; } = 100;
    public int MaxHealth { get; set; } = 100;

    public int MinDamage { get; set; } = 2;
    public int MaxDamage { get; set; } = 5;

    public int InventoryCapacity { get; set; } = 10;
    public List<Item> Inventory { get; set; } = new();

    public Item? Weapon { get; set; }
    public Item? Shield { get; set; }
    public Item? Helmet { get; set; }
    public Item? Armor { get; set; }
    public Item? Boots { get; set; }
    public Item? Gloves { get; set; }
    public Item? Amulet { get; set; }
    public Item? Ring { get; set; }

    public void Equip(Item item)
    {
        switch (item.Type)
        {
            case ItemType.Weapon: Weapon = item; break;
            case ItemType.Helmet: Helmet = item; break;
            case ItemType.Armor: Armor = item; break;
            case ItemType.Boots: Boots = item; break;
            case ItemType.Gloves: Gloves = item; break;
            case ItemType.Shield: Shield = item; break;
            case ItemType.Amulet: Amulet = item; break;
            case ItemType.Ring: Ring = item; break;
        }
    }

    public bool AddItem(Item item)
    {
        if (Inventory.Count >= InventoryCapacity)
            return false;

        Inventory.Add(item);
        return true;
    }

    public void RemoveItem(Item item) => Inventory.Remove(item);

    public void TakeDamage(int amount)
    {
        Health -= amount;
        if (Health < 0) Health = 0;
    }

    public int GetAttackDamage()
    {
        var rand = new Random();
        int baseDamage = rand.Next(MinDamage, MaxDamage + 1);
        int weaponDamage = Weapon?.Damage ?? 0;
        int strengthBonus = GetSkill("Strength")?.Level ?? 0;

        return baseDamage + weaponDamage + strengthBonus;
    }

    public void Heal(int amount)
    {
        Health += amount;
        if (Health > MaxHealth) Health = MaxHealth;
    }


    public List<Skill> Skills { get; set; } = new()
    {
        new Skill { Name = "Strength" },
        new Skill { Name = "Combat" },
        new Skill { Name = "Trade" },
        new Skill { Name = "Rhetoric" },
        new Skill { Name = "Alchemy" },
        new Skill { Name = "Exploration" }
    };

    public Skill? GetSkill(string name) => Skills.FirstOrDefault(s => s.Name == name);
}