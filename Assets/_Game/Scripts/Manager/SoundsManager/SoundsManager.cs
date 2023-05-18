using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : Singleton<SoundsManager>
{
    public List<AudioSource> audioSourceSFX = new List<AudioSource>();

    public void SFXMusic(string sfx)
    {
        for(int i = 0; i < audioSourceSFX.Count; i++)
        {
            if (audioSourceSFX[i].name == sfx)
            {
                Debug.Log("hihi");
                audioSourceSFX[i].Play();
            }
        }
    }
}
