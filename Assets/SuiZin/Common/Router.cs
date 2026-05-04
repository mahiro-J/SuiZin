using System;
using R3;
using Cysharp.Threading.Tasks;
using UnityScreenNavigator.Runtime.Core.Page;
using UnityScreenNavigator.Runtime.Core.Modal;
using UnityScreenNavigator.Runtime.Core.Sheet;
namespace SuiZin.Common
{
    public static class Router
    {
        private static PageContainer _pageContainer;
        private static ModalContainer _modalContainer;
        private static SheetContainer _sheetContainer;

        private static void EnsureContainers()
        {
            if (_modalContainer == null)
                _modalContainer = ModalContainer.Find(ContainerKeys.ModalContainer);
            if (_pageContainer == null)
                _pageContainer = PageContainer.Find(ContainerKeys.PageContainer);
        }
        
        public static void Initialize(PageContainer pageContainer, ModalContainer modalContainer/*, SheetContainer sheetContainer*/)
        {
            _pageContainer = pageContainer;
            _modalContainer = modalContainer;
            // _sheetContainer = sheetContainer;
        }

        
        public static async UniTask PushModal(string modalName,bool isAnimation = true)
        {
            EnsureContainers();
            if (_modalContainer == null) return;
            await _modalContainer.Push(modalName, isAnimation).Task;
        }


        public static async UniTask PopModal(bool isAnimation = true)
        {
            EnsureContainers();
            if (_modalContainer == null) return;
            if (_modalContainer.Modals.Count == 0) return;
            await _modalContainer.Pop(isAnimation).Task;
        }
        
        public static async UniTask PushPage(string pageName,bool isAnimation = true)
        {
            EnsureContainers();
            if (_pageContainer == null) return;
            await _pageContainer.Push(pageName, isAnimation).Task;
        }
        
        public static async UniTask PopPage(bool isAnimation = true)
        {
            EnsureContainers();
            if (_pageContainer == null) return;
            if (_pageContainer.Pages.Count == 0) return;
            await _pageContainer.Pop(isAnimation).Task;
        }
        
        public static async UniTask WaitModalTransition()
        {
            EnsureContainers();
            if (_modalContainer == null) return;
            await UniTask.WaitWhile(() => _modalContainer.IsInTransition);
        }
        
        public static async UniTask WaitPageTransition()
        {
            EnsureContainers();
            if (_pageContainer == null) return;
            await UniTask.WaitWhile(() => _pageContainer.IsInTransition);
        }
    }
}