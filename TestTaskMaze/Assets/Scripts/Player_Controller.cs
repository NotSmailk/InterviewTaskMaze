using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

// скрипт-контроллер игрока
public class Player_Controller : MonoBehaviour
{
    // задача переменных
    [SerializeField] private float _speed = 5f;
    [SerializeField] [Tooltip("0 - Белый, 1 - Желтый, 2- Синий, 3 - Зеленый")] private Sprite[] playerSprites = null;
    [SerializeField] private GameObject pressE = null;
    private Transform cameraMain = null;
    private PlayerState playerState = PlayerState.White;
    private Rigidbody2D rb;
    private float upAxis = 0f;
    private float rightAxis = 0f;
    protected bool Entering = false;

    // задача физического тела и камеры
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        cameraMain = GameObject.Find("Main Camera").transform;
    }

    // передвежение игрока и смена спрайта
    void Update() {
        upAxis = Input.GetAxis("Vertical")*_speed*10;
        rightAxis = Input.GetAxis("Horizontal")*_speed*10;
        rb.velocity = new Vector2(rightAxis, upAxis);
        GetComponent<SpriteRenderer>().sprite = playerSprites[Convert.ToInt32(playerState)];
    }

    // взаимодействие с ключами
    void Interacte(KeyData keyData){
        switch(keyData.KeyColor){
            case KeyData.State.Yellow: playerState = PlayerState.Yellow; break;
            case KeyData.State.Blue: playerState = PlayerState.Blue; break;
            case KeyData.State.Green: playerState = PlayerState.Green; break;
        }
    }

    // проверка дверей
    void CheckDoor(DoorData doorData, out bool check){
        check = false;
        switch(doorData.DoorColor){
            case DoorData.State.Yellow: if (playerState == PlayerState.Yellow) check = true; break;
            case DoorData.State.Blue: if (playerState == PlayerState.Blue) check = true; break;
            case DoorData.State.Green: if (playerState == PlayerState.Green) check = true; break;
        }
    }

    // проверка о столкновении с объектами
    private void OnTriggerEnter2D(Collider2D other) {
        // с ключом
        if (other.gameObject.tag == "Key"){
            pressE.SetActive(true); // подсвечивание кнопки "Е"
            other.gameObject.GetComponent<KeyScript>().OutlineActivity(true); // подсвечивание ключа
        }
        // с дверью
        if (other.gameObject.tag == "Door"){
            CheckDoor(other.gameObject.GetComponentInParent<DoorScript>().GetData(), out bool check); // проверка двери
            other.gameObject.GetComponentInParent<DoorScript>().SetEnter(check); // отправка булевой переменной, отвечающей за возможность пройти сквозь дверь
            Entering = check; // смена состояния на входящий в дверь
        }
        // с выходом
        if (other.gameObject.tag == "Exit"){ 
            cameraMain.GetComponent<GameUI>().Win(); // победа
        }
    }

    // проверка о нахождении рядом с объектом
    private void OnTriggerStay2D(Collider2D other) {
        // с ключом
        if (other.gameObject.tag == "Key"){
            if (Input.GetKey(KeyCode.E)){ Interacte(other.gameObject.GetComponent<KeyScript>().GetData()); Destroy(other.gameObject); } // взаимодействие с ключом
        }
    }

    // проверка о прекращении столкновений с объектами
    private void OnTriggerExit2D(Collider2D other) {
        // с ключом
        if (other.gameObject.tag == "Key"){
            pressE.SetActive(false); // отключение подсвечивания кнопки "Е"
            other.gameObject.GetComponent<KeyScript>().OutlineActivity(false);// отключение подсвечивания ключа
        }
        // с выходом из двери
        if (other.gameObject.tag == "DoorOut" && Entering){
            playerState = PlayerState.White; // смена состояния игрока на состояние по-умолчанию
            other.gameObject.GetComponentInParent<DoorScript>().SetEnter(false); // игрок не входит в двери
        }
    }

    // возможные цвета игрока
    public enum PlayerState{ White = 0, Yellow, Blue, Green }
}