using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class FinishPanel : MonoBehaviour
    {
        [SerializeField] private FinishTrigger _finishTrigger;
        [SerializeField] private Image _panel;
        [SerializeField] private TMP_Text _text;

        private void Start()
        {
            _finishTrigger.Finished += OnFinished;
        }

        private void OnFinished()
        {
            Debug.Log("Finished");
            _panel.enabled = true;
            _text.enabled = true;
            if (SceneManager.GetActiveScene().buildIndex+1 > SceneManager.sceneCount)
            {
                SceneManager.LoadSceneAsync(0);

            }
            else
            {
                SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
            }

        }
    }
}