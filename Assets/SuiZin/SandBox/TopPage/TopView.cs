using UnityEngine;
using UnityEngine.UI;
using System;
using R3;
using TMPro;

public class TopView : MonoBehaviour
{
    [SerializeField] private Button openButton;
    [SerializeField] private Button countButton;
    [SerializeField] private TextMeshProUGUI countText;
    public Observable<Unit> OnIncrementClicked => countButton.OnClickAsObservable();
    
    // ボタンが押されたことを外に伝えるための「窓口」
    public event Action OnButtonClicked;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        openButton.onClick.AddListener(() => OnButtonClicked?.Invoke());
    }

    // カウント表示を更新するメソッド
    public void UpdateCountText(int count)
    {
        countText.text = $"{count}";
    }
}
