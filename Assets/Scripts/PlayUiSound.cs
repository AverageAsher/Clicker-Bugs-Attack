using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayUiSound : MonoBehaviour

{
    public AudioClip sound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound() { AudioManager.Instance.audioSource.PlayOneShot(sound); 
    }
}
