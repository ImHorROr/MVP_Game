using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] Transform startPos = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (startPos == null) return;
        if(collision.CompareTag("Player"))
        {
            collision.gameObject.transform.position = startPos.position;

        }
    }
}
