using UnityEngine;
using Src;

[RequireComponent(typeof(Rigidbody2D))]
public class Player_Controller : ObjectInfo
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private GameObject pressE = null;

    private Transform mainCameraTransform = null;
    private Rigidbody2D playerRigidbody;
    private float upAxis = 0f;
    private float rightAxis = 0f;
    private bool isEntering = false;

    private void Start() 
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        mainCameraTransform = GameObject.Find("Main Camera").transform;
    }

    private void Update() 
    {
        upAxis = Input.GetAxis("Vertical")*speed;
        rightAxis = Input.GetAxis("Horizontal")*speed;
        playerRigidbody.velocity = new Vector2(rightAxis, upAxis);
    }

    private void Interacte(ObjectColor objectColor)
    { 
        ObjColor = objectColor;
        ChangeColor();
    }

    private void CheckDoor(ObjectColor objectColor, out bool check)
    {
        check = false;
        if (ObjColor == objectColor) 
            check = true;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Key")) 
        {
            pressE.SetActive(true); 
            other.gameObject.GetComponent<KeyScript>().OutlineActivity(true);
        }

        if (other.gameObject.CompareTag("Door")) 
        {
            CheckDoor(other.gameObject.GetComponentInParent<DoorScript>().GetColor(), out bool check);
            other.gameObject.GetComponentInParent<DoorScript>().SetEnter(check);
            isEntering = check; 
        }

        if (other.gameObject.CompareTag("Exit")) 
        { 
            mainCameraTransform.GetComponent<GameUI>().Win(); 
        }
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Key")) 
        {
            if (Input.GetKey(KeyCode.E)){ 
                Interacte(other.gameObject.GetComponent<KeyScript>().GetColor()); 
                Destroy(other.gameObject); 
            } 
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Key")) 
        {
            pressE.SetActive(false); 
            other.gameObject.GetComponent<KeyScript>().OutlineActivity(false);
        }

        if (other.gameObject.CompareTag("DoorOut") && isEntering) 
        {
            ObjColor = ObjectColor.White; 
            ChangeColor();
            other.gameObject.GetComponentInParent<DoorScript>().SetEnter(false); 
        }
    }
}