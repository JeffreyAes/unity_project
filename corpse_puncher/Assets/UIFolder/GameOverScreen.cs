using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    // Start is called before the first frame update
    public void setUp()
    {
        Input.anyKey.Equals(false);
        Cursor.visible = true;
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        gameObject.SetActive(true);
    }

    public void RestartButton()
    {
        print("yooooooooooooooooooooo");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ExitButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
