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

        void OnCollisionEnter(Collision collision){
            portalSaida.Fire();
        }

        public void PlacePortal(Vector3 coords){
            transform.position = coords;
        }
    }
}
