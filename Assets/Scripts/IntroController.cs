using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour
{
    public TextMeshProUGUI introText;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine("loadGame");
    }

    // Update is called once per frame
    void Update()
    {
        if (introText.color.a != 1f)
            introText.color = new Color(1f, 1f, 1f, introText.color.a + (0.1f * Time.deltaTime));
        else
            StartCoroutine("laodGame");
    }

    IEnumerator loadGame() { 
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("MenuScene");
    }

}
