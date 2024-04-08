using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Transform _followAt;
    [SerializeField] private float smooth = 5.0f;
    private Vector3 offset;

    void Start () 
    {        
        offset = transform.position - _followAt.transform.position;
    }
    void Update()
    {
        transform.position = Vector3.Lerp (transform.position, _followAt.position + offset, Time.deltaTime * smooth);
    } 

    void LateUpdate () 
    {        
        //transform.position = _followAt.transform.position + offset;
    }
}