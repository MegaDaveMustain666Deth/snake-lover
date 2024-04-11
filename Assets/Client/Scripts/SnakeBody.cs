using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SnakeBody : MonoBehaviour
{
    private GameObject _bodyPart;

    public List<SnakeBodyPart> SnakeBodyParts = new List<SnakeBodyPart>();

    public void ChangeBodyPart(GameObject gameObject)
    {
        _bodyPart = gameObject;
    }


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
            SnakeBodyParts[i].transform.localRotation = SnakeBodyParts[i - 1].transform.localRotation;
        }

        int x = Mathf.RoundToInt(transform.position.x) + direction.x;
        int z = Mathf.RoundToInt(transform.position.z) + direction.y;
        transform.position = new Vector3(x, transform.position.y, z);
    }

    public void Dead()
    {
        for (int i = SnakeBodyParts.Count - 1; i > 0; i--) {
            StartCoroutine(DestroyBody(i));
        }
        Rigidbody rb = Snake.Instance.Haed.GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * 10, ForceMode.Impulse);
        StartCoroutine(CloseGame());
    }

    private IEnumerator DestroyBody(int i)
    {
        yield return new WaitForSeconds(1);
        Destroy(SnakeBodyParts[i].gameObject);
    }

    private IEnumerator CloseGame()
    {
        yield return new WaitForSeconds(2);
        PlayerPrefs.SetFloat("MaxScore", Snake.Instance.MaxScore);
        UIManager.Instance.Pause.ExitToMenu();
    }
}