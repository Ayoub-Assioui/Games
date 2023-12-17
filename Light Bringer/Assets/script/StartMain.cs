using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMain : MonoBehaviour
{
    public GoogleAdMobController admob;
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.Play("MainMenu");
        admob.RequestAndLoadInterstitialAd();
        admob.RequestAndLoadRewardedAd();
    }

 
}
