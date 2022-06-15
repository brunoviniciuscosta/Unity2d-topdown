using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyAttackGun : MonoBehaviour
{
    [SerializeField] GameObject EnemyBulletPrefab;
    [SerializeField] Transform Gun;
    [SerializeField] float GunDamage;
    [SerializeField] float GunBPS;
    float GunDelay;
    bool CanFire = true;


    private void Update()
    {
        if (Input.GetMouseButton(0) && CanFire)
        {
            Fire();
        }
        else
        {
            FireDelay();
        }
    }

    void Fire()
    {
        float BulletSpeed = 10f;
        float BulletDamage = 1f;
        float angle = AngleTowardsMouse(Gun.position);
        Quaternion rotation = Quaternion.Euler(new Vector3(0f, 0f, angle - 90f));

        EnemyBullet bullet = Instantiate(EnemyBulletPrefab, Gun.position, rotation).GetComponent<EnemyBullet>();
        bullet.BulletVelocity = BulletSpeed;
        bullet.BulletDamage = BulletDamage;
        CanFire = false;
    }
    void FireDelay()
    {
        if (GunDelay >= GunBPS)
        {
            GunDelay = 0f;
            CanFire = true;
        }
        else
        {
            GunDelay += Time.deltaTime;
        }
    }
    public static float AngleTowardsMouse(Vector3 pos)
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 5.23f;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(pos);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        return angle;
    }
}
