using Cysharp.Threading.Tasks;
using R3;
using UnityEngine;
using System;
using System.Threading;
using UnityScreenNavigator.Runtime.Core.Modal;

namespace SuiZin.InGame
{
    public class Cycle : MonoBehaviour
    {
        [SerializeField] private CycleModel cycleModel;
        [SerializeField] private CycleView cycleView;
        private CancellationToken ct;
        ModalContainer modalContainer;

        async UniTask Start()
        {
            ct = destroyCancellationToken;
            cycleModel._isPlayerInRange
                .Skip(1)
                .SubscribeAwait(async (isInRange,ct) =>
                {
                    if (isInRange)
                    {
                        await Router.WaitModalTransition();
                        await Router.PushModal(ResourceKeys.ConfirmCycleCheck,false);
                    }
                    else
                    {
                        await Router.WaitModalTransition();
                        await Router.PopModal(false);
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
