using UnityEngine;
using UnityEditor;

public class GameManager : MonoBehaviour
{

    //---------------------------- Set the singletone ----------------------------// 
    public static GameManager instance;
    private void Awake()
    {
        if(GameManager.instance  != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            GameManager.instance = this;
        }
    }
    // ----------------------------------------------------------------------------------------------------------------//
    public void Win()
    {

    }

    public void Lose()
    {

    }

}
