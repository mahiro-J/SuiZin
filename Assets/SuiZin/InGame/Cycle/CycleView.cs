using UnityEngine;
using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine.UI;
using R3;
using UnityScreenNavigator.Runtime.Core.Modal;

public class CycleView : MonoBehaviour
{
    
    async UniTaskVoid Start()
    {

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

