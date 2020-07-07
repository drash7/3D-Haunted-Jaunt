using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform player;

    private bool _isPlayerInRange;

    public GameEnding gameEnding;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            _isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            _isPlayerInRange = false;
        }
    }

    private void Update()
    {
        if (_isPlayerInRange)
        {
            Vector3 direction = player.position - transform.position;
            // move direction from floor (Y=0) to chest height (Y=1;
            direction.y += 1f;

            Ray ray = new Ray(transform.position, direction);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.transform == player)
                {
                    // TODO Add call to GameEnding
                    gameEnding.CaughtPlayer();
                }
            }
        }

    }
}
