using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class FailPanel : MonoBehaviour
    {
        [SerializeField] private Ball _ball;
        [SerializeField] private Image _panel;
        [SerializeField] private TMP_Text _text;
        [SerializeField] private LevelController _levelController;

        private void OnEnable()
        {
            _ball.Failed += OnFailed;
        }

        private void OnFailed()
        {
            _panel.enabled = true;
            _text.enabled = true;
            _levelController.Restart();
        }
    }
}