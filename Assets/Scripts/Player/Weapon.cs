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
        IngameSoundManager _manager;
        if(_weaponCooldown > fireRate)
        {
            _weaponCooldown = 0;

            if(gameObject.tag == "Player")
            {
                _manager = gameObject.GetComponent<PlayerController>().manager;
                _manager.playAudio(_manager.sounds[0]);
            }
            else if(gameObject.tag == "Enemy")
            {
                _manager = gameObject.GetComponent<Enemy>().manager;
                _manager.playAudio(_manager.sounds[0]);
            }

            foreach (var spawnpoint in Bulletspawns)
            {
                Instantiate(laser, spawnpoint);
            }
        }
    }
}
