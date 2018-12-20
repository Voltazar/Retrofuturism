using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    public float moveSpeed;
    private float currentMoveSpeed;
    public float diagnoalMoveModifier;

    private Animator anim;
    private Rigidbody2D myRigitbody;

    private bool attacking;
    public float attackTime;
    private float attackTimeCounter;

    private static bool playerExists;
    public string startPoint;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        myRigitbody = GetComponent<Rigidbody2D>();

        if(!playerExists){
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        } else {
            Destroy(gameObject);
        }

	}

    private bool playerMoving;
    public Vector2 lastMove;
    // Update is called once per frame
    void Update () {

        if (!attacking)
        {

            playerMoving = false;

            if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
            {
                //transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
                myRigitbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * currentMoveSpeed, myRigitbody.velocity.y);
                lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
                playerMoving = true;

            }

            if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
            {
                //transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
                myRigitbody.velocity = new Vector2(myRigitbody.velocity.x, Input.GetAxisRaw("Vertical") * currentMoveSpeed);
                lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
                playerMoving = true;

            }

            if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
            {
                myRigitbody.velocity = new Vector2(0f, myRigitbody.velocity.y);
            }

            if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
            {
                myRigitbody.velocity = new Vector2(myRigitbody.velocity.x, 0f);
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                attackTimeCounter = attackTime;
                attacking = true;
                myRigitbody.velocity = Vector2.zero;
                anim.SetBool("Attack", true);

            }

            if(Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f && Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5f){

                currentMoveSpeed = moveSpeed * diagnoalMoveModifier; 
            } else {
                currentMoveSpeed = moveSpeed;
            }
            

        }

        if(attackTimeCounter > 0){
            attackTimeCounter -= Time.deltaTime;
        } else{
            attacking = false;
            anim.SetBool("Attack", false);
        }

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
    }
}
