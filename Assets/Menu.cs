using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
 

public class Menu : MonoBehaviour {
    public static bool runing = false;
    public GameObject MenuObj;
    public Canvas quitMenu;

    public InputField minf;
    public InputField secf;
    public Toggle timerToggle;

    public Button start;
    public Button Quit;

	// Use this for initialization
	void Start () {
        quitMenu = quitMenu.GetComponent<Canvas>();
        start = start.GetComponent<Button>();
        Quit = Quit.GetComponent<Button>();

        timerToggle = timerToggle.GetComponent<Toggle>();
        minf = minf.GetComponent<InputField>();
        secf = secf.GetComponent<InputField>();

        quitMenu.enabled = false;
	}

    public void StartPress()
    {
        BoardManager.running = true;
        if (timerToggle.isOn)
        {
            Timer.counting = true;
            Timer.timeReset = Timer.timeInSec = int.Parse(minf.text) * 60 + int.Parse(secf.text);
        }

        start.enabled = false;
        Quit.enabled = false;
        quitMenu.enabled = false;
        timerToggle.enabled = minf.enabled = secf.enabled = false;
        MenuObj.SetActive(false);

    }

    public void QuitPress()
    {
        quitMenu.enabled = true;
        start.enabled = false;
        Quit.enabled = false;
    } 

    public void NoPress()
    {
        quitMenu.enabled = false;
        start.enabled = true;
        Quit.enabled = true;
    }
    public void YESpress()
    {
        Application.Quit();
    }

	// Update is called once per frame
	void Update () {
	
	}
}
