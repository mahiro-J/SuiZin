using UnityScreenNavigator.Runtime.Core.Page;
using UnityScreenNavigator.Runtime.Core.Modal;
using R3;   

namespace SuiZin.InGame
{
    public static class PlayerInputController
    {
        private static PageContainer _pageContainer;

        private static readonly ReactiveProperty<bool> _isInputable = new(true);
        public static Observable<bool> IsInputable => _isInputable;

        
        public static void Initialize(PageContainer pageContainer,ModalContainer modalContainer)
        {
            _pageContainer = pageContainer;
            _isInputable.Value = pageContainer.Pages.Count == 0;

            Observable.EveryValueChanged(pageContainer, x => x.Pages.Count)
                .Subscribe(_ =>
                {
                    _isInputable.Value = pageContainer.Pages.Count == 0;
                });


        }
    }
    
}
