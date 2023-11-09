using UnityEngine;
using Vuforia;

public class CubeRotation : MonoBehaviour
{
    public GameObject cubeToRotate;
    public VirtualButtonBehaviour virtualButton;

    private bool isRotating = false;

    void Start()
    {
        virtualButton.RegisterOnButtonPressed(OnButtonPressed);
        virtualButton.RegisterOnButtonReleased(OnButtonReleased);
    }

    private void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        isRotating = !isRotating;
        Debug.Log("Pulsado");
    }

    private void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        // Puedes agregar aqu� un c�digo adicional cuando se suelta el bot�n virtual si es necesario.
    }

    void Update()
    {
        if (isRotating)
        {
            cubeToRotate.transform.Rotate(Vector3.up * Time.deltaTime * 30f);
        }
    }
}