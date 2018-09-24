using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AssaultRifle : MonoBehaviour, IWeapon {

    public float effectsDisplayTime {
        get { return .15f; }
        set { }
    }
    public float timeBetweenShots
    {
        get { return .15f; }
        set { }
    }

    public int damagePerShot = 20;
    public float range = 100f;
    int penetrationPotentialDefault = 3;

    float timer;
    int shootableMask;

    Ray shootRay = new Ray();

    Vector3 gunMuzzlePosition;
    RaycastHit shootHit;
    ParticleSystem gunParticles;
    LineRenderer gunLine;
    AudioSource gunAudio;
    Light gunLight;
    GameObject gunMuzzle;


    public void Awake()
    {
        shootableMask = LayerMask.GetMask("Shootable");
        gunParticles = gameObject.GetComponent<ParticleSystem>();
        gunLine = gameObject.GetComponent<LineRenderer>();
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

        if (timer >= timeBetweenShots * effectsDisplayTime)
        {
            DisableEffects();
        }
    }

    public void DisableEffects()
    {
        gunLine.enabled = false;
        gunLight.enabled = false;
    }

    public void Shoot()
    {
        timer = 0f;
        int penetrationPotential = penetrationPotentialDefault;

        gunAudio.Play();

        gunLight.enabled = true;

        gunParticles.Stop();
        gunParticles.Play();

        gunLine.enabled = true;
        gunLine.SetPosition(0, gunMuzzle.transform.position);

        shootRay.origin = gunMuzzle.transform.position;
        shootRay.direction = gunMuzzle.transform.forward;

        RaycastHit[] hits;
        hits = Physics.RaycastAll(shootRay, range, shootableMask);

        hits = hits.OrderBy(h => h.distance).ToArray();


        for (int i = 0; i < hits.Length; i++)
        {

            if (penetrationPotential > 0)
            {
                RaycastHit hit = hits[i];
                EnemyHealth enemy = hit.transform.gameObject.GetComponent<EnemyHealth>();
                Vector3 gunLineEndpoint = hit.point;

                if (enemy != null)
                {
                    enemy.TakeDamage(damagePerShot, hits[i].point);
                    penetrationPotential -= enemy.penetrationThickness;

                    if (penetrationPotential <= 0)
                    {
                        gunLineEndpoint = hit.point;
                    }
                }
                //Debug.Log($"Remaining penetration: {penetrationPotential}");
                gunLine.SetPosition(1, gunLineEndpoint);
            }
        }

    }
}
