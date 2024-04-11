using UnityEngine.InputSystem;
using UnityEngine;

public class InputSnakeHandler : MonoBehaviour
{
    private Input _input;

    public void Awake()
    {
        _input = new Input();
    }

    public void OnEnable()
    {
        _input.Enable();
    }

    public void OnDisable()
    {
        _input.Disable();
    }

    public void SubscribeSnake()
    {
        _input.Player.Up.started += OnLeft;
        _input.Player.Down.started += OnRight;
        _input.Player.Left.started += OnDown;
        _input.Player.Right.started += OnUp;
        _input.Player.Pause.started += OnOpenPause;
    }

    public void UnsubscribeSnake()
    {
        _input.Player.Up.started -= OnLeft;
        _input.Player.Down.started -= OnRight;
        _input.Player.Left.started -= OnDown;
        _input.Player.Right.started -= OnUp;
        _input.Player.Pause.started -= OnOpenPause;
    }

    private void OnUp(InputAction.CallbackContext context)
    {
        Snake.Instance.Movement.ChangeDirectionToUp();
    }

    private void OnDown(InputAction.CallbackContext context)
    {
        Snake.Instance.Movement.ChangeDirectionToDown();
    }

    private void OnLeft(InputAction.CallbackContext context)
    {
       Snake.Instance.Movement.ChangeDirectionToLeft();
    }

    private void OnRight(InputAction.CallbackContext context)
    {
        Snake.Instance.Movement.ChangeDirectionToRight();
    }

    private void OnOpenPause(InputAction.CallbackContext context)
    {
        UIManager.Instance.Pause.OpenPause();
    }
}