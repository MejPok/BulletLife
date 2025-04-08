using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GlobalManager : MonoBehaviour
{
    public static GlobalManager Instance { get; private set; }
    public GameObject Player;
    public GameObject Gun;

    void Start()
    {
        Instance = this;
    }
    
}
