using UnityEngine;

public class Snake : PersistentSingleton<Snake>
{
    [SerializeField] private SnakeMotor _movement;
    [SerializeField] private InputSnakeHandler _input;
    [SerializeField] private SnakeBodyPart _head;
    [SerializeField] private SnakeBody _body;
    [SerializeField] private GameUI _gameUI;
    
    public SnakeMotor Movement => _movement;
    public SnakeBodyPart Head => _head;
    public SnakeBody Body => _body;

    public int _emountApples;

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
        _emountApples++;
        _gameUI.UpdateApples();
    }
}
