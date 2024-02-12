using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewScene : MonoBehaviour
{

    public void LoadMod1Scene(string ApplePicker)
    {
        SceneManager.LoadScene(ApplePicker);
    }

    public void LoadMod2Scene(string MissionDemolition)
    {
        SceneManager.LoadScene(MissionDemolition);

    }
    public void LoadMod3Scene(string Prototype1)
    {
        SceneManager.LoadScene(Prototype1);

    }
}
