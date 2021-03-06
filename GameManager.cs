using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        if (GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);

    }

    //Resources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    //References
    public PlayerMovement player;
    // public weapon weapon...

    // Logic
    public int gold;
    public int experience;

    //Save State
    /*
     * INT preferredSkin
     * INT gold
     * INT experience
     * INT Weaponlevel
     * 
     * 
     * 
     */
    public void SaveState()
    {
        if (!PlayerPrefs.HasKey("SaveState"))
            return;

        string s = "";


        s += "0" + "|";
        s += gold.ToString() + "|";
        s += experience.ToString() + "|";
        s += "0";
        PlayerPrefs.SetString("SaveState", s);

        Debug.Log("SaveState");

    }
    public void LoadState(Scene s, LoadSceneMode mode)
    {
        if (!PlayerPrefs.HasKey("SaveState"))
            return;

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        // Change player skin

        gold = int.Parse(data[1]);
        experience = int.Parse(data[2]);

        Debug.Log("LoadState");
    }

}
