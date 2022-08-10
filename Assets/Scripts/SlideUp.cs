using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SlideUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        move();
    }

    void move()
    {
        Sequence mySeq = DOTween.Sequence().SetLoops(-1);
        mySeq.Append(transform.DOMoveY(5.61f, 3));
        mySeq.Append(transform.DOMoveY(6.68f, 3));

    }
}
