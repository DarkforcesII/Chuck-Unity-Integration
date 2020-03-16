using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    [SerializeField] AudioClip footstepsClip;
    private AudioSource FootstepSource;

    [SerializeField] float pitchMin, pitchMax;

    // Start is called before the first frame update
    void Start()
    {
        FootstepSource = GetComponent<AudioSource>();
        FootstepSource.clip = footstepsClip;
        FootstepSource.pitch = Random.Range(pitchMin, pitchMax);
    }

    void PlayFootSteps()
    {
        FootstepSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
