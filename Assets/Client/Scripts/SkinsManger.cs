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
}