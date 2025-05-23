using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class deplacement : MonoBehaviour
{
    public SpriteRenderer itSelf;
    public float basePosY;

    // Start is called before the first frame update
    void Start()
    {
        itSelf.DOFade(0f, 0f);
        basePosY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnText()
    {
        itSelf.DOFade(1f, 2f);
        transform.DOMove(new Vector2 (transform.position.x, basePosY + 2), 1f);
    }
}
