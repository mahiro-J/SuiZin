using UnityEngine;
using R3;
using R3.Triggers;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]

public class WaterDeath : MonoBehaviour
{
     [SerializeField]private Rigidbody rb;
     [SerializeField]private BoxCollider seaCollider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] Button button;
    void Start()
    {
        seaCollider.OnTriggerEnterAsObservable()
            .Subscribe(_ => Death())
            .AddTo(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void Death()
    {
        Destroy(gameObject);
    }
}
