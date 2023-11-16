using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FMODUnity;

public class PlayerController : MonoBehaviour
{
    public StudioEventEmitter sonidoAleatorio;
    public float velocidad;
    Rigidbody2D rb2D;

    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Physics2D.gravity *= -1;
            sonidoAleatorio.Play();
        }
    }
    void FixedUpdate()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        rb2D.position += input * velocidad * Time.fixedDeltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
