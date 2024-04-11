using Unity.VisualScripting;
using UnityEngine;

public class HeadBodyPart : SnakeBodyPart
{
    protected override void TriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Apple"))
        {
            Snake.Instance.Body.AddBodyPart();
            Snake.Instance.PlusApple();
            Destroy(other.gameObject);
        }
        else if(other.gameObject.CompareTag("Barrier") || other.gameObject.CompareTag("Snake"))
        {
            Snake.Instance.Body.Dead();
        }
        print(name);
        print(other.gameObject.name);
    }
}