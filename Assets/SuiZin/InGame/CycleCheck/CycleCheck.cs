using UnityEngine;
using R3;
using Cysharp.Threading.Tasks;
using SuiZin.Common;

public class CycleCheck : MonoBehaviour
{
    [SerializeField] CycleCheckView _view;
    CycleCheckModel _model;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _model = new CycleCheckModel();
        
        _view.OnCloseButtonPushed
            .Subscribe(_=>Router.PopPage().Forget())
            .AddTo(this);

        _view.OnDateNowChanged
            .Subscribe(date => _model.ChangeDateNow(date));
        
        _view.OnDateLimitChanged
            .Subscribe(date => _model.ChangeDateLimit(date));

        _model.dateNow
            .Subscribe(date => Debug.Log("Date:"+date));
        
        _model.dateLimit
            .Subscribe(date => Debug.Log("Limit"+date));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
