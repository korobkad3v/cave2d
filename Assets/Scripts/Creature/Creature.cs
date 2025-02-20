using UnityEngine;

public class Creature : MonoBehaviour
{
    [SerializeField]   
    protected int health = 3;
    [SerializeField]
    protected int damage = 1;
    public int Damage { get { return damage; } protected set { damage = value; } }

    [SerializeField]
    protected float speed = 1;
    public float MoveSpeed
    { get { return speed; } protected set { speed = value; } }

    protected Animator anim;
    public Animator Anime { get { return anim; } protected set { anim = value; } }

    protected Rigidbody2D rb;
    public Rigidbody2D RB { get { return rb; } protected set { rb = value; } }

    protected SpriteRenderer spriteRenderer;
    public SpriteRenderer SpriteRenderer { get { return spriteRenderer; } protected set { spriteRenderer = value; } }

    [SerializeField]
    protected bool isDead = false; 
    public bool IsDead { get { return isDead; } protected set {  isDead = value; } }
    public void TakeDamage(int damage)
    {
        health -= damage;
        anim.SetTrigger("Hurt");

        if (health <= 0)
        {
            Die();
        }
    }

    

    protected virtual void Die()
    {

        anim.SetBool("isDead", isDead = true);
        GetComponent<Collider2D>().enabled = false;
        rb.velocity = Vector3.zero;
        rb.isKinematic = true;
        GetComponent<EnemyPatrol>().enabled = false;
        this.enabled = false;
        
        
    }


    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

}
