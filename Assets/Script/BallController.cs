using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float lifeTime;
    Rigidbody2D rb;
    Vector2 direction;
    private SpriteRenderer spriteRenderer;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start(){
        rb.velocity = transform.up * speed; 
    }

    void Update() {
        lifeTime -= Time.deltaTime;
        if(lifeTime <= 0)
            DestroyBall();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        DestroyBall();
    }

    void DestroyBall(){
        LevelManger.Instance.UpdateNoOfBallsLeft();
        Destroy(gameObject);
    }
    public void ChangeLife() 
    {
        lifeTime -= 5;
        Debug.Log(speed);
    }
    public void ChangeColor(Color newColor)
    {
        spriteRenderer.color = newColor;
    }
}
