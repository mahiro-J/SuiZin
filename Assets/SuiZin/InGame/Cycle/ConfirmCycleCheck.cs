using System.Collections.Specialized;
using UnityEngine;
using R3;
using Cysharp.Threading.Tasks;
using SuiZin.InGame;
using UnityScreenNavigator.Runtime.Core.Modal;

public class ConfirmCycleCheck : MonoBehaviour
{
    [SerializeField]private ConfirmCycleCheckView _view;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    async UniTask Start()
    {
        
        _view.OnOpenButtonClicked
            .SubscribeAwait(async (_view,ct)=>
            {
                await Router.PopModal(false);
                await Router.PushPage(ResourceKeys.CycleCheck);
                
            })  
            .AddTo(this);
        
        _view.OnCloseButtonClicked
            .Subscribe(_ => Router.PopModal().Forget())
            .AddTo(this);
    }
    
}
