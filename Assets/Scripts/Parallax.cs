using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float _lenght, _startPos;
    public GameObject cam;
    public float parallaxEffect;
    
    private void Start()
    {
        _startPos = transform.position.x;
        _lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    
    private void FixedUpdate()
    {
        var transformPosition = transform.position;
        var camTransformPosition = cam.transform.position.x;
        var temp = (camTransformPosition * (1 - parallaxEffect));
        var dist = (camTransformPosition * parallaxEffect);

        transform.position = new Vector3(_startPos + dist, transformPosition.y, transformPosition.z);

        if (temp > _startPos + _lenght) _startPos += _lenght;
        else if (temp < _startPos - _lenght) _startPos -= _lenght;
    }
}