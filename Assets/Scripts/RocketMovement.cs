using UnityEngine;

public class RocketMovement : MonoBehaviour {

    [SerializeField]
    private float speed = 1.0f;
    [SerializeField]
    private float xIncrement = 10.0f;

    private const float maxLeft = -2.7f;
    private const float maxRight = 2.7f;

    private Vector2 targetPos, start;
    private bool isMoving = false;

	void Update () {
        isMoving = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            targetPos = new Vector2(Mathf.Clamp(transform.position.x - xIncrement, maxLeft, maxRight), transform.position.y);
            
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            targetPos = new Vector2(Mathf.Clamp(transform.position.x + xIncrement, maxLeft, maxRight), transform.position.y);
        }

        if (isMoving)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        }
	}
}
