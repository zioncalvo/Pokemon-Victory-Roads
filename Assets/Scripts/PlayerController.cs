using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public LayerMask noMovementLayer;
    public LayerMask grassLayer;
    public bool isMoving = false;

    private Vector2 input;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
    }

    void Update()
    {

        if (!isMoving) 
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if (input.x != 0) 
            { 
                input.y = 0;
            }

            if (input != Vector2.zero)
            {

                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y); 

                var moveToPoint = transform.position;
                moveToPoint.x += input.x;
                moveToPoint.y += input.y;

                if (IsWalkable(moveToPoint)) 
                {
                    StartCoroutine(Move(moveToPoint));
                }

            }  
        }

        animator.SetBool("isWalkingAnimation", isMoving);
    }

    IEnumerator Move(Vector3 moveToPoint) 
    {
        isMoving = true;
        
        while((moveToPoint - transform.position).sqrMagnitude > Mathf.Epsilon) {
            transform.position = Vector3.MoveTowards(transform.position, moveToPoint, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = moveToPoint;
        CheckForEncounter(moveToPoint);
        isMoving = false;

    }

    private bool IsWalkable(Vector3 moveToPoint)
    {
        if(Physics2D.OverlapCircle(moveToPoint, 0.2f, noMovementLayer) != null)
        {
            return false;
        }
        return true;
    }

    public void CheckForEncounter(Vector3 moveToPoint)
    {
        if(Physics2D.OverlapCircle(moveToPoint, 0.2f, grassLayer) != null)
        {
            if(Random.Range(1, 101) <= 10)
            {
                SceneManager.LoadScene("PokemonBattle");
            }
        }
        
	}
    
}
