using UnityEngine;

public class SnakeBodyPart : HitBox
{
    public Transform  NextPartSpawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out HitBox hitBox))
        {
            Snake.Instance.Body.Dead();
        }
    } 
}