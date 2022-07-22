using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    public float jumpForce;
    public Rigidbody2D rb;
    public string currentColor;
    public Color colorCyan;
    public Color colorPink;
    public Color colorPurple;
    public Color colorYellow;
    public SpriteRenderer sr;
    public int star;
    public Text starText;

    void Start()
    {
        RandomColor();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Star")
        {
            star++;
            starText.text = star.ToString();
            Destroy(other.gameObject);
            return;
        }

        if (other.tag == "ColorChanger")
        {
            RandomColor();
            Destroy(other.gameObject);
            return;
        }

        if (other.tag != currentColor)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) 
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    void RandomColor()
    {
        int index = Random.Range(0,4);

        switch(index)
        {
            case 0: currentColor = "Cyan";
                    sr.color = colorCyan;
                    break;
            case 1: currentColor = "Yellow";
                    sr.color = colorYellow;
                    break;   
            case 2: currentColor = "Pink";
                    sr.color = colorPink;
                    break;
            case 3: currentColor = "Purple";
                    sr.color = colorPurple;
                    break;       
        }
    }


}
