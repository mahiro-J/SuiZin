using UnityEngine;
using UnityEngine.UI;
using System;
using R3;
using TMPro;

public class TopView : MonoBehaviour
{
    [SerializeField] private Button openButton;
    [SerializeField] private Button closeButton;
    [SerializeField] private TextMeshProUGUI countText;
    [SerializeField] private TextMeshProUGUI pageNumText;
    // public Observable<Unit> OnIncrementClicked => countButton.OnClickAsObservable();
    public Observable<Unit> OnOpenClicked => openButton.OnClickAsObservable();
    public Observable<Unit> OnCloseClicked => closeButton.OnClickAsObservable();
    //
    // // カウント表示を更新するメソッド
    // public void UpdateCountText(int count) => countText.text = $"Count: {count}";
    // public void UpdatePageNum(int pageNum) => pageNumText.text = pageNum.ToString();
}
