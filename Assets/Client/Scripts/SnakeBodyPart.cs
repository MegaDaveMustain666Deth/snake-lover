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
        if(other.gameObject.CompareTag("Barrier") || other.gameObject.CompareTag("Snake"))
        {
            Snake.Instance.Body.Dead();
        }
    } 
}