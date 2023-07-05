using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    Idle,
    Wood,
    Iron,
    Balloon
};

public class PlayerController : MonoBehaviour
{
    [Tooltip("         "), SerializeField]
    public State myState;
    public GameObject Ball;
    Rigidbody2D rigidBody;
    FirePropagation fire;
    new SpriteRenderer renderer;
    [Tooltip(" ⺻500"), SerializeField]
    private float moveSpeed;
    bool isJumping;

    private bool moveState = true;
    public bool MoveState
    {
        get { return moveState; }
        set { moveState = value; }
    }

    //애니메이션을 위한 변수
    Animator PlayerAnim;

    [SerializeField]
    private Animator[] AnimGimmik;  //애니메이터 담을 배열 기믹에 따라 바꿔줌

    protected void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        PlayerAnim = GetComponent<Animator>();
        fire = GetComponent<FirePropagation>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (myState == State.Balloon) return;
        if( MoveState ) { InputKey(); }
    }

    /// <summary>
    /// Ű  Է   ޱ 
    /// </summary>
    protected virtual void InputKey()
    {
        float h = Input.GetAxisRaw("Horizontal");
        Move(h);
        if ((Input.GetKeyDown(KeyCode.W)|| Input.GetKeyDown(KeyCode.Space)) && myState != State.Iron && !isJumping)
        {
            Jump();
        }
    }

    /// <summary>
    /// Idle, Wood, Iron         
    /// </summary>
    public virtual void Move(float h)
    {
        if (rigidBody.velocity.x < -1 && rigidBody.velocity.x > 1)
        {
            //PlayerAnim.SetBool("isRun", false);
            return;
        }

        PlayerAnim.SetBool("isRun", true);
        rigidBody.AddForce(Vector2.right * h * Time.deltaTime * moveSpeed);

        if (h < 0)
        {
            renderer.flipX = true;
        }
        else if (h > 0)
        {
            renderer.flipX = false;
        }
        else
        {
            PlayerAnim.SetBool("isRun", false);
        }
    }

    /// <summary>
    /// Idle, Wood          
    /// </summary>
    public virtual void Jump()
    {
        //Ground                        ϰ 
       
        PlayerAnim.SetBool("isJump", true);
        //PlayerAnim.SetTrigger("Jump");
        rigidBody.AddForce(Vector2.up * 300);
        isJumping = true;
        //사운드 입력
        SoundManager soundController = SoundManager.s_Instance;
        soundController.onPlayJumpState();//추가
    }

    /// <summary>
    /// state    
    /// </summary>
    /// <param name="state"></param>
    protected virtual void SetState(State state)
    {
        if (state == myState) return;
        myState = state;
        switch (myState)
        {
            case State.Balloon:
                rigidBody.gravityScale = -0.5f;
                rigidBody.mass = 1;
                rigidBody.drag = 0.2f;
                rigidBody.velocity = Vector2.zero;
                PlayerAnim.SetTrigger("ToBalloon");
                fire.extinguish();
                //renderer.color = Color.yellow;
                break;
            case State.Iron:
                rigidBody.gravityScale = 1;
                rigidBody.mass = 10f;
                rigidBody.drag = 0.4f;
                PlayerAnim.SetTrigger("ToIron");
                fire.extinguish();
                //renderer.color = Color.gray;
                break;
            case State.Idle:
                rigidBody.gravityScale = 1;
                rigidBody.mass = 1;
                rigidBody.drag = 0.4f;
                PlayerAnim.SetTrigger("ToIdle");
                fire.extinguish();
                //renderer.color = Color.white;
                break;
            case State.Wood:
                rigidBody.gravityScale = 1;
                rigidBody.mass = 1;
                rigidBody.drag = 0.4f;
                PlayerAnim.SetTrigger("ToWood");
                //renderer.color = new Color(1, 0.5f, 0);
                break;
        }
    }
    public virtual void SetState(string state)
    {
        State newState = (State)System.Enum.Parse(typeof(State), state);
        if (myState == newState) return;
        myState = newState;
        switch (myState)
        {
            case State.Balloon:
                rigidBody.gravityScale = -0.5f;
                rigidBody.mass = 1;
                rigidBody.drag = 0.2f;
                rigidBody.velocity = Vector2.zero;
                PlayerAnim.SetTrigger("ToBalloon");
                fire.extinguish();
                moveSpeed = 700;
                //renderer.color = Color.yellow;
                break;
            case State.Iron:
                rigidBody.gravityScale = 1;
                rigidBody.mass = 10f;
                rigidBody.drag = 0.4f;
                PlayerAnim.SetTrigger("ToIron");
                fire.extinguish();
                moveSpeed = 5000;
                //renderer.color = Color.gray;
                break;
            case State.Idle:
                rigidBody.gravityScale = 1;
                rigidBody.mass = 1;
                rigidBody.drag = 0.4f;
                PlayerAnim.SetTrigger("ToIdle");
                fire.extinguish();
                moveSpeed = 700;
                //renderer.color = Color.white;
                break;
            case State.Wood:
                rigidBody.gravityScale = 1;
                rigidBody.mass = 1;
                rigidBody.drag = 0.4f;
                moveSpeed = 700;
                PlayerAnim.SetTrigger("ToTree");
                //renderer.color = new Color(1, 0.5f, 0);
                break;
        }
    }
    public bool CanBreak()
    {
        if (myState == State.Iron && rigidBody.velocity.magnitude < -5)
        {
            Debug.Log("break");
            Destroy(gameObject);
            return true;
        }
        return false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            PlayerAnim.SetBool("isJump", false);
        }
    }
}