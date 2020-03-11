using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MyChuckScript : MonoBehaviour
{
    [SerializeField] AudioMixer MyChucK;
    private string SFX;

    // Start is called before the first frame update
    void Start()
    {
        SFX = "SFX";
        Chuck.Manager.Initialize(MyChucK, SFX);
        Chuck.Manager.RunCode(SFX, @"SinOsc s => dac;
0.4 => s.gain;

for (60 => int i; i < 80; i++)
{
    Std.mtof(i) => s.freq;
    40 :: ms => now;
}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
