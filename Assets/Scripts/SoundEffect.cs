using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f, 1f)] float shootingVolume;
    [SerializeField] AudioClip damageClip;
    [SerializeField] [Range(0f, 1f)] float damageVolume;
    static SoundEffect instance;
    void Awake()
    {
        ManageSingleton();
    }

    public void ManageSingleton()
    {
        //int num = FindObjectsOfType<SoundEffect>().Length;
        //if(num > 1)
        if(instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }
    public void PlayAudio()
    {
        if (shootingClip != null)
        {
            AudioSource.PlayClipAtPoint(shootingClip, Camera.main.transform.position, shootingVolume);
        }
    }
    public void PlayAudioDamage()
    {
        if(damageClip != null)
        {
            AudioSource.PlayClipAtPoint(damageClip, Camera.main.transform.position, damageVolume);
        }
    }
}
