using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace BulletHoles
{
    public class PortalEntrada : MonoBehaviour
    {
        [SerializeField] Transform firePoint;
        Vector3 pos;
        [SerializeField] PortalSaida portalSaida;

        void Update(){
            pos = Input.mousePosition;
            transform.position = Camera.main.ScreenToWorldPoint(pos);
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }

        void OnCollisionEnter(Collision collision){
            portalSaida.Fire();
        }

    }
}
