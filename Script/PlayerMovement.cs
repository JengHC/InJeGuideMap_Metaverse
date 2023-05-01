using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Animator _animator;
    Camera _camera;
    CharacterController _controller;

    public float speed = 5.0f;
    public float runSpeed = 8.0f;
    public float finalSpeed;

    public bool toggleCameraRotation;
    public bool run;
    public float smoothness = 10.0f;

    //�߷�
    private float gravity = -9.81f;
    private Vector3 moveDirection = Vector3.zero;
    private float jumpSpeed = 7.0f;


    //   public Transform groundCheck;
    //  public LayerMask groundMask;
    //  public float groundDistance=0.2f;

    //    private Vector3 velocity;
    //    private bool isGrounded;


    // Start is called before the first frame update
    void Start()
    {
        _animator = this.GetComponent<Animator>();
        _camera = Camera.main;
        _controller = this.GetComponent<CharacterController>();
    }

    void Update()
    {
        // ĳ���� ����, ī�޶� ȸ������(ex.��Ʋ�׶��� �ü������� ī�޶� ������ ���)
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            toggleCameraRotation = true;
        }
        else
        {
            toggleCameraRotation = false;
        }

        // �޸��� 
        InputMovement();
        if (Input.GetKey(KeyCode.LeftShift))
        {
            run = true;
        }
        else
        {
            run = false;
        }

        //������ư
        if (Input.GetButton("Jump"))
        {
            moveDirection.y = jumpSpeed;
        }
        //�߷�
        moveDirection.y += gravity * Time.deltaTime;
        _controller.Move(moveDirection * Time.deltaTime);


    }

    void LateUpdate()
    {
        if (toggleCameraRotation != true)
        {
            Vector3 playerRotate = Vector3.Scale(_camera.transform.forward, new Vector3(1, 0, 1));
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(playerRotate), Time.deltaTime * smoothness);
        }
    }

    void InputMovement()
    {
        finalSpeed = (run) ? runSpeed : speed;

        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        Vector3 moveDirection = forward * Input.GetAxisRaw("Vertical") + right * Input.GetAxisRaw("Horizontal");

        _controller.Move(moveDirection.normalized * finalSpeed * Time.deltaTime);

        float percent = ((run) ? 1 : 0.5f) * moveDirection.magnitude;

        _animator.SetFloat("Blend", percent, 0.1f, Time.deltaTime);
    }
}
