using UnityEngine;
using UnityEngine.UIElements;

public class ShopUI : UIToolcitController
{
    [SerializeField] private VisualTreeAsset _shopAsset;
    [SerializeField] private MenuUI _menu;

    private VisualElement _shop;
    private int _amountApples;

    protected override void Initialize()
    {
        _shop = _shopAsset.CloneTree();
        
    }

    public void OpenShop()
    {
        ResetContainer(_shop);

        Button leave = _container.Q<Button>("Leave");

        leave.clicked += () => _menu.OpenMenu();

        Button GreenHead = _container.Q<Button>("GreenHead");
        Button RedHead = _container.Q<Button>("RedHead");
        Button BlueHead = _container.Q<Button>("BlueHead");
        Button YellowHead = _container.Q<Button>("YellowHead");
        Button OrangeHead = _container.Q<Button>("OrangeHead");
        Button PinkHead = _container.Q<Button>("PinkHead");

        Button GreenBody = _container.Q<Button>("GreenBody");
        Button RedBody = _container.Q<Button>("RedBody");
        Button BlueBody = _container.Q<Button>("BlueBody");
        Button YellowBody = _container.Q<Button>("YellowBody");
        Button OrangeBody = _container.Q<Button>("OrangeBody");
        Button PinkBody = _container.Q<Button>("PinkBody");

        GreenHead.clicked += () => ChangeHead(10);
        RedHead.clicked += () => ChangeHead(15);
        BlueHead.clicked += () => ChangeHead(25);
        YellowHead.clicked += () => ChangeHead(35);
        OrangeHead.clicked += () => ChangeHead(50);
        PinkHead.clicked += () => ChangeHead(70);

        GreenBody.clicked += () => ChandeBody(10);
        RedBody.clicked += () => ChandeBody(15);
        BlueBody.clicked += () => ChandeBody(25);
        YellowBody.clicked += () => ChandeBody(35);
        OrangeBody.clicked += () => ChandeBody(50);
        PinkBody.clicked += () => ChandeBody(70);
    }

    private void ChangeHead(int cost)
    {
        if (_amountApples < cost) return;
        SkinsManger.Instance.ChangeHead(cost);
    }

    private void ChandeBody(int cost)
    {
        if (_amountApples < cost) return;
        SkinsManger.Instance.ChangeBody(cost);
    }

    private void UpdateApples()
    {
        Label apples = _container.Q<Label>("Apples");
        do
        {
            apples.text = _amountApples.ToString();
        }
        while (_amountApples >= 0);
    }
}
