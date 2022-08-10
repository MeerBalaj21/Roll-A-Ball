using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SlidingBaseForward : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        move();
    }

    void move()
    {
        Sequence mySeq = DOTween.Sequence().SetLoops(-1);
        mySeq.Append(transform.DOMoveZ(2.85f, 3));
        mySeq.Append(transform.DOMoveZ(-2.85f, 3));

    }
}
