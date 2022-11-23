using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Image[] flagsImages;
    public string[] languagueArrays;
    protected string selectedLang;
    private int currentIteration = 0;
    private int limitIteration;
    // Start is called before the first frame update
    void Start()
    {
        selectedLang = languagueArrays[currentIteration];
        limitIteration = languagueArrays.Length - 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void LaunchScene(string scene_name) {
        SceneManager.LoadScene(scene_name);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Tab)) {
            if (currentIteration == limitIteration)
                currentIteration = 0;
            else 
                currentIteration++;
            selectedLang = languagueArrays[currentIteration];
            foreach (var flag in flagsImages) {
                Debug.Log(flag.color);
                flag.color = new Color(0.298f, 0.298f, 0.298f, 1);
                Debug.Log(flag.color);
            }

            flagsImages[currentIteration].color = new Color(1, 1, 1, 1);
        }
    }
}
