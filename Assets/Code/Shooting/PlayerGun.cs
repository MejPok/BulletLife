using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;


public class PlayerGun : MonoBehaviour
{
    public Transform shootPoint;
    public InputActionReference shootToUse;
    public Vector2 shotPosition;
    public GameObject bulletPrefab;
    public LineTrajectory trajectory;
    public BulletCounter counter;
    public ChargeShooting CS;

    public UnityEvent<int> bulletShots;

    public bool chargeIsReady;

    [SerializeReference]public List<ScriptableBulletBase> shootingBehaviours;
    public ScriptableBulletBase currentBulletType;

    void Start()
    {

        shootToUse.action.canceled += Shoot;
        shootToUse.action.performed += Aim;
        CS = GetComponent<ChargeShooting>();

        counter = GetComponent<BulletCounter>();

        foreach(var type in GlobalManager.Instance.allBulletTypes){
            shootingBehaviours.Add(Instantiate(type));
        }
        
    }
    void Update()
    {
        shotPosition = shootToUse.action.ReadValue<Vector2>();
    }

    void Shoot(UnityEngine.InputSystem.InputAction.CallbackContext callback){
        currentBulletType.getRef(this);
        currentBulletType.CreateBullet(shotPosition);
        
    }

    void Aim(UnityEngine.InputSystem.InputAction.CallbackContext context){
        if(!counter.EnoughBulletsInMagazine()){
            trajectory.EndLine();
            return;
        }

        trajectory = transform.GetComponent<LineTrajectory>();
        trajectory.playerGun = this;
        
        trajectory.StartLine();
    }

    public GameObject InstantiateFromHere(GameObject prefab, Vector3 trans){
        return Instantiate(prefab, trans, Quaternion.identity);
    }
}
