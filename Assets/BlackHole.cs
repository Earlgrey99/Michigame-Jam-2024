using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    public float rotationMultiplier;

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Rigidbody2D>().SetRotation(this.GetComponent<Rigidbody2D>().rotation + rotationMultiplier);
    }
}
