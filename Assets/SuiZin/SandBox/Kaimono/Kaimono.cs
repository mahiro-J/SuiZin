using UnityEngine;
using R3;

public class Kaimono : MonoBehaviour
{
    [SerializeField] private KaimonoView kaimonoView;
    KaimonoModel kaimonoModel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        kaimonoModel = new KaimonoModel();
        kaimonoView.OnBuy
            .Subscribe(_=>kaimonoModel.Buy())
            .AddTo(this);
        
        kaimonoModel.Money
            .Subscribe(currentMoney => kaimonoView.UpdateMoneyDisplay(currentMoney))
            .AddTo(this);
        
        kaimonoView.OnReset
            .Subscribe(_ => kaimonoModel.Reset())
            .AddTo(this);
        

        kaimonoModel.Money
            .Select(money => money >= 100)
            .Subscribe(canBuy => kaimonoView.SetBuyButtonInteractable(canBuy))
            .AddTo(this);
    }


}
