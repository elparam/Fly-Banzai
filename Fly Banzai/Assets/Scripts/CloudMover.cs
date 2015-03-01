using UnityEngine;

public class CloudMover : MonoBehaviour
{
    public float Speed;
    public Sprite[] Sprites;

    void Start()
    {
        ChangeCloudSprite();
    }

    void Update()
    {
        MoveCloud();
        DestroyNotOnScreen();
    }

    private void ChangeCloudSprite()
    {
        var sriteRenderer = renderer as SpriteRenderer;
        if (sriteRenderer != null)
            sriteRenderer.sprite = Sprites[Random.Range(0, Sprites.Length)];
    }

    private void MoveCloud()
    {
        if (gameObject != null)
        {
            gameObject.rigidbody2D.velocity = -Vector2.right * Speed * Time.deltaTime;
        }
    }

    private void DestroyNotOnScreen()
    {
        if (transform.position.x < -35f)
        {
            Destroy(gameObject);
        }
    }
}
