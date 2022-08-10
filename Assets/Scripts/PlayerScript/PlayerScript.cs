using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D r2d;
    public AudioSource AmThanh;
    private Animator animator;

    private float velocity = 7;
    private bool QuayPhai = true;
    private float speed = 0;
    private bool OnTheFloor = true;
    private float NhayCao = 550;
    private float RoiXuong = 5;
    private bool ChuyenHuong = false;

    GameObject camera;


    // Start is called before the first frame update
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        AmThanh = GetComponent<AudioSource>();
        camera = GameObject.FindWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", speed);
        animator.SetBool("OnTheFloor", OnTheFloor);
        NhayLen();
        DiChuyen();
    }

    private void FixedUpdate()
    {

    }

    void DiChuyen()
    {
        float PhimTraiPhai = Input.GetAxis("Horizontal");
        r2d.velocity = new Vector2(velocity * PhimTraiPhai, r2d.velocity.y);
        speed = Mathf.Abs(velocity * PhimTraiPhai);
        if (PhimTraiPhai > 0 && !QuayPhai)
        {
            camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y, -9.9f);
            QuayPhai = !QuayPhai;
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        if (PhimTraiPhai < 0 && QuayPhai)
        {
            camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y, -9.9f);
            QuayPhai = !QuayPhai;
            transform.localEulerAngles = new Vector3(0, -180, 0);

        }
    }

    void NhayLen()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (OnTheFloor == false) return;
            r2d.AddForce((Vector2.up) * NhayCao);
            OnTheFloor = false;
            /*TaoAmThanh("smb_jump-super");*/

        }
        //áp dụng lực hút trái đất để Mario rơi xuống nhanh hơn
        if (r2d.velocity.y < 0)
        {
            r2d.velocity += Vector2.up * Physics2D.gravity.y * (RoiXuong - 1) * Time.deltaTime;
        }
        else if (r2d.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            r2d.velocity += Vector2.up * Physics2D.gravity.y * (5 - 1) * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            OnTheFloor = true;
        }
    }

    public void TaoAmThanh(string fileAmThanh)
    {
        //lấy path resources
        AmThanh.PlayOneShot(Resources.Load<AudioClip>("Media/" + fileAmThanh));
    }
}
