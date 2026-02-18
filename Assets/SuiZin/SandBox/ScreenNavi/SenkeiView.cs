using UnityEngine;
using UnityEngine.UI;
using R3;
using Cysharp.Threading.Tasks;

namespace SuiZin.SandBox.ScreenNavi
{
    public class SenkeiView:MonoBehaviour
    {
        [SerializeField] private Button openButton;
        [SerializeField] private Button closeButton;
        
        public Observable<Unit> OnOpenClicked => openButton.OnClickAsObservable();
        public Observable<Unit> OnCloseClicked => closeButton.OnClickAsObservable();
        
    }
}