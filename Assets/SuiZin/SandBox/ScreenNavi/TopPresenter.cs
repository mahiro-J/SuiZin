using System;
using R3;
using UnityEngine;
using UnityScreenNavigator.Runtime.Core.Page;
using Cysharp.Threading.Tasks;

public class TopPresenter : MonoBehaviour
{
    private TopModel _topModel;
    [SerializeField] private TopView topView;
    PageContainer _pageContainer;

    [SerializeField] private string containerName = "TopPageContainer";
    [SerializeField] private string NextPage = "SenkeiPage";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    async UniTaskVoid Start()
    {
        _topModel = new TopModel();
        
        topView.OnOpenClicked
            .Subscribe(_ => OpenPage().Forget())
            .AddTo(this);
    }
    
    public async UniTask OpenPage()
    {
        _pageContainer = PageContainer.Find(containerName);
        
        var handle = _pageContainer.Push(NextPage, true);
        await handle.Task;
        Debug.Log($"{NextPage} opened");
    }
    
    
}
