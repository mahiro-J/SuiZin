using UnityEngine;
using TMPro;
using UnityEngine.UI;
using R3;

public class CycleCheckView : MonoBehaviour
{
    [SerializeField] private Button closeButton;
    [SerializeField] private TMP_InputField dateNowIF;
    [SerializeField] private TMP_InputField dateLimitIF;

    public Observable<Unit> OnCloseButtonPushed => closeButton.OnClickAsObservable();
    public  Observable<string> OnDateNowChanged => dateNowIF.onValueChanged.AsObservable();
    public Observable<string> OnDateLimitChanged => dateLimitIF.onValueChanged.AsObservable();
    
    
}
