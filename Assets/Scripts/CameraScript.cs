using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Camera mainCam;
    Vector3 damp;
    [SerializeField] float cam_Speed;
    [SerializeField] float cam_Dist = -10;
    [SerializeField] float distFromScreen;
    private float horizontal;
    private float vertical;

    private float zoomMax = 80f;

    // Start is called before the first frame update
    void Start()
    {
        if (!mainCam) mainCam = Camera.main;
        mainCam.enabled = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        if (horizontal != 0 || vertical != 0) camBehavior();

        //Touch Input
        if(Input.touchCount == 2)
        {
            Touch touch = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            Vector2 touchIni = touch.position - touch.deltaPosition;
            Vector2 touch1Ini = touch1.position - touch1.deltaPosition;

            float prevPosition = (touchIni - touch1Ini).magnitude;
            float curPosition = (touch.position - touch1.position).magnitude;

            float zoomMag = curPosition - prevPosition;

            mainCam.orthographicSize = Mathf.Clamp(mainCam.orthographicSize - (zoomMag * 0.001f), 1, 9);
        }
    }
 
    public void camBehavior()
    {
        
        if (mainCam.transform.position.y <= 9 && mainCam.transform.position.y >= 2)
        {
            if (mainCam.transform.position.x >= -10 && mainCam.transform.position.x <= -2)
            {
                if (transform.position.z < -11 || transform.position.z > -9) transform.position = new Vector3(transform.position.x, transform.position.y, cam_Dist);
                transform.position = Vector3.SmoothDamp(transform.position, transform.position - (transform.forward - (transform.right * horizontal) - (transform.up * vertical) * distFromScreen), ref damp, cam_Speed);
            }
            else if (mainCam.transform.position.x < -10)
            {
                transform.position = new Vector3(-10, transform.position.y, cam_Dist);
            }
            else if (mainCam.transform.position.x > -2)
            {
                transform.position = new Vector3(-2f, transform.position.y, cam_Dist);
            }
        } else if (mainCam.transform.position.y > 9)
        {
            transform.position = new Vector3(transform.position.x, 9f, cam_Dist);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, 2, cam_Dist);

        }

       
    }

   
  
}
