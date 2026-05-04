using Cysharp.Threading.Tasks;
using R3;
using UnityEngine;
using SuiZin.Common;

namespace SuiZin.InGame
{
    public class Cycle : MonoBehaviour
    {
        [SerializeField] private CycleModel cycleModel;
        private bool _isConfirmModalOpened;

        async UniTask Start()
        {
            cycleModel._isPlayerInRange
                .Skip(1)
                .SubscribeAwait(async (isInRange,ct) =>
                {
                    if (isInRange)
                    {
                        if (_isConfirmModalOpened) return;
                        await Router.WaitModalTransition();
                        await Router.PushModal(ResourceKeys.ConfirmCycleCheck,false);
                        _isConfirmModalOpened = true;
                    }
                    else
                    {
                        if (!_isConfirmModalOpened) return;
                        await Router.WaitModalTransition();
                        await Router.PopModal(false);
                        _isConfirmModalOpened = false;
                    }
                })
                .AddTo(this);
        }
        
        // public async UniTask ShowModal(CancellationToken ct)
        // {
        //     if (modalContainer.Modals.Count > 0) return;
        //     await modalContainer.Push(modalName,false);
        // }
        //
        // public async UniTask HideModal(CancellationToken ct)
        // {
        //     if (modalContainer.Modals.Count == 0)
        //     {
        //         Debug.LogError("No modals to pop.");
        //         return;
        //     }
        //     await modalContainer.Pop(false);
        // }
        
        // public async UniTask WaitModalTransition(CancellationToken ct)
        // {
        //     await UniTask.WaitWhile(() => modalContainer.IsInTransition);
        // }
        

    }
    
}
