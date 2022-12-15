using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCount : MonoBehaviour
{
    public Text CoinCountText;
    public Text CoinText;
    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CoinCountText.text = count.ToString();
        CoinText.text = "Coins : " + count.ToString();
    }
    public void AddCount()
    {
        count++;
    }
}
