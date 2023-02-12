using System;
using UnityEngine;

public class Splash : MonoBehaviour
{
    private readonly Vector3 _offset = new Vector3(0, 0.05f, 0);
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private float _lifeTime;

    public void Generate(Vector3 position, Transform parent, Color ballColor)
    {
        _sprite.color = ballColor;
        var splash = Instantiate(gameObject, position, transform.rotation);
        splash.transform.SetParent(parent);
        splash.transform.position += _offset;
        Destroy(splash, _lifeTime);
    }
}