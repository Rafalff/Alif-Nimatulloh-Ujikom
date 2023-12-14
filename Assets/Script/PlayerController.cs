using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Animator animator;
    [SerializeField] private float _moveSpeed = 1000f;

    [SerializeField] GameObject _projectile;
    [SerializeField] GameObject _projectileSpawnArea;

    [SerializeField] private float _projectileSpeed = 300;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Throw();
    }

    private void Movement() {
        float horizontal = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(horizontal, 0, 0);

        rb.velocity = movement * _moveSpeed * Time.deltaTime;

        if (horizontal > 0) {
            animator.SetBool("StrafeRight", true);
            animator.SetBool("StrafeLeft", false);
            animator.SetBool("Iddle", false);
        }
        else if(horizontal < 0) {
            animator.SetBool("StrafeRight", false);
            animator.SetBool("StrafeLeft", true);
            animator.SetBool("Iddle", false);
        } else {
            animator.SetBool("Iddle", true);
        }
    }

    private void Throw() {
        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) {
            GameObject foodThrown;

            foodThrown = Instantiate(_projectile, _projectileSpawnArea.transform.position, Quaternion.identity);
            Rigidbody rbProjectile = foodThrown.GetComponent<Rigidbody>();

            var speed = _projectileSpeed * Time.deltaTime;

            Vector3 location = new Vector3(0,0, 50);
            rbProjectile.velocity = location;

            Destroy(foodThrown, 3f);
        }
    }
}
