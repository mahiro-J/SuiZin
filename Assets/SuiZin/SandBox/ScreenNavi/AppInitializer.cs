using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityScreenNavigator.Runtime.Core.Page;

public class AppInitializer : MonoBehaviour
{
    // インスペクターで Scene 上の PageContainer をアタッチする
    [SerializeField] private PageContainer _pageContainer;
    
    // UnityのStartはUniTaskを返せる（async voidより安全）
    private async UniTaskVoid Start()
    {
        await InitializeApp();
    }

    private async UniTask InitializeApp()
    {
        // 1. もし PageContainer がどこにも登録されていなければ、このオブジェクトのものを使う
        // (PageContainer.Main は、最後に見つかった Container が自動でセットされます)
        
        // 2. 最初のページを表示する
        // 引数: ("Prefabの名前", アニメーションの有無)
        var handle = _pageContainer.Push("TopPage", false);

        // 3. 表示完了まで待機
        await handle.Task;

        Debug.Log("TopPage が表示されました！");
    }
}
