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
    public float Score;
    public float MaxScore;

    private void Start()
    {
        AmountApples = 0;
        _input.SubscribeSnake();
    }

    private void OnDisable()
    {
        _input.UnsubscribeSnake();    
    }

    public void PlusApple()
    {
        AmountApples++;
    }

    private void Update()
    {
        if (Score >= MaxScore)
        {
            MaxScore = Score;
        }
        Score += Time.deltaTime * 2;
        UIManager.Instance.GameUi.UpdateAll();
    }
}
