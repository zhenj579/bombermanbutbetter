using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollingBackground : MonoBehaviour
{
    [SerializeField] private RawImage _img;
    [SerializeField] private float _x_speed;

    // Update is called once per frame
    void Update()
    {
            _img.uvRect = new Rect(_img.uvRect.position + new Vector2(_x_speed, 0) * Time.deltaTime, _img.uvRect.size);
    }
}
