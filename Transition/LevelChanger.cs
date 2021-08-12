using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;

    private int levelToLoad;

    public bool nextScene = false;

    public int level;


    private void Update()
    {
        if (nextScene == true)
            FadeToNextLevel();
    }

    public void FadeToNextLevel()
    {
            FadeToLevel(level);
    }
public void FadeToLevel (int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        
        GameManager.instance.SaveState();
        SceneManager.LoadScene(levelToLoad);
    }
}
