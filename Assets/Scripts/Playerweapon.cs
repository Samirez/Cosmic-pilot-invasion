using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Playerweapon : MonoBehaviour
{
    bool isFiring = false;
    [SerializeField] GameObject[] lasers;
    [SerializeField] RectTransform crosshair;
    [SerializeField] Transform targetPoint;
    [SerializeField] float targetDistance = 100f;

    private void Update()
    {
        ProcessFiring();
        MoveCrosshair();
        MoveTargetPoint();
        AimLaser();
    }

    void Start()
    {
        Cursor.visible = false;
    }

    void ProcessFiring(){
        //ParticleSystem.EmissionModule emissionModule = laser.GetComponent<ParticleSystem>().emission;
        //emissionModule.enabled = isFiring;
        foreach (GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isFiring;
        }
    }


    private void OnFire(InputValue value)
    {
        isFiring = value.isPressed;

    }

    void MoveCrosshair()
    {
        crosshair.position = Input.mousePosition;
    }

    void MoveTargetPoint()
    {
        Vector3 targetPointPosition = new(Input.mousePosition.x, Input.mousePosition.y, targetDistance);
        targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPosition);
    }

    void AimLaser()
    {
        foreach (GameObject laser in lasers)
        {
            Vector3 fireDirection = targetPoint.position - transform.position;
            Quaternion rotationToTarget = Quaternion.LookRotation(fireDirection);
            laser.transform.rotation = rotationToTarget;
        }
    }
}
