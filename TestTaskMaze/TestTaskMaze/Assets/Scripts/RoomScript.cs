using System.Collections;
using UnityEngine;

// основной скрипт комнаты для взаимодействия с игроком
public class RoomScript : MonoBehaviour
{
    // объявдение полей
    private bool canClear = true;
    private Transform cameraMain = null;

    // нахождение объекта камеры
    private void Start() { cameraMain = GameObject.Find("Main Camera").transform; }

    // корутина для отправки булевой переменной о поражении игрока
    IEnumerator CheckPlayer(bool canClear){
        yield return new WaitForSeconds(1);
        if (!canClear) cameraMain.GetComponent<GameUI>().Defeat();
    }

    // проверка на наличие игрока в комнате (если комната - тупик, то поражение), если камера привязана не к игроку, а к комнатам, то новое положение камеры
    private void OnTriggerEnter2D(Collider2D other) { 
        if (other.gameObject.CompareTag("Player")) { 
            StartCoroutine(CheckPlayer(canClear)); 
            cameraMain.GetComponent<Player_Camera>().SetCamera(transform.position); 
        } 
    }
    // если игрок вышел из комнаты, она проверяет есть ли из нее выход
    private void OnTriggerExit2D(Collider2D other) { 
        if (other.gameObject.CompareTag("Player")) { GetComponentInChildren<RoomCheckSctipt>().enabled = true;} 
    }
    // функция задачи переменной о тупике
    public void SetRoomPass(bool check){ canClear = check; }
}