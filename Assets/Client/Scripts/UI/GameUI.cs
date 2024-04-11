using UnityEngine;
using UnityEngine.UIElements;

public class GameUI : UIToolcitController
{
    [SerializeField] private VisualTreeAsset _gameAsset;

    private VisualElement _gameUI;
    private Label score;
    private Label apples;

    protected override void Initialize()
    {
        _gameUI = _gameAsset.CloneTree();
    }

    public void InGame()
    {
        ResetContainer(_gameUI);
        score = _container.Q<Label>("Score");
        apples = _container.Q<Label>("Apples");
    }

    public void UpdateApples()
    {
        apples.text = Snake.Instance._emountApples.ToString();
    }
}
