using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : Pistol
{
    // Start is called before the first frame update
    void Start()
    {



        
        //Стрельба автоматическая, значит при зажатой клавише мыши оружие будет стрелять непрерывно учитывая задержку
        auto = true;
        ammoText.text = currentAmmoInMag + "/" + ammoInBackpack;
    }

   
}
