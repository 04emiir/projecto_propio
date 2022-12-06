using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float curretnTime;
    public TextMeshProUGUI textTimer;
    public GameObject timerScript;
    public GameObject timerCanvas;
    // Start is called before the first frame update
    void Start()
    {
        curretnTime = 0f;
        DontDestroyOnLoad(timerCanvas);
        DontDestroyOnLoad(timerScript);
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "MenuScene" || SceneManager.GetActiveScene().name == "CreditsScene") {
            // Destroy the gameobject this script is attached to
            Destroy(timerCanvas);
            Destroy(timerScript);
        } else {
            curretnTime += Time.deltaTime;
            int minutes = Mathf.FloorToInt(curretnTime / 60F);
            int seconds = Mathf.FloorToInt(curretnTime - minutes * 60);
            string niceTime = string.Format("{0:00}:{1:00}", minutes, seconds);
            textTimer.text = niceTime;
        }
    }
    

}
