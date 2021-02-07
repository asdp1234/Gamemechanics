using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookaround : MonoBehaviour
{
    float mouseX, mouseY;
    public float mousesensitivity = 100;

    public Transform pbody;

    float xrote;
    [SerializeField]
    float rotemax = 0;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {



        mouseX = Input.GetAxis("Mouse X") * mousesensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mousesensitivity * Time.deltaTime;

        //rotemax = 90;

        xrote -= mouseY;
        xrote = Mathf.Clamp(xrote, (rotemax * -1), rotemax);
        transform.localRotation = Quaternion.Euler(xrote, 0, 0);
        pbody.Rotate(Vector3.up * mouseX);
    }
}
