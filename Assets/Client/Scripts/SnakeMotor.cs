using UnityEngine;

public class SnakeMotor : MonoBehaviour
{
    [SerializeField] private int _speed = 1;
    [SerializeField] private float _speedMultiplier = 1f;

    private float nextUpdate = 0f;
    private Vector2Int _direction;
    
    private void Start()
    {
        ChangeDirectionToUp();
    }

    private void Update()
    {
        
        if(_direction == Vector2Int.up ||  _direction == Vector2Int.down)
        {
            Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, transform.position.z), _speed * _speedMultiplier * Time.deltaTime);
        }
        if (Time.time < nextUpdate) {
            return;
        }

        Move();


        nextUpdate = Time.time + (1f / (_speed * _speedMultiplier));
    }

    private void Move()
    {
        Snake.Instance.Body.MoveBody(_direction);
    }

    public void ChangeDirectionToUp()
    {
        if(_direction != Vector2Int.down)
        {
            _direction = Vector2Int.up;
            Snake.Instance.Haed.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    public void ChangeDirectionToDown()
    {
        if(_direction != Vector2Int.up)
        {
            _direction = Vector2Int.down;
            Snake.Instance.Haed.transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }

    public void ChangeDirectionToLeft()
    {
        if(_direction != Vector2Int.right)
        {
            _direction = Vector2Int.left;
            Snake.Instance.Haed.transform.localRotation = Quaternion.Euler(0, -90, 0);
        }
    }

    public void ChangeDirectionToRight()
    {
        if(_direction != Vector2Int.left)
        {
            _direction = Vector2Int.right;
            Snake.Instance.Haed.transform.localRotation = Quaternion.Euler(0, 90, 0);
        }
    }
}