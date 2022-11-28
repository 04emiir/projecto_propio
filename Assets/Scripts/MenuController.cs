using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {
    public Image[] flagsImages;
    public Image hudArrowIcon;
    private Vector3 initialHUDArrowPos;
    private Vector3 limitHUDArrowPos;
    public TextMeshProUGUI[] buttonsMenu;

    public string[] languagueArrays;
    [HideInInspector] public static string selectedLang;
    private static int currentLangIteration;
    private int limitLangIteration;

    private static string selectedScene;
    private string[] sceneArrays = { "GameScene", "ControlsScene", "CreditsScene", "ExitScene"};
    private static int currentSceneIteration;
    private int limitSceneIteration;

    private string[] engButtons = { "NEW GAME", "CONTROLS", "CREDITS", "EXIT" };
    private string[] espButtons = { "NUEVO JUEGO", "CONTROLES", "CREDITOS", "SALIR" };

    public AudioSource changeLang;
    public AudioSource changeScene;

    Dictionary<string, string[]> fullLanguages = new Dictionary<string, string[]>();

    private bool cooldown = false;

    // Start is called before the first frame update
    void Start()
    {
        initialHUDArrowPos = hudArrowIcon.transform.localPosition;
        limitHUDArrowPos = new Vector3(hudArrowIcon.transform.localPosition.x - 10f, hudArrowIcon.transform.localPosition.y, hudArrowIcon.transform.localPosition.z);

        fullLanguages.Add("esp", espButtons);
        fullLanguages.Add("eng", engButtons);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        GameObject ambientSound = GameObject.Find("AmbientSound");
        DontDestroyOnLoad(ambientSound);

        GameObject okSound = GameObject.Find("OkSound");
        DontDestroyOnLoad(okSound);

        GameObject changeSound = GameObject.Find("ChangeSound");
        DontDestroyOnLoad(changeSound);

        selectedLang = languagueArrays[currentLangIteration];
        limitLangIteration = languagueArrays.Length - 1;
        foreach (var flag in flagsImages) {
            flag.color = new Color(0.298f, 0.298f, 0.298f, 1);
        }
        flagsImages[currentLangIteration].color = new Color(1, 1, 1, 1);

        selectedScene = sceneArrays[currentSceneIteration];
        limitSceneIteration = sceneArrays.Length - 1;
        hudArrowIcon.transform.SetParent(buttonsMenu[currentSceneIteration].transform, false);
        selectedScene = sceneArrays[currentSceneIteration];

        var cont = 0;
        foreach (var singleButton in buttonsMenu) {
            singleButton.text = fullLanguages[selectedLang][cont++];
        }
    }

    public void LaunchScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    // Update is called once per frame
    void Update() {
        HUDArrowMovement();

        if (Input.GetKeyDown(KeyCode.Tab) && !cooldown) {
            cooldown = true;
            ChangeLanguage();
        }

        if (Input.GetKeyDown(KeyCode.W) && !cooldown) {
            cooldown = true;
            ChangeUpMenuScene();
        }
       

        if (Input.GetKeyDown(KeyCode.S) && !cooldown) {
            cooldown = true;
            ChangeDownMenuScene();
        }

        if (Input.GetKeyDown(KeyCode.J)) {
            if (selectedScene == "ExitScene") {
                Application.Quit();
            } else {
                changeLang.Play();
                var coroutine = Blink(hudArrowIcon);
                StartCoroutine(coroutine);
                var secondCoroutine = ChangeToScene(selectedScene);
                StartCoroutine(secondCoroutine);
            }
        }
    }

    private void ChangeLanguage() {
        changeLang.Play();
        if (currentLangIteration == limitLangIteration)
            currentLangIteration = 0;
        else
            currentLangIteration++;

        selectedLang = languagueArrays[currentLangIteration];
        foreach (var flag in flagsImages) {
            flag.color = new Color(0.298f, 0.298f, 0.298f, 1);
        }

        var coroutine = Blink(flagsImages[currentLangIteration]);
        StartCoroutine(coroutine);

        var cont = 0;
        foreach (var singleButton in buttonsMenu) {
            singleButton.text = fullLanguages[selectedLang][cont++];
        }

        StartCoroutine("InputDisabler");
    }

    private void HUDArrowMovement() {
        hudArrowIcon.transform.localPosition = new Vector3(Mathf.PingPong(Time.time * 25, initialHUDArrowPos.x - limitHUDArrowPos.x) + limitHUDArrowPos.x, hudArrowIcon.transform.localPosition.y, hudArrowIcon.transform.localPosition.z);
    }

    private void ChangeUpMenuScene() {
        changeScene.Play();
        if (currentSceneIteration == 0) {
            currentSceneIteration = sceneArrays.Length - 1;
        } else {
            currentSceneIteration--;
        }
        hudArrowIcon.transform.SetParent(buttonsMenu[currentSceneIteration].transform, false);
        selectedScene = sceneArrays[currentSceneIteration];
        StartCoroutine("InputDisabler");

    }
    private void ChangeDownMenuScene() {
        changeScene.Play();
        if (currentSceneIteration == limitSceneIteration) {
            currentSceneIteration = 0;
        } else {
            currentSceneIteration++;
        }
        hudArrowIcon.transform.SetParent(buttonsMenu[currentSceneIteration].transform, false);
        selectedScene = sceneArrays[currentSceneIteration];
        StartCoroutine("InputDisabler");
    }

    IEnumerator Blink(Image blinkingObject) {
        blinkingObject.color = new Color(1, 1, 1, 1);
        yield return new WaitForSeconds(0.05f);
        blinkingObject.color = new Color(1, 1, 1, 0);
        yield return new WaitForSeconds(0.05f);
        blinkingObject.color = new Color(1, 1, 1, 1);
        yield return new WaitForSeconds(0.05f);
        blinkingObject.color = new Color(1, 1, 1, 0);
        yield return new WaitForSeconds(0.05f);
        blinkingObject.color = new Color(1, 1, 1, 1);
        yield return new WaitForSeconds(0.05f);
        blinkingObject.color = new Color(1, 1, 1, 0);
        yield return new WaitForSeconds(0.05f);
        blinkingObject.color = new Color(1, 1, 1, 1);
    }

    IEnumerator InputDisabler() {
        // cant press anything
        yield return new WaitForSeconds(0.5f); //wait 
        cooldown = false;
    }

    IEnumerator ChangeToScene(string sceneToChangeTo) {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(sceneToChangeTo);
    }
}
