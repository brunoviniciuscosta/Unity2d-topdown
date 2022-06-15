using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerAttk : MonoBehaviour
{
    [SerializeField] GameObject BulletPreFab;
    [SerializeField] GameObject SwordSlashPreFab;
    [SerializeField] Transform Gun;
    [SerializeField] Transform Hand;
    [SerializeField] float GunDamage;
    [SerializeField] float GunBPS;
    [SerializeField] float SlashSpeed;
    float GunDelay;
    float SlashDelay;
    bool CanFire = true;
    bool CanSlash = true;
    float BulletSpeed = 10f;
    float BulletDamage = 1f;
    float SlashDamage = 1f;


    private void Update()
    {
        FireDelay();
        if (Input.GetMouseButton(0) && CanFire)
        {
            Fire();
        }
        else if (Input.GetMouseButton(1) && CanSlash)
        {
            Slash();
        }
    }
    

    void Fire()
    {
        CanFire = false;
        float angle = AngleTowardsMouse(Gun.position);
        Quaternion rotation = Quaternion.Euler(new Vector3(0f, 0f, angle - 90f));

        BulletScript bullet = Instantiate(BulletPreFab, Gun.position, rotation).GetComponent<BulletScript>();
        bullet.BulletVelocity = BulletSpeed;
        bullet.BulletDamage = BulletDamage;
    }

    void Slash()
    {
        CanSlash = false;
        float angleSlash = AngleTowardsMouse(Hand.position);
        Quaternion rotationSlash = Quaternion.Euler(new Vector3(0f, 0f, angleSlash));

        SlashScript slash = Instantiate(SwordSlashPreFab, Hand.position, rotationSlash).GetComponent<SlashScript>();
        slash.SlashDamage = SlashDamage;
    }

    void FireDelay()
    {
        GunDelay += Time.deltaTime;
        SlashDelay += Time.deltaTime;
        if (GunDelay >= GunBPS)
        {
            GunDelay = 0f;
            CanFire = true;
        }
        else if (SlashDelay >= SlashSpeed)
        {
            SlashDelay = 0f;
            CanSlash = true;
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
