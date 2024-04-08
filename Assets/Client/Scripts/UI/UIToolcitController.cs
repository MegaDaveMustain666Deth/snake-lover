using UnityEngine;
using UnityEngine.UIElements;

public abstract class UIToolcitController : MonoBehaviour
{
    private VisualElement _doc;
    protected VisualElement _container;
    protected abstract void Initialize();
    private void OnEnable()
    {
        _doc = GetComponent<UIDocument>().rootVisualElement;
        _container = _doc.Q<VisualElement>("Container");
        Initialize();
    }
    protected abstract void Start();
    protected virtual void ResetContainer(VisualElement element)
    {
        _container.Clear();
        _container.Add(element);
    }
}
