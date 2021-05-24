using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class WaveBehaviour : MonoBehaviour
{
    public List<GameObject> WaveList;
    public Text wavesCountText;
    public GameObject winScoreText;
    private int wavesCount;
    private GameObject score;
    
    public void TryInstantiateWave()
    {
        if (WaveList.Count > 0)
        {
            NewWave();
            wavesCount++;
            wavesCountText.text = "WAVE: " + wavesCount;
        }
        else if (!GameObject.Find("Alien Prefab(Clone)") && !GameObject.Find("Enemy Container Prefab(Clone)") &&
                 !GameObject.Find("Astronaut Prefab(Clone)"))
        {
            Debug.Log("WIN");
        }
    }
    
    private void NewWave()
    {
        Instantiate(WaveList[WaveList.Count - 1]);
        WaveList.RemoveAt(WaveList.Count - 1);
    }
}