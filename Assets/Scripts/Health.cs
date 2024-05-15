using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
    
public class Health : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] ParticleSystem hitEffect;

    [SerializeField] bool applyCameraShake;
    [SerializeField] bool isPlayer;
    CameraShake cameraShake;
    SoundEffect damageSound;
    ScoreKeeping score;
    [SerializeField] int ScoreValue = 50;

    Slider healthBar;

    LevelManager levelManager;
     void Awake()
    {
        score = FindObjectOfType<ScoreKeeping>();
        if (score == null)
        {
            Debug.LogError("ScoreKeeping object not found!");
        }
        cameraShake = Camera.main.GetComponent<CameraShake>();
        damageSound = FindObjectOfType<SoundEffect>();
        levelManager = FindObjectOfType<LevelManager>();
    }

    void Update()
    {
        
    }
    public void Die()
    {
        if (isPlayer)
        {

            levelManager.LoadGameOver();
            
        }
        else
        {
            Debug.Log("tieu diet ");
            score.ModifyScore(ScoreValue);
        }
        Destroy(gameObject);
        Debug.Log(score.GetScore());
    }
    public int GetCurrentHealth()
    {
        return health;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer dealer = other.GetComponent<DamageDealer>();
        if (dealer != null)
        {
            TakeDamage(dealer.GetDamage());
            PlayHitEffect();
            PlayShakeCamera();
            dealer.Hit();
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (applyCameraShake)
        {
            damageSound.PlayAudioDamage();
        }
        if (health <= 0)
            Die();
    }

    public void PlayHitEffect()
    {
        if(hitEffect != null)
        {
            ParticleSystem instance = Instantiate(hitEffect, transform.position,Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }

    void PlayShakeCamera()
    {
        if(cameraShake != null && applyCameraShake)
        {
            cameraShake.Play();
        }
    }

    
}
