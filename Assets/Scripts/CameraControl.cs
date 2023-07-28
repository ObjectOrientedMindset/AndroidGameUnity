using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    /*First person player camera controller script
     Set up:
     _attach the script onto a camera and make the
      camera a child of player's body
     _Write Mouse X and Mouse Y in the editor indicating the mouse control being used
     _Mouse sensitivity can be adjusted in the editor
     _Attach the player's body in the player body tag in the editor*/


    [SerializeField] private string mouseXName, mouseYName;

    [SerializeField]
    private float mouseSentivity;

    [SerializeField]
    private Transform playerBody;

    private float xAxisClamp;
    private float yAxisClamp;

    private void Awake()
    {
        CursorLock();
        xAxisClamp = 0.0f;
        yAxisClamp = 0.0f;
    }

    //Lock the cursor to the middle of the screen
    private void CursorLock()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        RotateCamera();
    }

    private void RotateCamera()
    {
        float mouseX = Input.GetAxis(mouseXName) * mouseSentivity * Time.deltaTime;
        float mouseY = Input.GetAxis(mouseYName) * mouseSentivity * Time.deltaTime;

        xAxisClamp += mouseY;
        yAxisClamp += mouseX;

        //Controlling the camera rotation not further than 90 degrees left or right
        //also applied for the body's rotation
        if (xAxisClamp > 90.0f)
        {
            xAxisClamp = 90.0f;
            mouseY = 0.0f;
            AxisXClampDuringRotation(270.0f);
        }
        else if (xAxisClamp < -90.0f)
        {
            xAxisClamp = -90.0f;
            mouseY = 0.0f;
            AxisXClampDuringRotation(90.0f);
        }

        if (yAxisClamp > 90.0f)
        {
            yAxisClamp = 90.0f;
            mouseX = 0.0f;
        }
        else if (yAxisClamp < -90.0f)
        {
            yAxisClamp = -90.0f;
            mouseX = 0.0f;
        }

        //Rotating the camera and body
        transform.Rotate(Vector3.left * mouseY);
        playerBody.Rotate(Vector3.up * mouseX);

    }

    //Clamp the camera to the rotation using euler angles
    private void AxisXClampDuringRotation(float value)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }

    private void AxisYClampDuringRotation(float value)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.y = value;
        transform.eulerAngles = eulerRotation;
    }

}
