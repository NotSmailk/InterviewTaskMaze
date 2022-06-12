using System.Collections;
using System;
using UnityEngine;
using Src;

// скрипт, проверящий, является ли комната тупиком
public class RoomCheckSctipt : MonoBehaviour
{
    // задача полей
    private int[] doorCounter = new int[3]; // 0 - Желтый, 1 - Синий, 2 - Зеленый
    private int[] keyCounter = new int[3]; // 0 - Желтый, 1 - Синий, 2 - Зеленый
    private bool[] checkClear = new bool[3]; // 0 - Желтый, 1 - Синий, 2 - Зеленый
    private bool canClear = false;

    // обнуление переменной тупика при отключении скрипта
    private void OnDisable() { canClear = false; }
    private void Update() {
        // сравнение комнат с ключами и получение результата о возможности пройти комнату
        for(int i = 0; i<3; i++) { CheckRoom(doorCounter, keyCounter, i); if(checkClear[i]) canClear |= checkClear[i]; } 

        // запуск карутины для отправки результата основному скрипту комнаты и сброса значений
        StartCoroutine(SendBool(canClear));
    }

    // карутина для отправки результата основному скрипту комнаты и сброса значений
    IEnumerator SendBool(bool canClear){
        yield return new WaitForSeconds(1);
        gameObject.GetComponentInParent<RoomScript>().SetRoomPass(canClear);
        GetComponent<RoomCheckSctipt>().enabled = false;
    }

    // функция сравнения комнат с ключами
    private void CheckRoom(int[] doorCounter, int[] keyCounter, int i){
        if (doorCounter[i] > 0 && keyCounter[i] > 0) checkClear[i] = true; else checkClear[i] = false;
    }

    // подсчет комнат разных цветов
    private void DoorCount(ObjectInfo.ObjectColor objectColor){ doorCounter[Convert.ToInt32(objectColor)-1]++; }

    // подсчет ключей разных цветов
    private void KeyCount(ObjectInfo.ObjectColor objectColor, int val){ keyCounter[Convert.ToInt32(objectColor)-1]+=val; }

    // проверка на наличие ключей, выхода, дверей
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Key")) { KeyCount(other.gameObject.GetComponent<KeyScript>().GetColor(), 1); }
        if (other.gameObject.CompareTag("Door")) { DoorCount(other.gameObject.GetComponentInParent<DoorScript>().GetColor()); }
        if (other.gameObject.CompareTag("Exit")) canClear = true;
    }

    // проверка на удаление ключей
    private void OnTriggerExit2D(Collider2D other) { 
        if (other.gameObject.CompareTag("Key")) { KeyCount(other.gameObject.GetComponent<KeyScript>().GetColor(), -1); } 
    }
}