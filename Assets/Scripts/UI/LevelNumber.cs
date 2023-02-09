using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelNumber : MonoBehaviour
{
    [SerializeField] private TMP_Text _index;

    private void Start()
    {
        _index.text = "Level " + (SceneManager.GetActiveScene().buildIndex + 1);
    }
}
