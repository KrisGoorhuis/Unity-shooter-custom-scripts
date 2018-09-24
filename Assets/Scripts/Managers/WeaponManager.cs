using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {

    public int equippedWeaponNumber;
    public GameObject[] weapons;

    IWeapon equippedWeaponScript;

    void Awake()
    {
        equippedWeaponNumber = 0;
        equippedWeaponScript = weapons[equippedWeaponNumber].GetComponent<IWeapon>(); 
    }

    void Update()
    {
        for (int i = 1; i <= weapons.Length; i++)
        {
            if (Input.GetKeyDown("" + i))
            {
                equippedWeaponNumber = i - 1;
                changeWeapon(equippedWeaponNumber);
                Debug.Log($"Choosing " + equippedWeaponScript.GetType());
            }
        }
        equippedWeaponScript.Update();
    }

    public void changeWeapon(int num)
    {
        equippedWeaponNumber = num;
        for (int i = 0; i < weapons.Length; i++)
        {
            if (i == num)
            {
                weapons[i].gameObject.SetActive(true);
                equippedWeaponScript = weapons[equippedWeaponNumber].GetComponent<IWeapon>();
            }
            else
            {
                weapons[i].gameObject.SetActive(false);
            }
        }
    }
}
