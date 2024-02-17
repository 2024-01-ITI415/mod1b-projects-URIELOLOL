using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMissionDemolition : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadMod2Scene(string MissionDemolition)
    {
        SceneManager.LoadScene(MissionDemolition);

    }
}
