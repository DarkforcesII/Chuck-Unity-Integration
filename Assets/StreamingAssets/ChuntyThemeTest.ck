TriOsc t => dac;
//0.0 => t.gain;
220.0 => float pitch1;
174.61 => float pitch2;


0.3 => t.gain;
    /*for (78 => int pitch; pitch < 53; pitch--)
    {
        Std.mtof(pitch) => t.freq;
        //0.3 => t.freq;
        //1.5 :: second => now;
        //Std.mtof(pitch) => t.freq; 
        25 :: ms => now;  
        <<< pitch >>>;
    }
    
    2 :: second => now;*/
    
while (pitch1 > 174.61)
{
    //pitch - 1.73 => t.freq;
    1.73 -=> pitch1 => t.freq;
    //pitch => t.freq;
    25 :: ms => now;
    <<< pitch1 >>>;
}

while (pitch2 < 349.23)
{
    
    //174.61 => pitch2;
    1.73 +=> pitch2 => t.freq;
    10 :: ms => now;
    <<< pitch2 >>>;
}