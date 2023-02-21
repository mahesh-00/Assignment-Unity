using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5;
    private int _noOfEnemies = 4;
    private Rigidbody _rb;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {

    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        _rb.AddForce(movement * _moveSpeed);
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("NPC"))
        {
            Destroy(other.gameObject);
            UIManager.Instance.OnEnemyKilled?.Invoke();
            _noOfEnemies--;
            if(_noOfEnemies<=0)
                UIManager.Instance.OnGameWon?.Invoke();
        }
            
    }


}
