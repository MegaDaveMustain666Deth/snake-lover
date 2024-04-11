using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private Transform _playerSpawnerPoint;

    private void Awake()
    {
        GameObject snake = Instantiate(SkinsManger.Instance.CurrentHead, _playerSpawnerPoint.position, Quaternion.Euler(0, 90, 0));
        Snake.Instance.Body.ChangeBodyPart(SkinsManger.Instance.CurrentBody);
    }
}