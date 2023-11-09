using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muelles : MonoBehaviour
{
    public GameObject[] contactoSuelo;
    public float gravityForce = 12f;
    public float alturaMuelle = 0.65f;
    float avance;
    float avance_anterior;
    public float coefAvance = 5.0f;
    float giro;
    float giro_anterior;
    public float coefGiro = 6.0f;
    public Animator m_animimator;
    public FixedJoystick _joystick; // Asegúrate de asignar el joystick en el Inspector.



    Rigidbody body;
    int layerMask;
    //public GameObject arcamera;
    void Start()
    {
        body = this.GetComponent<Rigidbody>();
        layerMask = 1 << LayerMask.NameToLayer("nave");
        layerMask = ~layerMask;
        body.centerOfMass = new Vector3 (0,-1.0f,0);

    }

    private void Update()
    {
        //print(Vector3.Distance(arcamera.transform.position,this.transform.position));
        if (_joystick == null)
        {
            Debug.LogError("FixedJoystick not assigned in the Inspector.");
            return;
        }

        Vector2 move = new Vector2(_joystick.Horizontal, _joystick.Vertical);
        avance = Mathf.Max(0, move.y) * coefAvance;
        giro = move.x * coefGiro;
/*
        if (avance != avance_anterior)
        {
            switch (avance)
            {
                case > 0:
                    m_animimator.SetTrigger("avanzar");
                    break;
                case < 0:
                    m_animimator.SetTrigger("retroceder");
                    break;
                default:
                    m_animimator.SetTrigger("parar");
                    break;
            }
        }*/
        avance_anterior = avance;

        /*if (giro != giro_anterior)
        {
            switch (giro)
            {
                case > 0.1f:
                    m_animimator.SetTrigger("derecha");
                    break;
                case < -0.1f:
                    m_animimator.SetTrigger("izquierda");
                    break;
                default:
                    m_animimator.SetTrigger("recto");
                    break;
            }
        }*/
        giro_anterior = giro;
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < contactoSuelo .Length; i++)
        {
            //contactoSuelo[i].GetComponent<LineRenderer>().SetPosition(0, contactoSuelo[i].transform.position);
            RaycastHit hit;
            if (Physics.Raycast(contactoSuelo[i].transform.position, -Vector3.up, out hit, alturaMuelle, layerMask))
            {
                body.AddForceAtPosition(contactoSuelo[i].transform.up * gravityForce * (((alturaMuelle - hit.distance) / alturaMuelle)), contactoSuelo[i].transform.position);
                //contactoSuelo[i].GetComponent<LineRenderer>().SetPosition(1, hit.point);
            }
            else
            {
                body.AddForceAtPosition(contactoSuelo[i].transform.up * -gravityForce, contactoSuelo[i].transform.position);
            }
        }

        body.AddForce(transform.forward * avance * coefAvance);
        body.AddRelativeTorque(Vector3.up * giro * coefGiro);


    }
    /*
    void OnDrawGizmos()
    {
        for (int i = 0; i < contactoSuelo.Length; i++)
        {
            RaycastHit hit;
            if (Physics.Raycast(contactoSuelo[i].transform.position, -Vector3.up, out hit, alturaMuelle, layerMask))
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawLine(contactoSuelo[i].transform.position, hit.point);
                Gizmos.DrawSphere(hit.point, 0.05f);
            }
            else
            {
                Gizmos.color = Color.red;
                Gizmos.DrawLine(contactoSuelo[i].transform.position, contactoSuelo[i].transform.position - Vector3.up * alturaMuelle);
            }
        }
        
    }
*/
    public void resetCar()
    {
        body.transform.position = new Vector3(0, 1, 0);
        body.transform.rotation = Quaternion.identity;
    }

}
