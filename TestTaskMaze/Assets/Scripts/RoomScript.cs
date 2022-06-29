using System.Collections;
using UnityEngine;

public class RoomScript : MonoBehaviour
{
    private bool canClear = true;
    private Transform mainCameraTransform = null;

    private void Start() 
    {
        mainCameraTransform = Camera.main.transform; 
    }

    IEnumerator CheckPlayer(bool canClear)
    {
        yield return new WaitForSeconds(1);

        if (!canClear)
            mainCameraTransform.GetComponent<GameUI>().Defeat();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    { 
        if (other.gameObject.CompareTag("Player")) 
        { 
            StartCoroutine(CheckPlayer(canClear));
            mainCameraTransform.GetComponent<Player_Camera>().SetCamera(transform.position); 
        } 
    }

    private void OnTriggerExit2D(Collider2D other) 
    { 
        if (other.gameObject.CompareTag("Player")) 
        { 
            GetComponentInChildren<RoomCheckSctipt>().enabled = true;
        } 
    }

    public void SetRoomPass(bool check)
    { 
        canClear = check; 
    }
}