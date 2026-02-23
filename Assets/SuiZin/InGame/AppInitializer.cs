using UnityEngine;
using Cysharp.Threading.Tasks;
using SuiZin.InGame;
using UnityScreenNavigator.Runtime.Core.Modal;
using UnityScreenNavigator.Runtime.Core.Page;
using UnityScreenNavigator.Runtime.Core.Sheet;

public class AppInitializer : MonoBehaviour
{
    [SerializeField] private ModalContainer modalContainer;
    [SerializeField] private PageContainer pageContainer;
    [SerializeField] private SheetContainer sheetContainer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InitializeApp();
    }

    private void InitializeApp()
    {
        Router.Initialize(pageContainer, modalContainer/*, SheetContainer sheetContainer*/);
    }
}
