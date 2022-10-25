using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 2.5f;

    private Rigidbody2D _rigidbody;
    private Animator _animator;

    private Vector2 _moviment;
    private bool _facingRight = true;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        _moviment = new Vector2(horizontalInput, 0f);

        if (horizontalInput < 0f && _facingRight) {
            Flip();
        } else if(horizontalInput > 0f && !_facingRight) {
            Flip();
        }
    }

    void FixedUpdate()
    {
        float horizontalVelocity = _moviment.normalized.x * speed;
        _rigidbody.velocity = new Vector2(horizontalVelocity, _rigidbody.velocity.y);
    }

    void LateUpdate()
    {
        _animator.SetBool("Idle", _moviment == Vector2.zero);
    }

    private void Flip()
    {
        _facingRight = !_facingRight;
        float localScaleX = transform.localScale.x;
        localScaleX = localScaleX * -1;
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }
}
