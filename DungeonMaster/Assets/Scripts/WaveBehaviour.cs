using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveBehaviour : MonoBehaviour
{
    public List<GameObject> WaveList;
    public Text wavesCountText;
    private int wavesCount;
    
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