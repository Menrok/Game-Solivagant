namespace Solivagant.Models.Characters;

public class Skill
{
    public string Name { get; set; } = "";
    public int Level { get; set; } = 1;
    public float Progress { get; set; } = 0f;

    public void GainProgress(float amount)
    {
        Progress += amount;

        while (Progress >= 100f)
        {
            Progress -= 100f;
            Level++;
        }
    }
}
