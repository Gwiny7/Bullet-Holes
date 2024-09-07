using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BulletHoles
{
    public class PortalEntrada : MonoBehaviour
    {
        [SerializeField] Transform firePoint;
        Vector3 pos;

        void Update(){
            pos = Input.mousePosition;
            pos.z = 0;
            transform.position = Camera.main.ScreenToWorldPoint(pos);
        }

    }
}
