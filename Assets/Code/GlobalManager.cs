using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GlobalManager : MonoBehaviour
{
    public static GlobalManager globalManager { get; private set; }
    public GameObject Player;

    void Start()
    {
        globalManager = this;
    }
    
}
