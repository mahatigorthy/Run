using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UIElements;

public class SphereMove : MonoBehaviour
{
    public bool bottom = true, rotate = false, isGrounded = false;
    Rigidbody rb;
    public Camera camera;
    private bool isCoolDown = false;
    private float coolDown = 1.8f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void RotateCam()
    {
        if (rotate)
        {
            if (camera.transform.eulerAngles.z > 180 && !bottom)
                rotate = false;
            else if (camera.transform.eulerAngles.z < 2 && bottom)
                rotate = false;
            else
                camera.transform.Rotate(0, 0, 1);
        }
    }

    void GravInvert() {
        if (bottom == true) //gravity normal
        {
            bottom = false;
            Physics.gravity = Vector3.up * 3;

        }
        else //inverted gravity
        {
            bottom = true;
            Physics.gravity = Vector3.down * 3;
        }
        rotate = true;
    }

    IEnumerator CoolDown()
    {
        isCoolDown = true;
        yield return new WaitForSeconds(coolDown);
        isCoolDown = false;
    }


    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.forward * Time.deltaTime * 2);
        if(gameObject.GetComponent<Rigidbody>().velocity.z < 3.5) {
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward);
        }

        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isCoolDown == false)
            {
                GravInvert();
                StartCoroutine(CoolDown());
            }
            
        }

        RotateCam();

        if(Input.GetKeyDown(KeyCode.UpArrow)) {
            if(isGrounded)
            {
                if(bottom = true) { gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 3.5f, ForceMode.Impulse); }
                else { gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 3.2f, ForceMode.Impulse); }
                isGrounded = false; 
            }
        }
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if(bottom == true && transform.position.x > -3.5f) {
                if (gameObject.GetComponent<Rigidbody>().velocity.z < 3.5)
                {
                    gameObject.GetComponent<Rigidbody>().AddForce(Vector3.left * 1.5f);
                }
            }
            else if(bottom == false && transform.position.x < 3.5f) {
                if (gameObject.GetComponent<Rigidbody>().velocity.z < 3.5)
                {
                    gameObject.GetComponent<Rigidbody>().AddForce(Vector3.right * 1.5f);
                }
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (bottom == true && transform.position.x < 3.5f) {
                if (gameObject.GetComponent<Rigidbody>().velocity.z < 3.5)
                {
                    gameObject.GetComponent<Rigidbody>().AddForce(Vector3.right * 1.5f);
                }
            }
            else if(bottom == false && transform.position.x > -3.5f) {
                if (gameObject.GetComponent<Rigidbody>().velocity.z < 3.5)
                {
                    gameObject.GetComponent<Rigidbody>().AddForce(Vector3.left * 1.5f);
                }
            }
        }

        if (transform.position.y > 5 || transform.position.y < -5)
        {
            GameOver(); 
        }


    }

    private void FixedUpdate()
    {
        //Debug.Log(rb.velocity + "");
    }

    public void GameOver() {
        rotate = true;
        bottom = false;
        RotateCam();
        GravInvert(); 
        Physics.gravity = Vector3.down * 3;
    }

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag.Equals("plane") || collision.gameObject.tag.Equals("planeTop"))
        {
            isGrounded = true;

        }
    }




    /*
     Debug.Log(gameObject.name); 
        if(other.gameObject.tag == "plane")
        {
            isGrounded = true; 
           
        }
    }*/


}
