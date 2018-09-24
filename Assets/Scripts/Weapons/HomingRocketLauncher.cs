using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingRocketLauncher : MonoBehaviour, IWeapon {

    public HomingRocket homingRocket;

    public float flightSpeed = 5f;
    public float rotationSpeed = 5f;
    public int damagePerShot = 50;
    public int explosionRadius = 3;

    int shootableMask;
    float timer;

    GameObject gunMuzzle;
    Light gunLight;
    AudioSource gunAudio;
    ParticleSystem gunParticles;

    public float timeBetweenShots
    {
        get { return .1f; }
        set { }
    }
    public float effectsDisplayTime
    {
        get { return .5f; }
        set { }
    }



    public void Awake()
    {
        shootableMask = UnityEngine.LayerMask.GetMask("Shootable");
        gunParticles = gameObject.GetComponent<ParticleSystem>();
        gunAudio = gameObject.GetComponent<AudioSource>();
        gunMuzzle = GameObject.Find("GunMuzzle");
        gunLight = gameObject.GetComponent<Light>();

        gunLight.transform.position = gunMuzzle.transform.position;
    }

    public void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetButton("Fire1") && timer >= timeBetweenShots && Time.timeScale != 0)
        {
            Shoot();
        }
    }

    public void DisableEffects()
    {
        //Lower albedo over time before disabling
        //Nothing here!
    }

    public void Shoot()
    {
        timer = 0f;

        gunAudio.Play();

        //gunParticles

        spawnRocket();

    }

    HomingRocket spawnRocket()
    {
        HomingRocket rocket = Instantiate(homingRocket, gunMuzzle.transform.position, gunMuzzle.transform.rotation);
        rocket.flightSpeed = flightSpeed;
        rocket.rotationSpeed = rotationSpeed;
        rocket.damagePerShot = damagePerShot;
        rocket.explosionRadius = explosionRadius;

        return rocket;
    }
}
