using R3;
public class KaimonoModel
{
    public readonly ReactiveProperty<int> Money = new(1000);

    public void Buy()
    {
        Money.Value -= 100;
    }
    
    public void Reset()
    {
        Money.Value = 1000;
    }
}
