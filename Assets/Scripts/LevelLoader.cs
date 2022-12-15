using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    int currentIdex;
    // Start is called before the first frame update
    void Start()
    {
        currentIdex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Nextlevel()
    {
        SceneManager.LoadScene(currentIdex+1);
    }
    public void Reload()
    {
        SceneManager.LoadScene(currentIdex);
    }
    public void QuitButton()
    {
        Application.Quit();
    }
}
