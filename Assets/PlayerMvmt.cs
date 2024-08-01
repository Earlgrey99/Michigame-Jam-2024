using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMvmt : MonoBehaviour
{
    public float speed;
    public float rotationMultiplier;
    public GameObject frontPoint;
    public Camera mainCamera;

    private float fuel;
    public float maxFuel;
    public float fuelConsumption;
    public float fuelContainerVal;
    public Slider fuelBar;

    public float blackHoleMultiplier;

    public GameManager gManager;

    // Start is called before the first frame update
    void Start()
    {
        fuel = maxFuel;
        fuelBar.value = maxFuel;
    }

    // Update is called once per frame
    void Update()
    {
        mainCamera.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, mainCamera.transform.position.z); //update camera position every frame

        if (Input.GetKey(KeyCode.LeftArrow)) //turn left
        {
            this.GetComponent<Rigidbody2D>().SetRotation(this.GetComponent<Rigidbody2D>().rotation + rotationMultiplier);
        }

        if (Input.GetKey(KeyCode.RightArrow)) //turn right
        {
            this.GetComponent<Rigidbody2D>().SetRotation(this.GetComponent<Rigidbody2D>().rotation - rotationMultiplier);
        }

        if (Input.GetKey(KeyCode.UpArrow)) //move in direction the transform is facing
        {
            Vector2 direction = new Vector2((frontPoint.transform.position.x - this.transform.position.x), (frontPoint.transform.position.y - this.transform.position.y)).normalized;
            this.GetComponent<Rigidbody2D>().velocity = direction * speed;
            fuel -= (Time.deltaTime * fuelConsumption);
            fuelBar.value = fuel;
        }
    }

    void OnTriggerEnter2D(Collider2D collider) //check for collisions
    {
        if(collider.gameObject.tag == "Fuel") //check if player collides with fuel container
        {
            Destroy(collider.gameObject); //destroy fuel container
            if (fuel + fuelContainerVal > maxFuel)
            {
                fuel = maxFuel;
            }
            else
            {
                fuel += fuelContainerVal;
            }
            fuelBar.value = fuel;
        }

        if(collider.gameObject.tag == "Memory")
        {
            gManager.TriggerMemory();
        }

    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Black Hole")
        {
            Vector2 direction = new Vector2((collider.gameObject.transform.position.x - this.transform.position.x), (collider.gameObject.transform.position.y - this.transform.position.y)).normalized;
            this.GetComponent<Rigidbody2D>().velocity += (direction * blackHoleMultiplier);
        }
    }
}
