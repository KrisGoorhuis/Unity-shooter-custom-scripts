//using UnityEngine;
//using System.Linq;

//public class PlayerShooting : MonoBehaviour
//{
//    //public int damagePerShot = 20;
//    //public float timeBetweenBullets = 0.15f;
//    //public float range = 100f;
//    //int penetrationPotentialDefault = 3;
//    //float effectsDisplayTime = 0.2f;
//    //Ray shootRay = new Ray();

//    //float timer;
//    //int shootableMask;
//    //IWeapon currentWeapon;

//    //RaycastHit shootHit;
//    //ParticleSystem gunParticles;
//    //LineRenderer gunLine;
//    //AudioSource gunAudio;
//    //Light gunLight;

//    //int equippedWeapon;


//    //void Awake()
//    //{
//    //    shootableMask = LayerMask.GetMask("Shootable");
//    //    gunParticles = GetComponent<ParticleSystem>();
//    //    gunLine = GetComponent<LineRenderer>();
//    //    gunAudio = GetComponent<AudioSource>();
//    //    gunLight = GetComponent<Light>();
//    //    currentWeapon = GetComponent<IWeapon>();
//    //}


//    //void Update ()
//    //{
//    //    for (int i = 1; i <= weapons.Length; i++)
//    //    {
//    //        if (Input.GetKeyDown("" + i))
//    //        {
//    //            equippedWeapon = i - 1;
//    //            changeWeapon(equippedWeapon);
//    //        }
//    //    }

//    //    WeaponManager weapon = GetComponent<WeaponManager> ();

//    //timer += Time.deltaTime;

//    //    if (Input.GetButton("Fire1") && timer >= weapon.timeBetweenBullets && Time.timeScale != 0)
//    //    {
//    //        weapon.Shoot();
//    //    }

//    //    if (timer >= weapon.timeBetweenBullets * weapon.effectsDisplayTime)
//    //    {
//    //        weapon.DisableEffects();
//    //    }
//    //}


//    //public void DisableEffects ()
//    //{
//    //    gunLine.enabled = false;
//    //    gunLight.enabled = false;
//    //}

//    //void ShootPenetration()
//    //{
//    //    timer = 0f;
//    //    int penetrationPotential = penetrationPotentialDefault;

//    //    gunAudio.Play();

//    //    gunLight.enabled = true;

//    //    gunParticles.Stop();
//    //    gunParticles.Play();

//    //    gunLine.enabled = true;
//    //    gunLine.SetPosition(0, transform.position);

//    //    shootRay.origin = transform.position;
//    //    shootRay.direction = transform.forward;

//    //    RaycastHit[] hits;
//    //    hits = Physics.RaycastAll(shootRay, range, shootableMask);

//    //    hits = hits.OrderBy(h => h.distance).ToArray();


//    //    for (int i = 0; i < hits.Length; i++)
//    //    {

//    //        if (penetrationPotential > 0)
//    //        {
//    //            RaycastHit hit = hits[i];
//    //            EnemyHealth enemy = hit.transform.gameObject.GetComponent<EnemyHealth>();
//    //            Vector3 gunLineEndpoint = hit.point;

//    //            if (enemy != null)
//    //            {
//    //                enemy.TakeDamage(damagePerShot, hits[i].point);
//    //                penetrationPotential -= enemy.penetrationThickness;

//    //                if (penetrationPotential <= 0)
//    //                {
//    //                    gunLineEndpoint = hit.point;
//    //                }
//    //            }
//    //            //Debug.Log($"Remaining penetration: {penetrationPotential}");
//    //            gunLine.SetPosition(1, gunLineEndpoint);
//    //        }
//    //    }

//    //}

//    //    public void changeWeapon(int num)
//    //    {
//    //        equippedWeapon = num;
//    //        for (int i = 0; i < weapons.Length; i++)
//    //        {
//    //            if (i == num)
//    //            {
//    //                weapons[i].SetActive(true);
//    //            }
//    //            else
//    //            {
//    //                weapons[i].SetActive(false);
//    //            }
//    //        }
//    //    }
//}
