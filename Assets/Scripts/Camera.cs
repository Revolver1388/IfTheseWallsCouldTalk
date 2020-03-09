using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Camera main;
    Vector3 damp;
    [SerializeField] float cam_Speed;
    [SerializeField] float cam_Dist = -10;
    [SerializeField] float distFromScreen;
    private float horizontal;
    private float vertical;

    private float zoom = 80f;

    // Start is called before the first frame update
    void Start()
    {
        
        if (!main) main = FindObjectOfType<Camera>();
        main.enabled = true;

     

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        if (horizontal != 0 || vertical != 0) camBehavior();
    }

    public void camBehavior()
    {
        
        if (main.transform.position.y <= 9 && main.transform.position.y >= 2)
        {
            if (main.transform.position.x >= -10 && main.transform.position.x <= -2)
            {
                if (transform.position.z < -11 || transform.position.z > -9) transform.position = new Vector3(transform.position.x, transform.position.y, cam_Dist);
                transform.position = Vector3.SmoothDamp(transform.position, transform.position - (transform.forward - (transform.right * horizontal) - (transform.up * vertical) * distFromScreen), ref damp, cam_Speed);
            }
            else if (main.transform.position.x < -10)
            {
                transform.position = new Vector3(-10, transform.position.y, cam_Dist);
            }
            else if (main.transform.position.x > -2)
            {
                transform.position = new Vector3(-2f, transform.position.y, cam_Dist);
            }
        } else if (main.transform.position.y > 9)
        {
            transform.position = new Vector3(transform.position.x, 9f, cam_Dist);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, 2, cam_Dist);

        }

       
    }

   
  
}
