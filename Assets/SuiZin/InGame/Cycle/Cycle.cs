using Cysharp.Threading.Tasks;
using R3;
using UnityEngine;
using System;
using System.Threading;

public class Cycle : MonoBehaviour
{
    [SerializeField] private CycleModel cycleModel;
    [SerializeField] private CycleView cycleView;
    private CancellationToken ct;

    async UniTask Start()
    {
        ct = destroyCancellationToken;
        cycleModel._isPlayerInRange
            .Skip(1)
            .SubscribeAwait(async (isInRange,ct) =>
            {
                if (isInRange)
                {
                    await cycleView.WaitModalTransition(ct);
                    await cycleView.ShowModal(ct);
                }
                else
                {
                    await cycleView.WaitModalTransition(ct);
                    await cycleView.HideModal(ct);
                }
            })
            .AddTo(this);
    }
    

}
