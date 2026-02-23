using UnityEngine;
using R3;
using Cysharp.Threading.Tasks;
using UnityScreenNavigator.Runtime.Core.Modal;

public class ConfirmCycleCheck : MonoBehaviour
{
    [SerializeField] private ModalContainer modalContainer;
    [SerializeField] private string nextpageName;

    [SerializeField]private ConfirmCycleCheckView _view;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    async UniTask Start()
    {
        modalContainer = ModalContainer.Find("ModalContainer");
        _view.OnOpenButtonClicked
            .Subscribe(_=> OpenNextModal().Forget())
            .AddTo(this);
        
        _view.OnCloseButtonClicked
            .Subscribe(_ => CloseThisModal().Forget())
            .AddTo(this);
    }

    async UniTask OpenNextModal()
    {
        // var handle = modalContainer.Push(nextModalName, true);
        // await handle.Task;
    }

    async UniTask CloseThisModal()
    {
        // var handle = modalContainer.Pop(true);
        // await handle.Task;
    }
    
}
