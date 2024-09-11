using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSceneChanger : MonoBehaviour
{
    public void Changescene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }


}
