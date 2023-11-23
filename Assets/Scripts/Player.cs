using System.Collections;
using UnityEngine;
using DG.Tweening;
using System.Linq;

namespace Assets.Scripts
{
    public class Player : MonoBehaviour
    {
        // movimiento
        public float hp=500,moveSpeed,jumpForce,gravity=9.8f,bombaImpulso=5;
        public int cantidadDeBombas = 5;
        public CharacterController characterController;
        public Transform chek;
        public bool isGrounded;
        public Pistol pistol;
        public float maxHP = 500;
        public static Player instance;
        [SerializeField]GroundChecker groundChecker;
        [SerializeField] GameObject bombaPrefab;
        string currentState;
        //public Rigidbody rb;
        // animacion
        public Animator animator;

        // sonido
        private void Awake()
        {
            if (instance == null) instance = this;
        }
        void Update()
        {
           // if (animator.GetBool("AtkB") is true || animator.GetBool("AtkB1") is true || animator.GetBool("AtkB2") is true) return;
                float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
            movementDirection = transform.TransformDirection(movementDirection);
            movementDirection *= moveSpeed* Time.deltaTime;

            bool gr = isGrounded;
            // rb.MovePosition(rb.position + movementDirection);
             //transform.Rotate(0, horizontalInput * 100f * Time.deltaTime, 0);
            if(gr is false) movementDirection.y -= gravity* Time.deltaTime;
            if (Input.GetButtonDown("Jump") && gr)
            {
                 movementDirection.y += jumpForce;
                //animator.SetTrigger("jump");
                //transform.DOJump(new Vector3(transform.position.x, transform.position.y , transform.position.z), jumpForce, 1,1);
                //rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
            }
            if (movementDirection != Vector3.zero)
            {
                characterController.Move(movementDirection);
                animator.SetBool("run", true);
            }
            else if (movementDirection == Vector3.zero) animator.SetBool("run", false);
            //print($"is grounded : {gr}");
        }
        public void LanzarBomba()
        {
            if (cantidadDeBombas <= 0) return;
            //animator.SetTrigger("lanzarBomba");
            var obj = Instantiate(bombaPrefab, transform.position, transform.parent.rotation);
            print(new Vector3(0,transform.parent.rotation.y + bombaImpulso / 3,
                bombaImpulso) * bombaImpulso    );

            obj.GetComponent<Rigidbody>().AddForce(Vector3.forward * bombaImpulso, ForceMode.Impulse);
        }
       

    }
}