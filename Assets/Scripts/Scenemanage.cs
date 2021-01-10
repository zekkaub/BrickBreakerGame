using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Scenemanage : MonoBehaviour
{
    public void Loadscene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
