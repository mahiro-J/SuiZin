using System;
using R3;
using Cysharp.Threading.Tasks;
using UnityScreenNavigator.Runtime.Core.Page;
namespace SuiZin.SandBox.ScreenNavi
{
    public static class Router
    {
        private static PageContainer _pageContainer;
        public static async UniTask Push(string pageName)
        {
            await _pageContainer.Push(pageName, true).Task;
        }

        public static void Initialize(PageContainer pageContainer)
        {
            _pageContainer = pageContainer;
        }

        public static async UniTask Pop()
        {
            await _pageContainer.Pop(true);
        }
    }
}