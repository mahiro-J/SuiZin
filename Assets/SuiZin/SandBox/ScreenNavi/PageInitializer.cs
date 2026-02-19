using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityScreenNavigator.Runtime.Core.Page;

namespace SuiZin.SandBox.ScreenNavi
{
    public class PageInitializer : MonoBehaviour
    {
        [SerializeField] private PageContainer pageContainer;
        private async UniTaskVoid Start()
        {
            Router.Initialize(pageContainer);
            await InitializeApp();
        }

        private async UniTask InitializeApp()
        {
            var ct = this.GetCancellationTokenOnDestroy();
            await Router.Push("TopPage").AttachExternalCancellation(ct);
            Debug.Log("TopPage が表示されました！");
        }
    }
}
