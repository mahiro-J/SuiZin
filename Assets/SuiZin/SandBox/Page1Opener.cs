using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityScreenNavigator.Runtime.Core.Page;

public class Page1Opener : MonoBehaviour
{
    public PageContainer pageContainer;

    public Button openButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    IEnumerator OpenPage1()
    {
        

        // 「ExamplePage」に遷移する
        var handle = pageContainer.Push("Page1", true);

        // 遷移の終了を待機する
        yield return handle;
        //await handle.Task; // awaitでも待機できます
        //handle.OnTerminate += () => { }; // コールバックも使えます
    }

    void Start()
    {
        
        openButton.onClick.AddListener(() => StartCoroutine(OpenPage1()));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
