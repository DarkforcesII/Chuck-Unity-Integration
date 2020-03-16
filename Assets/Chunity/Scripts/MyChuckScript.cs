using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MyChuckScript : MonoBehaviour
{
    [SerializeField] AudioMixer MyChucK;
    private string SFX;
    private string Music;

    // Chunity Theme
    [SerializeField] AudioSource[] ChunitySources;
    [SerializeField] AudioClip[] ChunityClips;

    // Footsteps
    private AudioSource SFXSource;
    [SerializeField] float pitchMin, pitchMax;

    private void Awake()
    {
        SFXSource = this.gameObject.AddComponent<AudioSource>();

        // Assigning audio mixer child to each audio source
        AudioMixer MasterMixer = Resources.Load("MyChucK") as AudioMixer;
        string MixerGroup_2 = "SFX";
        SFXSource.outputAudioMixerGroup = MasterMixer.FindMatchingGroups(MixerGroup_2)[0];
    }

    // Start is called before the first frame update
    void Start()
    {
        // Chuck
        SFX = "SFX";
        Music = "Music";
        Chuck.Manager.Initialize(MyChucK, SFX);
        Chuck.Manager.Initialize(MyChucK, Music);
        PlayMusic();

        // Music
        ChunitySources[1] = GetComponent<AudioSource>();
        ChunitySources[1].clip = ChunityClips[0];
        ChunitySources[1].Play();
        StartCoroutine(ChunityLoop());

        // SFX
        SFXSource.clip = ChunityClips[2];
        SFXSource.pitch = Random.Range(pitchMin, pitchMax);
    }

    void ChuckAlgorithm_3()
    {
        Chuck.Manager.RunCode(Music, @"
        /*Creating a simple melody using sine waves*/
        SinOsc s => dac;
        // First note
        1.0 => s.gain;
        220 => s.freq;
        0.3::second => now;

        0.0 => s.gain;
        0.3::second => now;

        // Play another note, same pitch
        1.0 => s.gain;
        0.3::second => now;

        0.0 => s.gain;
        0.3::second => now;

        //Play 2 more notes
        329.63 => s.freq;
        0.3 => s.gain;
        0.3::second => now;

        0.0 => s.gain;
        0.3::second => now;

        0.3 => s.gain;
        0.3::second => now;

        0.0 => s.gain;
        0.3::second => now; ");
    }

    void PlayFootSteps()
    {
        SFXSource.Play();
    }

    void PlayMusic()
    {
        Chuck.Manager.RunCode(Music, @"// RiserOne
TriOsc s => dac;
0.0 => s.gain;
//RiserTwo
TriOsc t => Pan2 p => dac;
0.0 => t.gain;
1 => int RepeatCounter;

fun void RiserOne()
{
    0.3 => s.gain;
    for (53 => int pitch; pitch < 78; pitch++)
    {
        Std.mtof(pitch) => s.freq;
        25 :: ms => now;
        //<<< pitch >>>;
    }
}

fun void RiserTwo()
{   
    for (RepeatCounter; RepeatCounter < 1000; RepeatCounter++)
    {
        220.0 => float pitch1;
        174.61 => float pitch2;
        
        //<<< RepeatCounter >>>;
        Math.random2f(0.0, 10.0) :: second => now;
        
    while (pitch1 > 174.61)
    {
        Math.sin(now/500 :: ms) => p.pan;
        0.3 => t.gain;
        1.73 -=> pitch1 => t.freq;
        25 :: ms => now;
        //<<< pitch1 >>>;
    }
    
    while (pitch2 < 349.23)
    {
        Math.sin(now/500 :: ms) => p.pan;
        0.3 => t.gain;
        1.73 +=> pitch2 => t.freq;
        10 :: ms => now;
        //<<< pitch2 >>>;
    }
    
    for (1 => int counter; counter < 5; counter++)
    {
        Math.sin(now/500 :: ms) => p.pan;
        349.34 => t.freq;
        50 :: ms => now;
    }
    0.0 => t.gain;
    Math.random2f(10.0, 15) :: second => now;
        
    }
}

// 1st time
spork ~ RiserOne();
1 :: second => now;
// 2nd time
spork ~ RiserOne();
1 :: second => now;
// 3rd time
spork ~ RiserOne();
1 :: second => now;
// 4th time
spork ~ RiserOne();
1.0 :: second => now;
0.0 => s.gain;
// Loop algorithm
spork ~ RiserTwo(); 
1000 :: minute => now;


");
    }

    IEnumerator ChunityLoop()
    {
        yield return new WaitForSecondsRealtime(4f);
        ChunitySources[1].clip = ChunityClips[1];
        ChunitySources[1].Play();
        ChunitySources[1].loop = true;
    }

    private void OnApplicationQuit()
    {
        Chuck.Manager.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
