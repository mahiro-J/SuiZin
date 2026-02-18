using UnityEngine;
using R3;
using Cysharp.Threading.Tasks;

namespace SuiZin.SandBox.ScreenNavi
{
    public class SenkeiPresenter:MonoBehaviour
    {
        private SenkeiModel _senkeiModel;
        [SerializeField] private SenkeiView senkeiView;
        [SerializeField] private string NextPage = "";
        
        async UniTaskVoid Start()
        {
            _senkeiModel = new SenkeiModel();
            
            senkeiView.OnOpenClicked
                .Subscribe(_ => OpenPage().Forget())
                .AddTo(this);
            
            senkeiView.OnCloseClicked
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
}