using UnityEngine;
using System.Collections;
 
 public class Movement : MonoBehaviour {
     
     public float moveSpeed;

     //public float speed;
     public float jumpForce;
     bool grounded;
     bool standing;
     bool jumping;
     
     Animator animator;
     Rigidbody2D rb2D;

     void Start() {
         rb2D = GetComponent<Rigidbody2D>();
         grounded = true;
         jumping = false;
         standing = true;
         animator = GetComponent<Animator>();
            
         //moveSpeed = 10f;
     }
     void Update() {
         var move = new Vector3(moveSpeed * Input.GetAxis("Horizontal"), rb2D.velocity.y, 0);
          if (move.magnitude > 0) {
              standing = false;
          }  else {
              standing = true;
          }
        if (grounded) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                jumping = true;
                grounded = false;
                rb2D.AddForce(Vector2.up * jumpForce);
                }
                
            }

        if (move.x > 0) {
            GetComponent<SpriteRenderer>().flipX = false;
        } else if (move.x < 0) {
             GetComponent<SpriteRenderer>().flipX = true;
        }
         //rb2D.AddForce(Vector2.up * jumpForce);
         setAnimations(standing, grounded, jumping);   
        
         //transform.position += move * speed * Time.deltaTime;
         rb2D.velocity = move;
        
     }

     void setAnimations (bool standing, bool grounded, bool jumping){
         //Debug.Log(animator.name);
        animator.SetBool("standing", standing);
        animator.SetBool("jumping", jumping);
        animator.SetBool("grounded", grounded);
     }

     void OnTriggerStay2D(Collider2D col) {

         if (col.tag == "ground") {
             
             grounded = true;
         }
     }
 }