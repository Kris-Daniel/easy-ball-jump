using System.Collections;
using System.Collections.Generic;
using Helpers;
using UnityEngine;

public class MusicManager : MonoSingleton<MusicManager> {
    
    public AudioClip ballJump;
    public AudioClip gameOver;

    AudioSource _audioSource;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        _audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void PlayAmbientSound() {
        if(!_audioSource.isPlaying)
            _audioSource.Play();
    }

    public void PlayBallJumpSound() {
        AudioSource.PlayClipAtPoint(ballJump, PlatformPoolController.Instance.transform.position);
    }
    
    public void PlayGameOverSound() {
        gameObject.GetComponent<AudioSource>().Stop();
        AudioSource.PlayClipAtPoint(gameOver, PlatformPoolController.Instance.transform.position);
    }

}
