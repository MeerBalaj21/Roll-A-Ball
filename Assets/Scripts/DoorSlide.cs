using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoorSlide : MonoBehaviour
{
   
    void Start()
    {
        move();


    }

    void move()
    {
        Sequence mySeq = DOTween.Sequence().SetLoops(-1);
        mySeq.Append(transform.DOMoveX(-11.11f, 3));
        mySeq.Append(transform.DOMoveX(-8.89f, 3));

    }
}
