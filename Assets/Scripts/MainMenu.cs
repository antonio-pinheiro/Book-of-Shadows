using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update

    public Button newGameButton;
    public Button loadButton;
    public Button exitGameButton;
    public Button newGameSceneName;
    public Button creditsButton;
    public Button optionsButton;
    public Button backtoMenu;
    public GameObject loadGameMenu;
    private bool isMuted;
    
    
    void Start(){
        isMuted = PlayerPrefs.GetInt("Muted") == 1;
        AudioListener.pause = isMuted;
    }

    public void MutedPressed(){
        isMuted = !isMuted;
        AudioListener.pause = isMuted;
        PlayerPrefs.SetInt("Muted", isMuted ? 1 : 0);
    }

    public void NewGame(){
        
        SceneManager.LoadScene(1);
    }

    public void Options(){
        SceneManager.LoadScene("Options");
    }

    public void Credits(){
        SceneManager.LoadScene(3);
    }

    public void BackMenu(){
        SceneManager.LoadScene(0);
    }

    public void OpenLoadGameMenu(){
        loadGameMenu.SetActive(true);
    }
    
    public void ExitGame(){
        Application.Quit();
    }
}
