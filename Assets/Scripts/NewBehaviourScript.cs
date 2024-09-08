using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class NewBehaviourScript : MonoBehaviour
{

    TilemapRenderer tilemapRenderer;
    // Start is called before the first frame update
    void Start()
    {
        tilemapRenderer = GetComponent<TilemapRenderer>();
        Debug.Log(gameObject.name + " : " + tilemapRenderer.bounds);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
