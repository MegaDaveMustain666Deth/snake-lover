using UnityEngine;
using UnityEngine.UIElements;

public class GameUI : UIToolcitController
{
    [SerializeField] private VisualTreeAsset _gameAsset;

    private VisualElement _gameUI;
    private Label score;
    private Label apples;
    private Label MaxScore;

    protected override void Initialize()
    {
        _gameUI = _gameAsset.CloneTree();
    }

    public void InGame()
    {
        ResetContainer(_gameUI);
        score = _container.Q<Label>("Score");
        apples = _container.Q<Label>("Apples");
        MaxScore = _container.Q<Label>("MaxScore");
    }

    public void UpdateAll()
    {
        apples.text = Snake.Instance.AmountApples.ToString();
        score.text = Mathf.RoundToInt(Snake.Instance.Score).ToString();
        MaxScore.text = Mathf.RoundToInt(Snake.Instance.MaxScore).ToString();
    }
}
