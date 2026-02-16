using System;
using R3;
using UnityEngine;

public class TopPresenter : MonoBehaviour
{
    private TopModel topModel;
    [SerializeField] private TopView topView;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        topModel = new TopModel();
        topView.OnButtonClicked += OnButtonClicked;

        topView.OnIncrementClicked
            .Subscribe(_ => topModel.Increment())
            .AddTo(this);
        
        topModel.Count
            .Subscribe(currentCount => topView.UpdateCountText(currentCount))
            .AddTo(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnButtonClicked()
    {
        topModel.OnButtonClicked();
    }

    private void OnDestroy()
    {
        topView.OnButtonClicked -= OnButtonClicked;
    }
}
