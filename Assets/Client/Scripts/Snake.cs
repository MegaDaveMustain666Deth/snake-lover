using UnityEngine;

public class Snake : PersistentSingleton<Snake>
{
    [SerializeField] private SnakeMotor _movement;
    [SerializeField] private InputSnakeHandler _input;
    [SerializeField] private SnakeBodyPart _head;
    [SerializeField] private SnakeBody _body;
    
    public SnakeMotor Movement => _movement;
    public SnakeBodyPart Haed => _head;
    public SnakeBody Body => _body;

    public int AmountApples;

    private void Start()
    {
        _input.SubscribeSnake();
    }

    private void OnDisable()
    {
        _input.UnsubscribeSnake();    
    }

    public void PlusApple()
    {
        AmountApples++;
        UIManager.Instance.Game.UpdateApples();
    }
}
