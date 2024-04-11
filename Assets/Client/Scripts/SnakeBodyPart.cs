using UnityEngine;

public class SnakeBodyPart : HitBox
{
    public Transform  NextPartSpawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Apple"))
        {
            Snake.Instance.Body.AddBodyPart();
            Destroy(other.gameObject);
        }
        else if(other.gameObject.CompareTag("Barrier"))
        {
            Snake.Instance.Body.Dead();
        }
    } 
}