using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MenuUI : UIToolcitController
{
    [SerializeField] private VisualTreeAsset _MenuAsset;
    [SerializeField] private ShopUI _shop;
    [SerializeField] private GameUI _gameIU;

    private VisualElement _menu;

    protected override void Initialize()
    {
        _menu = _MenuAsset.CloneTree();
        OpenMenu();
    }

    public void OpenMenu()
    {
        ResetContainer(_menu);

        Button start = _container.Q<Button>("Play");
        Button shop = _container.Q<Button>("Shop");
        Button exit = _container.Q<Button>("Exit");

        Label MaxScore = _container.Q<Label>("MaxScore");
        Label apples = _container.Q<Label>("Apples");

        start.clicked += () =>
        {
            SceneManager.LoadScene("SampleScene");
            _gameIU.InGame();
        };
        shop.clicked += () => _shop.OpenShop();
        exit.clicked += () =>
        {
            Application.Quit();
        };
        MaxScore.text = Mathf.RoundToInt(PlayerPrefs.GetFloat("MaxScore")).ToString();
        apples.text = Mathf.RoundToInt(PlayerPrefs.GetFloat("")).ToString();
    }
}
