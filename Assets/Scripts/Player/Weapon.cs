using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform[] Bulletspawns;
    public float fireRate = 1f;
    private float _weaponCooldown = 0f;

    public Laser laser;

    private void Update()
    {
        _weaponCooldown += Time.deltaTime;
    }

    public void fireWeapon()
    {
        if(_weaponCooldown > fireRate)
        {
            _weaponCooldown = 0;

            foreach (var spawnpoint in Bulletspawns)
            {
                Instantiate(laser, spawnpoint);
            }
        }
    }
}
