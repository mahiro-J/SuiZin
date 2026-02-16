using R3;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KaimonoView : MonoBehaviour
{
    [SerializeField] Button BuyButton;
    [SerializeField] TextMeshProUGUI MoneyText;
    [SerializeField] Button ResetButton;

    public Observable<Unit> OnBuy => BuyButton.OnClickAsObservable();
    public Observable<Unit> OnReset => ResetButton.OnClickAsObservable();

    public void UpdateMoneyDisplay(int money)
    {
        MoneyText.text = $"Money: {money}";
    }
    
    // KaimonoView.cs
    public void SetBuyButtonInteractable(bool interactable)
    {
        BuyButton.interactable = interactable;
    }
    
    
}
