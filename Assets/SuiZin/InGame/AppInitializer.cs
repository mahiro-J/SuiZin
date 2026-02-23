using UnityEngine;
using Cysharp.Threading.Tasks;
using SuiZin.InGame;
using UnityScreenNavigator.Runtime.Core.Modal;
using UnityScreenNavigator.Runtime.Core.Page;
using UnityScreenNavigator.Runtime.Core.Sheet;

public class AppInitializer : MonoBehaviour
{
    ModalContainer modalContainer;
    PageContainer pageContainer;
    SheetContainer sheetContainer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InitializeApp();
    }

    private void InitializeApp()
    {
        modalContainer = ModalContainer.Find(ContainerKeys.ModalContainer);
        pageContainer = PageContainer.Find(ContainerKeys.PageContainer);
        // sheetContainer = SheetContainer.Find(ContainerKeys.SheetContainer);
        Router.Initialize(pageContainer, modalContainer/*, SheetContainer sheetContainer*/);
    }
}
