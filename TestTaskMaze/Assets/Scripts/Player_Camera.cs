using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// скрипт для камеры игрока
public class Player_Camera : MonoBehaviour
{
    // задача переменных
    [SerializeField] private CameraState cameraState = CameraState.CamStatic;
    protected GameObject player;

    // нахождение объекта игрока
    void Start() { player = GameObject.Find("Player"); }

    // следование за игрока в случае если камера следящая
    void Update() { 
        if (cameraState == CameraState.CamFollow) { transform.position = new Vector3(player.transform.position.x, player.transform.position.y,transform.position.z); }
    }

    // функция для камеры для комнат
    public void SetCamera(Vector2 vector){
        if (cameraState == CameraState.CamRoom) gameObject.transform.position = new Vector3(vector.x, vector.y, transform.position.z);
    }

    // режимы камеры (статическая, следящая, комнатная)
    public enum CameraState{ CamStatic, CamFollow, CamRoom }
}
