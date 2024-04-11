using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MenuUI : UIToolcitController
{
    [SerializeField] private VisualTreeAsset _MenuAsset;
    [SerializeField] private SaveManager _saveManager;
    [SerializeField] private ShopUI _shop;
    [SerializeField] private GameUI _gameIU;

    private VisualElement _menu;

    protected override void Initialize()
    {
        _menu = _MenuAsset.CloneTree();
        _saveManager.loadGameData();
        OpenMenu();
    }

    public void OpenMenu()
    {
        ResetContainer(_menu);

        Button start = _container.Q<Button>("Play");
        Button exit = _container.Q<Button>("Exit");

        start.clicked += () =>
        {
            SceneManager.LoadScene("SampleScene");
            _gameIU.InGame();
        };
        exit.clicked += () =>
        {
            _saveManager.SaveGame();
            Application.Quit();
        };
    }
}
