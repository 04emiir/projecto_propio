using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMusic : MonoBehaviour
{
    public AudioSource bgMusic;
    // Start is called before the first frame update
    void Start()
    {
        GameObject ambientSound = GameObject.Find("AmbientSound");
        GameObject okSound = GameObject.Find("OkSound");
        GameObject changeSound = GameObject.Find("ChangeSound");
        bgMusic.Play();
        DontDestroyOnLoad(bgMusic);
        Destroy(ambientSound);
        Destroy(okSound);
        Destroy(ambientSound);
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "CreditsScene") 
            Destroy(bgMusic);
    }
}
