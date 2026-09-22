using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    //------------- Scene management -------------------- //
    public void PlayLevel()
    {
        SceneManager.LoadScene("PlayLevel");
    }
    public void QuitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                        Application.Quit();
        #endif
    }

    //--------------------------------------------------------------------------------//
}
