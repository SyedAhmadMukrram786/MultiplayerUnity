using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class NetwordManagerUI : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] Button Serverbtn;
    [SerializeField] Button Clientbtn;
    [SerializeField] Button Hostbtn;
    // Start is called before the first frame update

    private void Awake()
    {
        Serverbtn.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartServer();
        });
        Clientbtn.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartClient();
        });
        Hostbtn.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartHost();
        });
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
