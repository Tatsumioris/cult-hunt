using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TexteTrigger : MonoBehaviour
{
    public deplacement Texte;
    //public Transform Position;

    private BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.CompareTag("Player"))
        {
            Texte.SpawnText();
        }
            

    }
}
