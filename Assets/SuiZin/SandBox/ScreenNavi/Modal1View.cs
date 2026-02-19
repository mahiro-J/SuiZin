using UnityEngine;
using R3;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;

public class Modal1View : MonoBehaviour
{
    [SerializeField] private Button openButton;
    [SerializeField] private Button closeButton;
    public Observable<Unit> OnOpenButtonClicked => openButton.OnClickAsObservable();
    public Observable<Unit> OnCloseButtonClicked => closeButton.OnClickAsObservable();

}
