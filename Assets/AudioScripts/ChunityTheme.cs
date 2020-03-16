using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunityTheme : MonoBehaviour
{
    private AudioSource ChunitySource;
    [SerializeField] AudioClip[] ChunityClips;

    // Start is called before the first frame update
    void Start()
    {
        ChunitySource = GetComponent<AudioSource>();
        ChunitySource.clip = ChunityClips[0];
        ChunitySource.Play();
        StartCoroutine(ChunityLoop());
    }

    IEnumerator ChunityLoop()
    {
        yield return new WaitForSecondsRealtime(4f);
        ChunitySource.clip = ChunityClips[1];
        ChunitySource.Play();
        ChunitySource.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
