using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingRocket : MonoBehaviour {

    // These values are initialized by whatever weapon is instantiating a rocket.
    public float flightSpeed;
    public float rotationSpeed;
    public int damagePerShot;
    public int explosionRadius;

    GameObject[] enemies;
    GameObject closestEnemy;
    ParticleSystem explosion;



	void Awake () {
        explosion = GetComponent<ParticleSystem>();
    }
	
	void Update () {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length > 0)
        {
            findTarget();
            seekTarget();
        }
        else
        {
            transform.position += transform.forward * Time.deltaTime * flightSpeed;
        }
    }

    void findTarget()
    {
        float shortestDistance = float.MaxValue;

        for (int i = 1; i < enemies.Length; i++)
        {
            float distance = Vector3.Distance(enemies[i].transform.position, transform.position);

            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                closestEnemy = enemies[i];
            }
        }
    }

    void seekTarget()
    {
        Vector3 enemyPos = closestEnemy.transform.position;
        Vector3 myPos = transform.position;
        Vector3 noseToTarget = enemyPos - myPos;
        noseToTarget.y = 0f;

        Quaternion newRotation = Quaternion.LookRotation(noseToTarget);

        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * rotationSpeed);

        transform.position += transform.forward * Time.deltaTime * flightSpeed;  
    }

    void OnTriggerEnter(Collider other)
    {
        explode();
    }

    void explode()
    {
        // Animate
        explosion.Play();

        // Hurt things
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, explosionRadius);

        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].tag == "Enemy") {
                EnemyHealth enemy = hitColliders[i].GetComponent<EnemyHealth>();
                enemy.TakeDamage(damagePerShot, enemy.transform.position);
            }
        }

        GameObject.Destroy(gameObject);
    }
}
