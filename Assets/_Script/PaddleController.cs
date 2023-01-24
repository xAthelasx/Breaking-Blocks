using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    #region Private variables
    Vector3 touchPosition; //Variable que guardará la posición donde tocamos la pantalla.
    float xLimit = 7; //Variable que nos indicará donde no puede rebasar la pala.
    #endregion
    #region Serializables variables
    [SerializeField] float speed = 3; //Variable que nos indica la velocidad de movimiento de la pala.
    #endregion

    #region Monobehaviour Method
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            touchPosition = Input.mousePosition; //Guardamos la posición de toque.
            Move(); //Llamamos a la función de mover.
        }
    }
    #endregion

    #region Private Method
    private void Move()
    {
        Vector3 realPosition = Camera.main.ScreenToWorldPoint(touchPosition).normalized;
        transform.Translate(Vector3.right * Mathf.Sign(realPosition.x) * speed * Time.deltaTime);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -xLimit, xLimit),-4,0);
    }
    #endregion
}
