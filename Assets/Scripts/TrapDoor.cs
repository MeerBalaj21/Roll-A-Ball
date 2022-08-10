using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TrapDoor : MonoBehaviour
{
    public GameObject ball;
    private Vector3 OGScale;
    // Start is called before the first frame update
    void Start()
    {
        OGScale = ball.transform.localScale;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && ball.transform.localScale.z > OGScale.z)
        {
            Sequence mySeq = DOTween.Sequence();
            mySeq.Append(transform.DOMoveX(-10.53f, 3));
            mySeq.Append(transform.DOMoveX(-8.13f, 3));
        }
    }
}
