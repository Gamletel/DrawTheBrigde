using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelsHandler : MonoBehaviour
{
    [SerializeField] private GameObject[] _levelBtns;
    [SerializeField] private Sprite _reachedLevelSprite;
    
    private void OnEnable()
    {
        if (PlayerPrefs.GetInt("bestLvl") < 1)
        {
            PlayerPrefs.SetInt("bestLvl", 1);
            Debug.Log("Установлено начальное значение уровня!");
        }

        UnlockLevels();
    }

    private void UnlockLevels()
    {
        for (int i = 0; i < PlayerPrefs.GetInt("bestLvl"); i++)
        {
            _levelBtns[i].GetComponent<Image>().sprite = _reachedLevelSprite;
            _levelBtns[i].GetComponent<Button>().interactable = true;
        }
    }
}
