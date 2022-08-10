using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        move();
    }

    void move()
    {
        Sequence mySeq = DOTween.Sequence().SetLoops(-1);
        mySeq.Append(transform.DOMoveZ(6.23f, 3));
        mySeq.Append(transform.DOMoveZ(8.76f, 3));

    }
}
