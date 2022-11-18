using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public int PlayerHealth = 100;
    SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        int walk = (int)Input.GetAxisRaw("Horizontal");

        if (walk > 0 || walk < 0 )
        {
            anim.SetBool("walk", true);
        }
        else if (walk == 0)
        {
            anim.SetBool("walk", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.name == "P2")
            PlayerHealth = PlayerHealth - 1;

        Debug.Log(PlayerHealth);
        if (PlayerHealth <= 0)
            Debug.Log("Game Over!");
    }

    public bool IsDead
    {
        get
        {
            return PlayerHealth == 0;
        }
    }

    public void TakeDamege(int amount)
    {
        PlayerHealth -= amount;
        if (PlayerHealth < 0)
            PlayerHealth = 0;

        if (IsDead)
        {
           
        }
    }

    public Animator anim;

}
