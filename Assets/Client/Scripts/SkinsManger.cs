using UnityEngine;

public class SkinsManger : PersistentSingleton<SkinsManger>
{
    [SerializeField] private GameObject GreenHead;
    [SerializeField] private GameObject RedHead;
    [SerializeField] private GameObject BlueHead;
    [SerializeField] private GameObject YellowHead;
    [SerializeField] private GameObject OrangeHead;
    [SerializeField] private GameObject PinkHead;
    [SerializeField] private GameObject GreenBody;
    [SerializeField] private GameObject RedBody;
    [SerializeField] private GameObject BlueBody;
    [SerializeField] private GameObject YellowBody;
    [SerializeField] private GameObject OrangeBody;
    [SerializeField] private GameObject PinkBody;
    [SerializeField] private GameObject StandartHead;
    [SerializeField] private GameObject StandartBody;

    public GameObject CurrentHead;
    public GameObject CurrentBody;


    public void ChangeBody(int index)
    {
        switch (index)
        {
            case 10:
            CurrentBody = GreenBody;
                break;
            case 15:
                break;
            case 25:
                break;
            case 35:
                break;
            case 50:
                break;
            case 70:
                break;
        }

    }

    public void ChangeHead(int index)
    {
        switch (index)
        {
            case 10:
                break;
            case 15:
                break;
            case 25:
                break;
            case 35:
                break;
            case 50:
                break;
            case 70:
                break;
        }
    }
    private void SaveSnake()
    {
       // SaveSnake.Save = new
    }
}