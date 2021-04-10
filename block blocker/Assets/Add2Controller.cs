using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class Add2Controller : MonoBehaviour, IUnityAdsListener 
{
    public string gameId = "4067351";
    public string videoId = "video";
    public bool testMode = true;

    public void OnUnityAdsDidError(string message)
    {

    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if(showResult == ShowResult.Finished)
        {
            //Debug.Log("ok");
            SceneManager.LoadScene("TwobarSelect");
        }
        else if(showResult == ShowResult.Skipped)
        {
            //Debug.Log("skipped");
            SceneManager.LoadScene("TwobarSelect");
        }
        else if(showResult == ShowResult.Failed)
        {
            //Debug.Log("bad");
        }

    }

    public void OnUnityAdsDidStart(string placementId)
    {

    }

    public void OnUnityAdsReady(string placementId)
    {

    }
	// Use this for initialization
	void Start () 
    {
		Advertisement.Initialize(gameId, testMode);
        Advertisement.AddListener(this);
	}
	// Update is called once per frame
	void Update () 
    {
		
	}

	public void ShowAd()
	{
		if (Advertisement.IsReady(videoId))
		{
			Advertisement.Show(videoId);
		}
    
    }

}