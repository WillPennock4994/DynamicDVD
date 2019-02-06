using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    private AudioSource audio;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        audio = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayAudio();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayAudio()
    {
        if (audio.isPlaying) return;
        audio.Play();
    }

    public void StopAudio()
    {
        audio.Stop();
    }
}
