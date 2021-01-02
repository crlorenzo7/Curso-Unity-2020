using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackgroundX : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 initialPosition;
    [SerializeField]
    private float width;
    void Start()
    {
        initialPosition = transform.position;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        width = spriteRenderer.sprite.bounds.size.x * transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= (initialPosition.x - (width / 2)))
        {
            transform.position = initialPosition;
        }
    }


}


