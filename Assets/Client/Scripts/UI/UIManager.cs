using UnityEngine;

public class UIManager : PersistentSingleton<UIManager>
{
    [SerializeField] private PauseUI _pause;
    [SerializeField] private GameUI _gameUI;
    [SerializeField] private MenuUI _menu;

    public PauseUI Pause => _pause;
    public GameUI GameUi => _gameUI;
    public MenuUI Menu => _menu;
}
