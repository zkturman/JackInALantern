using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<ICollidable>(out ICollidable collideObject))
        {
            collideObject.StartCollision();
        }
    }
}
