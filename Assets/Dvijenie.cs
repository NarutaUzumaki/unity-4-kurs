using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dvijenie : MonoBehaviour
{
    public GameObject Cube;
    public Vector3 Direction;
    public float MaxDistance = 5;
    public float RotatePoint = 2;
    public float ScalePoint = 0.5f;
    public float MaxSize = 100;

    private Rigidbody _rigidbody;
    private void Awake()
    {
        Cube.transform.position = Vector3.zero;
    }

    private void Start()
    {
        _rigidbody = Cube.GetComponent<Rigidbody>();
        _rigidbody.velocity = Direction;
        StartCoroutine(Fixed());
    }

    private void Update()
    {
        RotateAndScale();
    }
    private IEnumerator Fixed()
    {
        var condition = new WaitUntil(() => MaxDistance <= Cube.transform.position.magnitude);
        while (true)
        {
            yield return condition;
            _rigidbody.velocity *= -1;
            yield return new WaitForFixedUpdate();
        }
    }

    private void RotateAndScale()
    {
        gameObject.transform.Rotate(0, gameObject.transform.rotation.y + RotatePoint, 0);
        
        if(gameObject.transform.localScale.y <= MaxSize)
        {
            gameObject.transform.localScale = new Vector3(1, gameObject.transform.localScale.y + ScalePoint, 1);
        }
        else if(gameObject.transform.localScale.y >= MaxSize)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
        
    }
}
