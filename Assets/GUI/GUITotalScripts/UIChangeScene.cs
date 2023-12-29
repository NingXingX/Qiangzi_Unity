using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIChangeScene : MonoBehaviour
{
    public int sceneIndex;

    public void SwitchLevel(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
