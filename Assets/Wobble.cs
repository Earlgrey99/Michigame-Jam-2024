using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wobble : MonoBehaviour
{
    public float rotationMultiplier;
    public float bounceSpeed;
    public float bounceScale;

    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Rigidbody2D>().SetRotation(this.GetComponent<Rigidbody2D>().rotation + rotationMultiplier);
        this.transform.position = new Vector3(startPos.x, startPos.y + (Mathf.Sin((Time.time) * bounceSpeed) * bounceScale),
            startPos.z);
    }
}
