using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorParticleController : MonoBehaviour
{
    void Update()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10f);
        if (Input.GetMouseButtonUp(0))
            Destroy(gameObject);
    }
}
