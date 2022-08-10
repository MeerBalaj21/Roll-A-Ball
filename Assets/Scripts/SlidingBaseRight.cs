using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SlidingBaseRight : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        move();
    }

    void move()
    {
        Sequence mySeq = DOTween.Sequence().SetLoops(-1);
        mySeq.Append(transform.DOMoveX(5f, 3));
        mySeq.Append(transform.DOMoveX(0f, 3));

    }
}
