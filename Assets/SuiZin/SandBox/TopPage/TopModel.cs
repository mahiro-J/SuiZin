using UnityEngine;
using R3;

public class TopModel 
{
    public readonly ReactiveProperty<int> Count = new(0);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Increment()
    {
        Count.Value++;
    }
    
    public void OnButtonClicked()
    {
        // ボタンが押されたときの処理
        Debug.Log("OnButtonClicked");
    }
}
