using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField] private Ball _ball;
        [SerializeField] private MapGenerator _mapGenerator;
        private Slider _slider;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
        }

        private void LateUpdate()
        {
            var currentProgress = Mathf.InverseLerp(_mapGenerator.GetStartCirclePosition().y, 
                _mapGenerator.GetFinishCirclePosition().y, _ball.transform.position.y);
            _slider.value = currentProgress;
        }
    }
}