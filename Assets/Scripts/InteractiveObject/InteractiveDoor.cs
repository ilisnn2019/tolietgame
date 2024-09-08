using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveDoor : MonoBehaviour, IInteractive
{
    private bool isInteractive = false;

    public Transform doorNext;

    public bool IsInteractive { get => isInteractive; set => isInteractive = value; }

    public void Interact(GameObject player)
    {
        player.transform.position = doorNext.transform.position;
        Debug.Log("door");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Active");
            isInteractive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInteractive = false;
        }
    }
}
