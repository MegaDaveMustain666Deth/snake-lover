using UnityEngine;

public class SnakeBodyPart : HitBox
{
    public Transform  NextPartSpawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        TriggerEnter(other);
    } 

    protected virtual void TriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Snake"))
        {
            Snake.Instance.Body.Dead();
        }
        print(name);
        print(other.gameObject.name);
    }
}