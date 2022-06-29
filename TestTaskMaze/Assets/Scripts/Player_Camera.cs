using UnityEngine;

public class Player_Camera : MonoBehaviour
{
    [SerializeField] private CameraState cameraState = CameraState.CamRoom;

    private GameObject player;

    private void Start() 
    { 
        player = GameObject.Find("Player"); 
    }

    private void Update() 
    { 
        if (cameraState == CameraState.CamFollow) 
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y,transform.position.z); 
    }

    public void SetCamera(Vector2 vector)
    {
        if (cameraState == CameraState.CamRoom) 
            gameObject.transform.position = new Vector3(vector.x, vector.y, transform.position.z);
    }

    public enum CameraState
    { 
        CamFollow, 
        CamRoom
    }
}