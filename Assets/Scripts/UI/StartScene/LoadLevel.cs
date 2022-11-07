using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public void Load()
    {
        SceneManager.LoadScene(Convert.ToInt32(gameObject.name));
    }
}
