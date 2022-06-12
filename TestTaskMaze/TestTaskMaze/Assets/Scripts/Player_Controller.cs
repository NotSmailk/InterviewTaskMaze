using UnityEngine;
using Src;

// скрипт-контроллер игрока
[RequireComponent(typeof(Rigidbody2D))]
public class Player_Controller : ObjectInfo
{
    // задача полей
    [SerializeField] private float speed = 10f;
    [SerializeField] private GameObject pressE = null;
    private Transform cameraMain = null;
    private Rigidbody2D playerRigidbody;
    private float upAxis = 0f;
    private float rightAxis = 0f;
    private bool isEntering = false;

    // задача физического тела и камеры
    private void Start() {
        playerRigidbody = GetComponent<Rigidbody2D>();
        cameraMain = GameObject.Find("Main Camera").transform;
    }

    // передвежение игрока и смена спрайта
    private void Update() {
        upAxis = Input.GetAxis("Vertical")*speed;
        rightAxis = Input.GetAxis("Horizontal")*speed;
        playerRigidbody.velocity = new Vector2(rightAxis, upAxis);
    }

    // взаимодействие с ключами
    private void Interacte(ObjectColor objectColor){ 
        ObjColor = objectColor;
        ChangeColor();
    }

    // проверка дверей
    private void CheckDoor(ObjectColor objectColor, out bool check){
        check = false;
        if (ObjColor == objectColor) check = true;
    }

    // проверка о столкновении с объектами
    private void OnTriggerEnter2D(Collider2D other) {
        // с ключом
        if (other.gameObject.CompareTag("Key")) {
            pressE.SetActive(true); // подсвечивание кнопки "Е"
            other.gameObject.GetComponent<KeyScript>().OutlineActivity(true); // подсвечивание ключа
        }
        // с дверью
        if (other.gameObject.CompareTag("Door")) {
            CheckDoor(other.gameObject.GetComponentInParent<DoorScript>().GetColor(), out bool check); // проверка двери
            other.gameObject.GetComponentInParent<DoorScript>().SetEnter(check); // отправка булевой переменной, отвечающей за возможность пройти сквозь дверь
            isEntering = check; // смена состояния на входящий в дверь
        }
        // с выходом
        if (other.gameObject.CompareTag("Exit")) { 
            cameraMain.GetComponent<GameUI>().Win(); // победа
        }
    }

    // проверка о нахождении рядом с объектом
    private void OnTriggerStay2D(Collider2D other) {
        // с ключом
        if (other.gameObject.CompareTag("Key")) {
            if (Input.GetKey(KeyCode.E)){ 
                Interacte(other.gameObject.GetComponent<KeyScript>().GetColor()); 
                Destroy(other.gameObject); 
            } // взаимодействие с ключом
        }
    }

    // проверка о прекращении столкновений с объектами
    private void OnTriggerExit2D(Collider2D other) {
        // с ключом
        if (other.gameObject.CompareTag("Key")) {
            pressE.SetActive(false); // отключение подсвечивания кнопки "Е"
            other.gameObject.GetComponent<KeyScript>().OutlineActivity(false);// отключение подсвечивания ключа
        }
        // с выходом из двери
        if (other.gameObject.CompareTag("DoorOut") && isEntering) {
            ObjColor = ObjectColor.White; // смена состояния игрока на состояние по-умолчанию
            ChangeColor();
            other.gameObject.GetComponentInParent<DoorScript>().SetEnter(false); // игрок не входит в двери
        }
    }
}