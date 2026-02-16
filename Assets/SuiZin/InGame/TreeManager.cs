using UnityEngine;

public class TreeManager : MonoBehaviour,MoveObjectInterface
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Move(Vector3 offset)
    {
        transform.position += offset;
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }

    public void ResetObject()
    {
        throw new System.NotImplementedException();
    }
}
