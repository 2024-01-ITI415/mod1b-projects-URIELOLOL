using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject youWinText;
    public float dely;
    void Start()
    {
        youWinText.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            youWinText.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
