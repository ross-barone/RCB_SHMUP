using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteInfo : MonoBehaviour
{
    [SerializeField] public float radius = .75f;

    [SerializeField] public Vector2 rectSize = Vector2.one;

    // Properties for Min and Max

    public SpriteRenderer renderer;

    [SerializeField] public bool isColliding = false;

    // Start is called before the first frame update
    void Start()
    {
        rectSize = new Vector2((renderer.bounds.max.x - renderer.bounds.min.x),(renderer.bounds.max.y - renderer.bounds.min.y));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
