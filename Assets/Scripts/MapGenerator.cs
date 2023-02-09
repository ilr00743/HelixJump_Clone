using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private Circle _circlePrefab;
    [SerializeField] private Transform _cylinder;
    [SerializeField] private float _verticalDistance;
    [SerializeField, Min(10)] private int _circlesAmount;
    private List<Circle> _circles = new();


    [ContextMenu(nameof(SpawnCirclesEditor))]
    public void SpawnCirclesEditor()
    {
        SpawnCircles(_circlesAmount);
    }

    private void SpawnCircles(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Circle currentCircle;
            if (i == 0)
            {
                currentCircle = _circlePrefab.GenerateFinishCircle();
            }
            else if(i == amount - 1)
            {
                currentCircle = _circlePrefab.GenerateStartCircle();   
            }
            else
            {
                currentCircle = _circlePrefab.GenerateRandomCircle();
            }
            
            currentCircle.transform.SetParent(_cylinder);
            currentCircle.transform.position = new Vector3(0, i * _verticalDistance, 0);
            _circles.Add(currentCircle);
        }
    }

    public Vector3 GetLastCirclePosition()
    {
        return _circles[^1].transform.position;
    }
}