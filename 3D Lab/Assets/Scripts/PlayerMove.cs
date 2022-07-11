using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    //void Start()
    private CharacterController cc;
    public float gravity;
    public float JumpForce;
    public float speed;
    private float jspeed = 0;

    void Awake()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = 0;
        float vertical = 0;
        if (cc.isGrounded)
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
            jspeed = 0;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jspeed = JumpForce;
            }
        }
        jspeed += gravity * Time.deltaTime * 3f;
        Vector3 dir = new Vector3(horizontal * speed * Time.deltaTime, jspeed * Time.deltaTime, vertical * speed * Time.deltaTime);
        cc.Move(dir);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (this.CompareTag("Player") && other.CompareTag("Finish"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}