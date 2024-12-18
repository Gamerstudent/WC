using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponControl : MonoBehaviour
{
    public Transform muzzle;

    public float range;

    public RectTransform CrossHair;

    public Camera mainCamera;

    bool somethingHit;

    RaycastHit hitInfo;

    public LayerMask ignoreLayer;

    public GameObject bullet;

    public float speed;

    public float scaleFactor;

    public float Damage;

    void SetCrossHair()
    {
        somethingHit = Physics.Raycast(muzzle.position, muzzle.forward,out hitInfo, range, ~ignoreLayer);
        if (somethingHit)
        {
            CrossHair.gameObject.SetActive(true);
            Vector3 hitPoint = hitInfo.point;
            Vector3 positionInCamera = mainCamera.WorldToScreenPoint(hitPoint);
            CrossHair.anchoredPosition = new Vector2(positionInCamera.x, positionInCamera.y);
            CrossHair.localScale = new Vector3(1, 1, 1) * scaleFactor / hitInfo.distance; 
        }
        else 
        {
            CrossHair.gameObject.SetActive(false);
        }
    }

    void Shoot() 
    {
        GameObject bulletclone = Instantiate(bullet, muzzle.position, Quaternion.identity);
        bulletclone.GetComponent<BulletBehavior>().SetVelocity(speed * muzzle.forward.normalized);
        bulletclone.GetComponent<BulletBehavior>().SetDamage(Damage);
    }

    
    void Update()
    {
        SetCrossHair();
        if (Input.GetMouseButtonDown(0) && CrossHair.gameObject.activeSelf) { Shoot(); }
    }
}
