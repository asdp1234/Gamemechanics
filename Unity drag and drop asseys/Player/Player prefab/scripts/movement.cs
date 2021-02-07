using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    Vector3 xyz;

    Vector3 move;

    public CharacterController controler;
    public float gravity = -9.81f;
    public Transform gc;
    public float grounddis= .4f;
    public LayerMask groundmask;
    [SerializeField]
    bool isground = true;

    public float jumph = 1.5f;
    [SerializeField]
    int jumpnum = 1;


    float speed = 12;
    [SerializeField]
    Vector3 val;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

       

        //isground = Physics.CheckSphere(gc.position, grounddis, groundmask);

        
        if (controler.isGrounded)
        {
            val.y = -2.0f;
            isground = true;
        }
        else
        {
            isground = false;
        }
        

        xyz.x = Input.GetAxis("Horizontal");
        xyz.z = Input.GetAxis("Vertical");

        move = transform.right * xyz.x + transform.forward * xyz.z;

        controler.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isground)
        {
            val.y = Mathf.Sqrt(jumph * -2 * gravity);
            isground = false;
        }


        val.y += gravity * Time.deltaTime;

        controler.Move(val * Time.deltaTime);

       
    }
}
