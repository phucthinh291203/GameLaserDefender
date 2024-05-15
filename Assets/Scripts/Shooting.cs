using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed =20f;
    [SerializeField] float projectileLifeTime = 2f;
    [SerializeField] float baseFiringRate = 0.2f;
    [SerializeField] bool useAI;
    [SerializeField] float firingRateVariance = 0f;
    [SerializeField] float minimumFiringRate = 0.1f;

    public bool isFiring;

    Coroutine continueFire;

    SoundEffect audioPlayer;

    void Awake()
    {
        audioPlayer = FindObjectOfType<SoundEffect>();
    }
    void Start()
    {
        if (useAI)
        {
            isFiring = true;
        }
    }
    void Update()
    {
        
          Fire(); 
    }

    void Fire()
    {
        if (isFiring && continueFire == null)
        {
            continueFire = StartCoroutine(ContinueShooting());
        }
        else if(!isFiring && continueFire != null)
        {
            StopCoroutine(continueFire);
            continueFire = null;
        }
    }

    IEnumerator ContinueShooting()
    {
        while (true)
        {
            GameObject instance = Instantiate(projectilePrefab,transform.position, Quaternion.identity);
            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = transform.up * projectileSpeed;
            }
            Destroy(instance,projectileLifeTime);

            float timeToNextProjectile = Random.Range(minimumFiringRate - baseFiringRate,
                                                        minimumFiringRate + baseFiringRate);

            timeToNextProjectile = Mathf.Clamp(timeToNextProjectile, minimumFiringRate,  float.MaxValue);
            audioPlayer.PlayAudio();

            yield return new WaitForSeconds(timeToNextProjectile);
        }
        
    }
}
