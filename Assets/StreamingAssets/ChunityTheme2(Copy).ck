// RiserOne
TriOsc s => dac;
0.0 => s.gain;
//RiserTwo
TriOsc t => dac;
0.0 => t.gain;
220.0 => float pitch1;
174.61 => float pitch2;
1 => int RepeatCounter;


SndBuf2 ChunityTheme => dac;
me.dir() + "ChunityTheme2.wav" => ChunityTheme.read;
1.0 => ChunityTheme.rate;
0.0 => ChunityTheme.gain;

fun void RiserOne()
{
    0.3 => s.gain;
    for (53 => int pitch; pitch < 78; pitch++)
    {
        Std.mtof(pitch) => s.freq;
        25 :: ms => now;
        <<< pitch >>>;
    }
}

/*fun void RiserTwo()
{ 
    //Std.mtof(57) => t.freq;
    //0.3 => t.gain;
    57 => int pitch;
    0.3 => t.gain;
    while (pitch < 53)
    {
        //57 => int pitch;
        //Std.mtof(pitch) => t.freq;
        1 -=> pitch => Std.mtof(pitch) => t.freq;
        //0.3 => t.freq;
        //1.5 :: second => now;
        Std.mtof(pitch) => t.freq; 
        25 :: ms => now;  
        <<< pitch >>>;
    }
}*/

fun void RiserTwo()
{
    while (pitch1 > 174.61)
    {
        0.3 => t.gain;
        1.73 -=> pitch1 => t.freq;
        25 :: ms => now;
        <<< pitch1 >>>;
    }
    
    while (pitch2 < 349.23)
    {
        0.3 => t.gain;
        1.73 +=> pitch2 => t.freq;
        10 :: ms => now;
        <<< pitch2 >>>;
    }

    0.0 => t.gain;
}

fun void PlayChunityTheme()
{
    1.0 => ChunityTheme.gain; 
    0 => ChunityTheme.pos;
    1 => ChunityTheme.loop;
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
spork ~ PlayChunityTheme();
for (RepeatCounter; RepeatCounter < 1000; RepeatCounter++)
{
    <<< RepeatCounter >>>;
    Math.random2f(0.0, 10.0) :: second => now;
    spork ~ RiserTwo(); 
    Math.random2f(10.0, 30) :: second => now; 
}


