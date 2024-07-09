using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rhythm_ChapterManager : MonoBehaviour
{
    // 0. ½Ì±ÛÅæ Àû¿ë
    public static Rhythm_ChapterManager instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else { Destroy(gameObject); }
    }

    public bool BGMisPlaying;

    private void Start()
    {
        Rhythm_SoundManager.instance.PlayBGM("BGM");
        BGMisPlaying = true;
    }


}
