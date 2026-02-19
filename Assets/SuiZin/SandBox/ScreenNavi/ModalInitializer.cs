using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityScreenNavigator.Runtime.Core.Modal;


namespace SuiZin.SandBox.ScreenNavi
{
    public class ModalInitializer:MonoBehaviour
    {
        [SerializeField] private ModalContainer modalContainer;
        [SerializeField] private string firstModalName = "Modal1";
        async UniTaskVoid Start()
        {
            await InitializeApp();
        }

        private async UniTask InitializeApp()
        {
            var handle = modalContainer.Push(firstModalName,true);
            await handle.Task;
            Debug.Log($"{firstModalName} が表示されました！");
        }
    }
}