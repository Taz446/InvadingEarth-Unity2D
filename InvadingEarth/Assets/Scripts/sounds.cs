using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sounds : MonoBehaviour
{
    private static sounds instance = null;

    public static AudioClip laser;
    static AudioSource laserSource;

    public static AudioClip explosion;
    static AudioSource explosionSource;

    public static AudioClip pickResources;
    static AudioSource pickResourcesSource;

    public static AudioClip buttonClick;
    static AudioSource buttonClickSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        if (instance == this) return;
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);

        laser = Resources.Load<AudioClip>("laser");
        laserSource = GetComponent<AudioSource>();

        explosion = Resources.Load<AudioClip>("explosion");
        explosionSource = GetComponent<AudioSource>();

        pickResources = Resources.Load<AudioClip>("pickResources");
        pickResourcesSource = GetComponent<AudioSource>();

        buttonClick = Resources.Load<AudioClip>("buttonClick");
        buttonClickSource = GetComponent<AudioSource>();
    }

    public static void playLaserSound(float f)
    {
        laserSource.PlayOneShot(laser, f);
    }

    public static void playExplosionSound()
    {
        explosionSource.PlayOneShot(explosion);
    }

    public static void playPickResourcesSound()
    {
        pickResourcesSource.PlayOneShot(pickResources);
    }

    public static void playButtonClickSound()
    {
        buttonClickSource.PlayOneShot(buttonClick);
    }
}
