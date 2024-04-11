using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;


public class PauseUI : UIToolcitController
{
    [SerializeField] private VisualTreeAsset _pauseAsset;
    [SerializeField] private MenuUI _menu;
    [SerializeField] private GameUI _gameUI;

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
        _gameUI.InGame();
        Time.timeScale = 1;
        _onPause = false;
    }

    private void ExitToMenu()
    {
        Time.timeScale = 1;
        _onPause = false;
        PlayerPrefs.SetFloat("MaxScore", Snake.Instance.MaxScore);
        int amountapples = PlayerPrefs.GetInt("Amount Apples");
        PlayerPrefs.SetInt("Amount Apples", Snake.Instance.AmountApples + amountapples);
        Destroy(Snake.Instance.gameObject);
        SceneManager.LoadScene("Menu");
        _menu.OpenMenu();
    }
}
