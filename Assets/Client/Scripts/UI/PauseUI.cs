using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;


public class PauseUI : UIToolcitController
{
    [SerializeField] private VisualTreeAsset _pauseAsset;
    [SerializeField] private MenuUI _menu;

    private VisualElement _pause;
    private bool _onPause = false;

    protected override void Initialize()
    {
        _pause = _pauseAsset.CloneTree();
    }

    public void OpenPause()
    {
        if (_onPause == true)
        {
            ClosePause();
        }
        else
        {
            ResetContainer(_pause);
            Time.timeScale = 0;
            _onPause = true;

            Button _continue = _container.Q<Button>("Continue");
            Button _exitToMenu = _container.Q<Button>("ExitToMenu");

            _continue.clicked += () => ClosePause();
            _exitToMenu.clicked += () => ExitToMenu();
        }
    }

    private void ClosePause()
    {
        ResetContainer(null);
        Time.timeScale = 1;
        _onPause = false;
    }

    private void ExitToMenu()
    {
        ClosePause();
        Destroy(Snake.Instance.gameObject);
        SceneManager.LoadScene("Menu");
        _menu.OpenMenu();
    }
}
