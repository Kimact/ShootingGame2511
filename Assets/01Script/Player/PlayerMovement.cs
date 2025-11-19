using UnityEngine;

public class PlayerMovement : MonoBehaviour ,IMovement
{
    private bool isMoving = false;
    [SerializeField] private float moveSpeed = 5f;

    private Vector2 minArea = new Vector2(-2f, 4.5f);
    private Vector2 maxArea = new Vector2(2f,0f);

    private Vector3 moveDelta;

    public void Move(Vector2 direction)
    {
        if(isMoving)
        {
            moveDelta = new Vector3(direction.x, direction.y, 0f) * (moveSpeed * Time.deltaTime);
            
            Vector3 newPos = transform.position + moveDelta;


        }
    }

    public void SetEnable(bool newEnable)
    {
        throw new System.NotImplementedException();
    }

   
}
