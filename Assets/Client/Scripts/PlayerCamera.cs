using UnityEngine;

public class PlayerCamera : MonoBehaviour
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
        transform.position = Vector3.Lerp(transform.position, _followAt.position + offset, Time.deltaTime * smooth);
    } 

    void LateUpdate () 
    {        
        Vector3 vec = new Vector3(transform.position.x, transform.position.y, _followAt.transform.position.z + offset.z);
        transform.position = Vector3.Lerp(vec, _followAt.position + offset, Time.deltaTime * smooth);
    }
}