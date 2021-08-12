using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GoldTracker : MonoBehaviour
{
    public TextMeshProUGUI goldCount;
    public void Start()
    {
       
    }
    public void Update()
    {
        goldCount.SetText("Gold: " + GameManager.instance.gold.ToString());
        
    }
}
