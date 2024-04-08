using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MenuUI : UIToolcitController
{
    [SerializeField] private VisualTreeAsset _MenuAsset;

    private VisualElement _menu;

    protected override void Start()
    {
        Initialize();
    }
    protected override void Initialize()
    {
        _menu = _MenuAsset.CloneTree();
        OpenMenu();
    }
    public void OpenMenu()
    {
        ResetContainer(_menu);

        Button start = _container.Q<Button>("Play");
        Button exit = _container.Q<Button>("Exit");

        start.clicked += () => SceneManager.LoadScene("SampleScene");
        exit.clicked += () => Application.Quit();
    }
}
