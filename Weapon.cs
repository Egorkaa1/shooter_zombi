using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected TMP_Text ammoText;


    [SerializeField] protected float damage;
    [SerializeField] protected float fireRate;
    [SerializeField] protected float drift;
    [SerializeField] protected GameObject particle;
    [SerializeField] protected GameObject cam;

    [SerializeField] protected int maxAmmoInMag;
    [SerializeField] protected float reloadTime;
    [SerializeField] protected int ammoInBackpack;
    [SerializeField] AudioSource shootSound;
    [SerializeField] AudioClip bulletSound, noBulletSound, reload;


    protected int currentAmmoInMag;
    protected bool isReloading = false;
    protected bool auto = false;
    protected float timer = 0f;




    // Start is called before the first frame update
    void Start()
    {
        timer = fireRate;
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetMouseButton(0) && !isReloading) Shoot();
        if (Input.GetKeyDown(KeyCode.R) && currentAmmoInMag < maxAmmoInMag && ammoInBackpack > 0) Reload(); 
    }

    private void Reload()
    {
        if (isReloading) return;
        isReloading = true;
        ammoText.text = "Reloading...";
        shootSound.PlayOneShot(reload);
        Invoke("ReloadLogic", reloadTime);
    }

    private void ReloadLogic()
    {
        isReloading = false;
        int needAmmo = maxAmmoInMag - currentAmmoInMag;
        if (ammoInBackpack >= needAmmo)
        {
            ammoInBackpack -= needAmmo;
            currentAmmoInMag += needAmmo;
        }
        else
        {
            currentAmmoInMag += ammoInBackpack;
            ammoInBackpack = 0;
        }
        ammoText.text = currentAmmoInMag + "/" + ammoInBackpack;
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0) || auto)
        {
            if (timer >= fireRate)
            {

                
                if (currentAmmoInMag > 0)
                {
                    shootSound.PlayOneShot(bulletSound);
                    shootSound.pitch = Random.Range(1f, 1.5f);

                    currentAmmoInMag--;
                    ammoText.text = currentAmmoInMag + "/" + ammoInBackpack;
                    OnShoot();
                    timer = 0f;
                }
                else
                {
                     shootSound.PlayOneShot(noBulletSound);
                }
            }
        }
    }

    protected virtual void OnShoot(){}
}
