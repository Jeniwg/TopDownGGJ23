using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private TileBase newSprite;
    [SerializeField]
    private Tilemap tilemap;
    [SerializeField]
    private GameObject PauseScreen;
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Animator animator;
    Rigidbody2D body;

    float horizontal;
    float vertical;

    public float runSpeed = 5.0f;
    private bool gameIsPaused = false;
    private Vector2 direction;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        
        HandleSpriteFlip();
        
        animator.SetFloat("horizontal", horizontal);
        animator.SetFloat("vertical", vertical);

        direction = new Vector2(horizontal, Input.GetAxisRaw("Vertical")).normalized;

        Vector3Int pos = tilemap.WorldToCell(gameObject.transform.position);
        tilemap.SetTile(pos, newSprite);



        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;
            PauseGame();
        }
    }
    private void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }

    void PauseGame()
    {
        if (gameIsPaused)
        {
            PauseScreen.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            PauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }

    private void HandleSpriteFlip()
    {
        if (!spriteRenderer.flipX && direction.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (spriteRenderer.flipX && direction.x > 0)
        {
            spriteRenderer.flipX = false;
        }

    }

}
