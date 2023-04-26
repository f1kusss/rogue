using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class PlayGame : MonoBehaviour
{
    public Button playButton;


    public void Play()
    {
        SceneManager.LoadScene("Dungeon");
    }
}
