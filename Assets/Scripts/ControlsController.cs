using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlsController : MonoBehaviour
{
    private string[] engButtons = { "SELECT / ACTION", "GO BACK / CANCEL", "MENU\nCONTROL", "PLAYER\nCONTROL" };
    private string[] espButtons = { "SELECCION / ACCION", "ATRAS / CANCELAR", "CONTROL MENU", "CONTROL JUGADOR" };
    public TextMeshProUGUI[] textControls;
    public AudioSource changeLang;

    Dictionary<string, string[]> fullLanguages = new Dictionary<string, string[]>();
    // Start is called before the first frame update
    void Start()
    {
        fullLanguages.Add("esp", espButtons);
        fullLanguages.Add("eng", engButtons);

        var cont = 0;
        foreach (var singleButton in textControls) {
            singleButton.text = fullLanguages[MenuController.selectedLang][cont++];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K)) {
            changeLang.Play();
            StartCoroutine("BackToMenu");
 
        }
    }

    IEnumerator BackToMenu() {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("MenuScene");
    }
}
