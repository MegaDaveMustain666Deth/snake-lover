using System.Collections.Generic;
using UnityEngine;

public class SnakeBody : MonoBehaviour
{
    [SerializeField] GameObject _bodyPart;

    public List<SnakeBodyPart> SnakeBodyParts = new List<SnakeBodyPart>();


    [ContextMenu("Add body part")]
    public void AddBodyPart()
    {
        GameObject part = Instantiate(_bodyPart, SnakeBodyParts[SnakeBodyParts.Count - 1].NextPartSpawnPoint.position, Quaternion.identity);
        SnakeBodyPart snakeBodyPart = part.GetComponent<SnakeBodyPart>();
        SnakeBodyParts.Add(snakeBodyPart);
    }

    public void MoveBody(Vector2Int direction)
    {
        for (int i = SnakeBodyParts.Count - 1; i > 0; i--) {
            SnakeBodyParts[i].transform.position = SnakeBodyParts[i - 1].transform.position;
        }

        int x = Mathf.RoundToInt(transform.position.x) + direction.x;
        int z = Mathf.RoundToInt(transform.position.z) + direction.y;
        transform.position = new Vector3(x, transform.position.y, z);
    }

    public void Dead()
    {
        for (int i = SnakeBodyParts.Count - 1; i > 0; i--) {
            Destroy(SnakeBodyParts[i].gameObject);
        }
    }
}