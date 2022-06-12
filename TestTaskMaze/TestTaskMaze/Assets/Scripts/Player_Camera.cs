using UnityEngine;

// скрипт для камеры игрока
public class Player_Camera : MonoBehaviour
{
    // задача полей
    public CameraState cameraState = CameraState.CamRoom;
    private GameObject player;

    // нахождение объекта игрока
    private void Start() { player = GameObject.Find("Player"); }

    // следование за игрока в случае если камера следящая
    private void Update() { 
        if (cameraState == CameraState.CamFollow) { transform.position = new Vector3(player.transform.position.x, player.transform.position.y,transform.position.z); }
    }

    // функция для камеры для комнат
    public void SetCamera(Vector2 vector){
        if (cameraState == CameraState.CamRoom) gameObject.transform.position = new Vector3(vector.x, vector.y, transform.position.z);
    }

    // режимы камеры (статическая, следящая, комнатная)
    public enum CameraState{ CamFollow, CamRoom }
}
