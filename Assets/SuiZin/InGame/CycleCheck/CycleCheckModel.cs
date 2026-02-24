using R3;
using System;

public class CycleCheckModel
{
    public readonly ReactiveProperty<string> dateNow = new ReactiveProperty<string>();
    public readonly ReactiveProperty<string> dateLimit = new ReactiveProperty<string>();

    public void ChangeDateNow(string date)
    {
        dateNow.Value = date;
    }
    
    public void ChangeDateLimit(string date)
    {
        dateLimit.Value = date;
    }
}