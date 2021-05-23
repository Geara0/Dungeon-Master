using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveBehaviour : MonoBehaviour
{
    public List<GameObject> WaveList;
    
    public void TryInstantiateWave()
    {
        if (WaveList.Count > 0)
        {
            NewWave();
        }
        else if (!GameObject.Find("Enemy Prefab(Clone)") && !GameObject.Find("Enemy Container Prefab(Clone)"))
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