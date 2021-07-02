using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPause;
    public GameObject UIMenu;

    private void Start()
    {
        isPause = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Debug.Log("hello world");

            if (isPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        UIMenu.SetActive(true);
        Time.timeScale = 0f;
        isPause = true;
    }

    public void Resume()
    {
        UIMenu.SetActive(false);
        Time.timeScale = 1f;
        isPause = false;
    }

    public void MenuButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}