using System.Collections;
using System;
using UnityEngine;
using Src;

public class RoomCheckSctipt : MonoBehaviour
{
    private int[] doorCounter = new int[3]; // 0 - Y, 1 - B, 2 - G
    private int[] keyCounter = new int[3]; // 0 - Y, 1 - B, 2 - G
    private bool[] checkClear = new bool[3]; // 0 - Y, 1 - B, 2 - G
    private bool canClear = false;

    private void OnDisable() 
    { 
        canClear = false; 
    }

    private void Update() 
    {
        for(int i = 0; i<3; i++) 
        { 
            CheckRoom(doorCounter, keyCounter, i); 
            if(checkClear[i]) 
                canClear |= checkClear[i]; 
        } 

        StartCoroutine(SendBool(canClear));
    }

    IEnumerator SendBool(bool canClear)
    {
        yield return new WaitForSeconds(1);
        gameObject.GetComponentInParent<RoomScript>().SetRoomPass(canClear);
        GetComponent<RoomCheckSctipt>().enabled = false;
    }

    private void CheckRoom(int[] doorCounter, int[] keyCounter, int i)
    {
        checkClear[i] = doorCounter[i] > 0 && keyCounter[i] > 0; 
    }

    private void DoorCount(ObjectColor objectColor)
    { 
        doorCounter[Convert.ToInt32(objectColor)-1]++; 
    }

    private void KeyCount(ObjectColor objectColor, int val)
    { 
        keyCounter[Convert.ToInt32(objectColor)-1]+=val; 
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Key")) 
            KeyCount(other.gameObject.GetComponent<KeyScript>().GetColor(), 1);

        if (other.gameObject.CompareTag("Door")) 
            DoorCount(other.gameObject.GetComponentInParent<DoorScript>().GetColor()); 

        canClear = other.gameObject.CompareTag("Exit");
    }

    private void OnTriggerExit2D(Collider2D other) 
    { 
        if (other.gameObject.CompareTag("Key")) 
            KeyCount(other.gameObject.GetComponent<KeyScript>().GetColor(), -1); 
    }
}