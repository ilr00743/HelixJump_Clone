using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class FinishPanel : MonoBehaviour
    {
        [SerializeField] private Ball _ball;
        [SerializeField] private Image _panel;
        [SerializeField] private TMP_Text _text;
        [SerializeField] private LevelController _levelController;

        private void Start()
        {
            _ball.Finished += OnFinished;
        }

        private void OnFinished()
        {
            _panel.enabled = true;
            _text.enabled = true;
            Invoke(nameof(_levelController.LoadNextLevel), 2f);
        }
    }
}