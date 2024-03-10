using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class SoundEffects : MonoBehaviour
{
    public static SoundEffects instance;
    [SerializeField] AudioClip[] sounds;

    private void Awake()
    {
        instance = this;
    }
    
    public enum SoundFX
    {
        none,
        throws,
        hit,
        kill,
        score,
        bigScore
    }

    public void PlaySFX(SoundFX name)
    {
        if(name != SoundFX.none)
        { 
            AudioSource.PlayClipAtPoint(sounds[(int)name], GameObject.FindObjectOfType<AudioListener>().transform.position);
        }
        
    }
}
