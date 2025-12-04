using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    
    // Start is called before the first frame update
    void Start()
    {
       

        
        //Стрельба не автоматическая. Нужно каждый раз нажимать на кнопку мыши для выстрела
        auto = false;
    }


    // Update is called once per frame
    


    protected override void OnShoot()
        {
            Vector3 rayStartPosition = new Vector3(Screen.width / 2, Screen.height / 2, 0);

            Vector3 fireDrift = new Vector3(Random.Range(-drift, drift), Random.Range(-drift, drift), Random.Range(-drift, drift));
            Ray ray = cam.GetComponent<Camera>().ScreenPointToRay(rayStartPosition + fireDrift);
            
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitEffect = Instantiate(particle, hit.point, hit.transform.rotation);
                Destroy(hitEffect, 1f);
                if(hit.collider.CompareTag("enemy"))
                {
                    //Число 10 можешь поменять на своё. Это урон, который наносит одна пуля
                    hit.collider.gameObject.GetComponent<Enemy>().ChangeHealth((int)damage);
                }

            }
        }
}
