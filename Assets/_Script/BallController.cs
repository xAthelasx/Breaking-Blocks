using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    #region SerializeField variables
    [SerializeField] float initialSpeed = 2;//Velocidad inicial de la bola.
    #endregion
    #region Privates variables
    Vector2 currentVelocity; //Guarda la velocidad actual de la bola.
    Vector2 moveDirection; //Guardamos la nueva dirección
    bool ballInPlay; //Indicamos que la bola está en juego.

    Rigidbody2D _rb; //Variable del rigidbody.
    #endregion

    #region Monobehaviour method
    private void Start()
    {
        ballInPlay = false;
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(Input.GetMouseButton(0) && !ballInPlay) { LaunchBall(); }
    }
    #endregion

    #region Private Method
    private void LaunchBall()
    {
        _rb.velocity = Vector2.up * initialSpeed;
        currentVelocity = _rb.velocity;
        ballInPlay = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        moveDirection = Vector2.Reflect(currentVelocity, collision.GetContact(0).normal);
        _rb.velocity = moveDirection;
        currentVelocity = _rb.velocity;

        if (collision.gameObject.CompareTag("Brick")) { Destroy(collision.gameObject); }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DeathLine")) { Destroy(this.gameObject); }
    }
    #endregion

}
