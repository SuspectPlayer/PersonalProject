using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private CharacterController cc;
    [SerializeField] private float movementSpeed = 6.0f;
    public float forwardSpeed = 60.0f;
    [SerializeField] private float agility = 12.0f;
    [SerializeField] private float turnAmount = 5f;
    [SerializeField] private float yawAmount = 20f;

    public GameObject pressFireToMove;
    public AudioSource audioSource;
    public float maxSpeed = 60;
    public float currentSpeed;
    public bool freeze;
    private void Start()
    {
        cc = GetComponent <CharacterController>();
        audioSource = GetComponent<AudioSource>();
        freeze = true;
        audioSource.enabled = false;
       
    }
    private void Update()
    {
        currentSpeed = cc.velocity.z / 30 + 2;
        audioSource.pitch = currentSpeed;
    }

    void FixedUpdate()
    {
        if (freeze && Input.GetMouseButton(0))
        {
            pressFireToMove.SetActive(false);
            audioSource.enabled = true;
                freeze = false;
                
        }
        if (!freeze)
        {
            cc.Move(Vector3.forward * Time.deltaTime * forwardSpeed);
            // Movement x and z
            Vector3 move = new Vector3(Input.GetAxis("Horizontal") * agility, 0, Input.GetAxis("Vertical") * movementSpeed);
            cc.Move(move * Time.deltaTime);

            // Rotation
            if (move != Vector3.zero)
            {
                gameObject.transform.rotation = Quaternion.Euler(0, Input.GetAxis("Horizontal") * turnAmount, -Input.GetAxis("Horizontal") * yawAmount);
            }
        }
        
        
    }
    public void ChangePlayerSpeed(int speed)
    {
        forwardSpeed = speed;
    }
}
