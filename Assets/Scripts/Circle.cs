using System.Collections.Generic;
using Extension;
using UnityEngine;

public class Circle : MonoBehaviour
{
    private const int FullAngle = 360;
    private const int _piecesAmount = 12;
    [SerializeField] private List<GameObject> _piecePrefabs;
    [SerializeField] private GameObject _finishPrefab;
    [SerializeField] private GameObject _startPrefab;

    [ContextMenu(nameof(GenerateRandomCircle))]
    public Circle GenerateRandomCircle()
    {
        var parent = Instantiate(this);
        for (int i = 0; i < _piecesAmount; i++)
        {
            var currentPiece = Instantiate(GetRandomPiece(), parent.transform,true);
            var rotation = currentPiece.transform.localRotation;

            rotation.eulerAngles = new Vector3(0, (FullAngle / _piecesAmount) * i, 0);
            currentPiece.transform.localRotation = rotation;
        }
        return parent;
    }

    public Circle GenerateFinishCircle()
    {
        var parent = Instantiate(this);
        Instantiate(_finishPrefab, parent.transform, true);
        return parent;
    }
    
    public Circle GenerateStartCircle()
    {
        var parent = Instantiate(this);
        Instantiate(_startPrefab, parent.transform, true);
        return parent;
    }

    private GameObject GetRandomPiece()
    {
        return _piecePrefabs.RandomItem();
    }
}