using UnityEngine;
using UnityEditor;

public interface IWeapon
{
    float timeBetweenShots { get; set; }
    float effectsDisplayTime { get; set; }

    void Awake();
    void Update();
    void Shoot();
    void DisableEffects();
}