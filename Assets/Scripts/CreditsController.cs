using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsController : MonoBehaviour
{
    private string[] engText = { "DIRECTION AND\n HISTORY BY", "PROGRAMMING BY", "ART AND ASSETS BY" };
    private string[] espText = { "DIRECCION E\n HISTORIA POR", "PROGRAMADO POR", "ARTE Y RECURSOS POR" };
    public TextMeshProUGUI[] textControls;
    public AudioSource changeLang;
    Dictionary<string, string[]> fullLanguages = new Dictionary<string, string[]>();
    // Start is called before the first frame update
    void Start()
    {
        fullLanguages.Add("esp", espText);
        fullLanguages.Add("eng", engText);

        var cont = 0;
        foreach (var singleText in textControls) {
            singleText.text = fullLanguages[MenuController.selectedLang][cont++];
        }

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.K)) {
            changeLang.Play();
            StartCoroutine("BackToMenu");

        }
    }

    IEnumerator BackToMenu() {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("MenuScene");
    }
}
