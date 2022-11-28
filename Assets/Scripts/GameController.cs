using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour{

    public Image hudArrowIcon;
    public GameObject canvas;
    private GameObject quitParent;
    private GameObject resumeParent;
    private string selectedPause;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        selectedPause = "resume";    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
            PauseGame();

        if (Input.GetKeyDown(KeyCode.W)) {
            selectedPause = "resume";
            hudArrowIcon.transform.SetParent(resumeParent.transform, false);
        }

        if (Input.GetKeyDown(KeyCode.S)) {
            selectedPause = "quit";
            hudArrowIcon.transform.SetParent(quitParent.transform, false);
        }

        if (Input.GetKeyDown(KeyCode.J) && canvas.activeSelf) {
            if (selectedPause == "resume") {
                PauseGame();
            } else {
                PauseGame();
                SceneManager.LoadScene("MenuScene");
            }
        }
        

    }

    public void PauseGame() {
        if (canvas.activeSelf) {
            canvas.SetActive(false);
            Time.timeScale = 1;
        } else {
            canvas.SetActive(true);
            Time.timeScale = 0;
            resumeParent = GameObject.Find("Resume");
            quitParent = GameObject.Find("Quit");
        }
    }

}
