using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GlobalManager : MonoBehaviour
{
    public static GlobalManager Instance { get; private set; }
    public GameObject Player;
    public GameObject Gun;

    [Header("Types")]
    [SerializeReference] public List<ScriptableBulletBase> allBulletTypes;


    void Start()
    {
        Instance = this;
    }

    public ScriptableBulletBase GetBulletTypeAt(int index){
        return allBulletTypes[index];
    }
    
}
