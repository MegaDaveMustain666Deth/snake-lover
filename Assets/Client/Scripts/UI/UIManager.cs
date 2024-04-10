using UnityEngine;

public class UIManager : PersistentSingleton<UIManager>
{
    [SerializeField] private PauseUI _pause;
    public PauseUI Pause => _pause;
}
