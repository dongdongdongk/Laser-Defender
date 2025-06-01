using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] private AudioClip shootClip;
    [SerializeField][Range(0f, 1f)] float shootVolume = 1f;

    [Header("Damage")]
    [SerializeField] private AudioClip damageClip;
    [SerializeField][Range(0f, 1f)] float damageVolume = 1f;

    public void PlayShootingClip()
    {
        if (shootClip != null)
        {
            PlayClip(shootClip, shootVolume);
        }
    }

    public void PlayDamageClip()
    {
        if (damageClip != null)
        {
            PlayClip(damageClip, damageVolume);
        }
    }

    void PlayClip(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
        }
    }
}
