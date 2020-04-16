using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class charicterController : MonoBehaviour
{

    public Transform firstperson;
    public Transform cam;
    //public int health = 100;
    public float speed = 6.0F;
    public float setSpeed;
    public float horizontalSpeed = 2.0F;
    public float verticalSpeed = 2.0F;
    public int rotate = 6;
    public float jumpSpeed = 8.0F;
    public float setJumpSpeed;
    public float gravity = 20.0F;
    public bool isCrouching = false;
    public bool isSprinting = false;
    public float minimumY = -60F;
    public float maximumY = 60F;
    float rotationY;
    float rotationX;
    private Vector3 moveDirection = Vector3.zero;

    [SerializeField]
    private int multiplayerSceneIndex;

    private void Start()
    {
        setJumpSpeed = jumpSpeed;
        setSpeed = speed;
    }
    void Update()
    {
        // hide mouse cursor
        if (Input.GetButtonDown("Fire1"))
        {
            Screen.lockCursor = true;
        }
        Movement();


        /*if (Input.GetKeyDown("p"))
        {
            if (PhotonNetwork.IsMasterClient)
            {
                //PhotonNetwork.Disconnect();
                
                PhotonNetwork.LoadLevel(1);
                
            }
        }*/
    }

    void Movement()
    {
        //player rotation
        CharacterController controller = GetComponent<CharacterController>();


        rotationX += Input.GetAxis("Mouse X") * horizontalSpeed;//player side to side rotation
        transform.localEulerAngles = new Vector3(0, rotationX, 0);
        rotationY += Input.GetAxis("Mouse Y") * verticalSpeed;//camera up down rotation
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);// set max an min camera up down angle
        cam.transform.localEulerAngles = new Vector3(-rotationY, 0, 0);
        if (controller.isGrounded) //player is on the ground
        {
            //player WASD movement
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed; //set player speed
            // Space to jump
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;//jump speed
        }
        moveDirection.y -= gravity * Time.deltaTime; //player gravity
        controller.Move(moveDirection * Time.deltaTime);
        //sprint
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (!isCrouching)//cant sprint if crouching
            {
                speed = setSpeed * 2f; //sprint speed
                isSprinting = true;
            }

        }

        //stop sprinting
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            if (!isCrouching && isSprinting)
            {
                speed = setSpeed;
                isSprinting = false;
            }
        }
        //crouch
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.C))
        {
            if (isSprinting && !isCrouching)
            {
                speed = setSpeed;
                isSprinting = false;
            }
            Vector3 pos = firstperson.transform.position;
            if (!isCrouching)
            {
                controller.height = 1;
                controller.center = new Vector3(0, 0.5f, 0);
                pos += new Vector3(0, -1f, 0);
                firstperson.transform.position = pos;
                speed = setSpeed / 3; //reduce sprint speed
                jumpSpeed = 0;//cant jump if crouching
                isCrouching = true;
            }
            //un crouch
            else if (isCrouching)
            {
                controller.height = 2;
                controller.center = new Vector3(0, 0, 0);
                //pos += new Vector3(0, 1f, 0);
                firstperson.transform.position = pos;
                speed = setSpeed;
                jumpSpeed = setJumpSpeed;
                isCrouching = false;
            }
        }
    }
}
