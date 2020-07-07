using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoCoroutine : MonoBehaviour
{

    private Coroutine coroutine;
    // Start is called before the first frame update
    void Start()
    {
        // StartCoroutine(DoMove());
        // gameObject.SetActive(false);
    }

    void OnEnable()
    {
        if (coroutine == null)
            coroutine = StartCoroutine(DoMove());

    }

    void OnDisable()
    {
        // StopAllCoroutines();
    }

    IEnumerator DoMove()
    {
        float interval = 0.5f;
        WaitForSeconds wait = new WaitForSeconds(interval);

        while (true)
        {
            transform.Translate(Vector3.forward * interval);
            yield return wait;
        }

        coroutine = null;
    }
}
