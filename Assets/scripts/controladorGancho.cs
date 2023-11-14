using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CambiarColorBoton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Image imagenBoton; // Referencia a la imagen del botón que quieres cambiar
    public Color colorPresionado; // Color que deseas cuando se presione el botón

    private Color colorOriginal; // Color original de la imagen del botón

    void Start()
    {
        // Guarda el color original al iniciar el juego
        if (imagenBoton != null)
        {
            colorOriginal = imagenBoton.color;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Cambia el color al color presionado cuando se presiona el botón
        if (imagenBoton != null)
        {
            imagenBoton.color = colorPresionado;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Restaura el color original cuando se suelta el botón
        if (imagenBoton != null)
        {
            imagenBoton.color = colorOriginal;
        }
    }
}
