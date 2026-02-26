using Cysharp.Threading.Tasks;
using UnityScreenNavigator.Runtime.Core.Page;
using UnityScreenNavigator.Runtime.Core.Modal;
using UnityScreenNavigator.Runtime.Core.Sheet;
using R3;   

namespace SuiZin.InGame
{
    public static class PlayerInputController
    {
        private static PageContainer _pageContainer;
        private static ModalContainer _modalContainer;

        private static readonly ReactiveProperty<bool> _isInputable = new(true);
        public static Observable<bool> IsInputable => _isInputable;

        
        public static void Initialize(PageContainer pageContainer,ModalContainer modalContainer)
        {
            _pageContainer = pageContainer;
            _modalContainer = modalContainer;

            Observable.Merge(
                    Observable.EveryValueChanged(pageContainer, x => x.Pages.Count).Select(_ => Unit.Default),
                    Observable.EveryValueChanged(modalContainer, y => y.Modals.Count).Select(_ => Unit.Default)
                )
                .Subscribe(_ =>
                {
                    var inputable = pageContainer.Pages.Count == 0 && modalContainer.Modals.Count == 0;
                    _isInputable.Value = inputable;
                });


        }
    }
    
}
