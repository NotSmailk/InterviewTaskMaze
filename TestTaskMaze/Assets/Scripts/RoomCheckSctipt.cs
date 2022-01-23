using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

// скрипт, проверящий, является ли комната тупиком
public class RoomCheckSctipt : MonoBehaviour
{
    // задача переменных
    protected int[] _DoorCount = new int[3]; // 0 - Желтый, 1 - Синий, 2 - Зеленый
    protected int[] _KeyCount = new int[3]; // 0 - Желтый, 1 - Синий, 2 - Зеленый
    private bool[] checkClear = new bool[3]; // 0 - Желтый, 1 - Синий, 2 - Зеленый
    private bool canClear = false;

    // обнуление переменной тупика при отключении скрипта
    private void OnDisable() { canClear = false; }
    void Update() {
        // сравнение комнат с ключами и получение результата о возможности пройти комнату
        for(int i = 0; i<3; i++) { CheckRoom(_DoorCount, _KeyCount, i); if(checkClear[i]) canClear |= checkClear[i]; } 

        // запуск карутины для отправки результата основному скрипту комнаты и сброса значений
        StartCoroutine(SendBool(canClear));
    }

    // карутина для отправки результата основному скрипту комнаты и сброса значений
    IEnumerator SendBool(bool canClear){
        yield return new WaitForSeconds(1);
        gameObject.GetComponentInParent<RoomScript>().SetRoom(canClear);
        GetComponent<RoomCheckSctipt>().enabled = false;
    }

    // функция сравнения комнат с ключами
    private void CheckRoom(int[] _DoorCount, int[] _KeyCount, int i){
        if (_DoorCount[i] > 0 && _KeyCount[i] > 0) checkClear[i] = true; else checkClear[i] = false;
    }

    // подсчет комнат разных цветов
    private void DoorCount(DoorData doorData){ _DoorCount[Convert.ToInt32(doorData.DoorColor)]++; }

    // подсчет ключей разных цветов
    private void KeyCount(KeyData keyData, int val){ _KeyCount[Convert.ToInt32(keyData.KeyColor)]+=val; }

    // проверка на наличие ключей, выхода, дверей
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Key"){ KeyCount(other.gameObject.GetComponent<KeyScript>().GetData(), 1); }
        if (other.gameObject.tag == "Door"){ DoorCount(other.gameObject.GetComponentInParent<DoorScript>().GetData()); }
        if (other.gameObject.tag == "Exit") canClear = true;
    }

    // проверка на удаление ключей
    private void OnTriggerExit2D(Collider2D other) { if (other.gameObject.tag == "Key"){ KeyCount(other.gameObject.GetComponent<KeyScript>().GetData(), -1); } }
}