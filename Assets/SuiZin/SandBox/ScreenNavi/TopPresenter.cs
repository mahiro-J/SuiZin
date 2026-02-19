using System;
using R3;
using UnityEngine;
using UnityScreenNavigator.Runtime.Core.Page;
using Cysharp.Threading.Tasks;
using SuiZin.SandBox.ScreenNavi;

public class TopPresenter : MonoBehaviour
{
    private TopModel _topModel;
    [SerializeField] private TopView topView;
    [SerializeField] private string NextPage = "SenkeiPage";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    async UniTaskVoid Start()
    {
        _topModel = new TopModel();
        
        topView.OnOpenClicked
            .Subscribe(_ => OpenPage().Forget())
            .AddTo(this);
        
        topView.OnCloseClicked
            .Subscribe(_=> Pop().Forget())
            .AddTo(this);
    }
    
    public async UniTask OpenPage()
    {
        var ct = this.GetCancellationTokenOnDestroy();
        await Router.Push(NextPage).AttachExternalCancellation(ct);
        Debug.Log($"{NextPage} opened");
    }
    
    async UniTask Pop()
    {
        await Router.Pop();
        Debug.Log($"Page popped");
    }

    
    
}
