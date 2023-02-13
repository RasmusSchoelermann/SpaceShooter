using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class BackgroundRenderer : MonoBehaviour
{
    public Camera _cam;
    public SpriteRenderer _renderer;

    private void Start()
    {
        float worldSpaceHeight = _cam.orthographicSize * 2;
        float worldSpaceWidth = worldSpaceHeight * _cam.aspect;

        _renderer.size = new Vector2(worldSpaceWidth, worldSpaceHeight);
    }
}
