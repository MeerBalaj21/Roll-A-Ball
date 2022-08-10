using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CylinderRotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Rotate();
    }
    void Rotate()
    {
        Sequence mySeq = DOTween.Sequence().SetLoops(-1);
        //var quart = Quaternion.Euler(new Vector3(170, 0,90));
        mySeq.Append(transform.DOLocalRotate(new Vector3(90, 0, 90), 5));
    }
}
