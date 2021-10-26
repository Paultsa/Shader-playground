using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    float rotateSpeed;
    [SerializeField]
    float movementSpeed;
    [SerializeField]
    float mouseSensitivity;
    [SerializeField]
    bool cameraMovementEnabled;
    [SerializeField]
    bool reversedRotate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!Cursor.visible)
        {
            int rotateDir = reversedRotate ? -1 : 1;
            transform.Rotate(-Input.GetAxis("Mouse Y") * mouseSensitivity * rotateDir, Input.GetAxis("Mouse X") * mouseSensitivity * rotateDir, 0);
            float eulerX = transform.localEulerAngles.x;
            if (cameraMovementEnabled)
            {
                int w = Input.GetKey(KeyCode.W) ? 1 : 0;
                int a = Input.GetKey(KeyCode.A) ? -1 : 0;
                int s = Input.GetKey(KeyCode.S) ? -1 : 0;
                int d = Input.GetKey(KeyCode.D) ? 1 : 0;
                int ctrl = Input.GetKey(KeyCode.LeftControl) ? -1 : 0;
                int space = Input.GetKey(KeyCode.Space) ? 1 : 0;

                float translateX = (a + d) * Time.deltaTime * movementSpeed;
                float translateY = (space + ctrl) * Time.deltaTime * movementSpeed;
                float translateZ = (w + s) * Time.deltaTime * movementSpeed;
                transform.Translate(new Vector3(translateX, translateY, translateZ));
            }
            if(Input.GetKey(KeyCode.Q))
            {
                transform.Rotate(0, 0, Time.deltaTime*rotateSpeed);
            }
            if(Input.GetKey(KeyCode.E))
            {
                transform.Rotate(0, 0, -Time.deltaTime*rotateSpeed);
            }
        }
        

        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            Cursor.visible = false;
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
        }

    }

    public void ChangeSensitivity(float sensitivity)
    {
        mouseSensitivity = sensitivity;
    }
}
