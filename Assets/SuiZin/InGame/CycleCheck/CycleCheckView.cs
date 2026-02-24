using UnityEngine;
using UnityEngine.UI;
using R3;

public class CycleCheckView : MonoBehaviour
{
    [SerializeField] private Button closeButton;
    [SerializeField] private InputField dateNowIF;
    [SerializeField] private InputField dateLimitIF;

    private Observable<Unit> OnCloseButtonPushed => closeButton.OnClickAsObservable();
    private Observable<string> OnDateNowChanged => dateNowIF.OnValueChangedAsObservable();
    private Observable<string> OnDateLimitChanged => dateLimitIF.OnValueChangedAsObservable();
    
    
}
