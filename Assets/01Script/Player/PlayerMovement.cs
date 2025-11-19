using UnityEngine;

public class PlayerMovement : MonoBehaviour ,IMovement
{
    private bool isMoving = false;
    [SerializeField] private float moveSpeed = 5f;

    private Vector2 minArea = new Vector2(-2f, 4.5f);
    private Vector2 maxArea = new Vector2(2f,0f);

    private Vector3 moveDelta;

    public void Move(float delta , Vector2 direction)
    {
        if(isMoving)
        {
            moveDelta = new Vector3(direction.x, direction.y, 0f) * (moveSpeed * delta);
            

            Vector3 newPos = transform.position + moveDelta;



            // 이동 범위 제한

            newPos.x = Mathf.Clamp(newPos.x, minArea.x, maxArea.x);
            newPos.y = Mathf.Clamp(newPos.y, maxArea.y, minArea.y);

            transform.position = newPos;
        }
    }

    public void SetEnable(bool newEnable)
    {
        isMoving = newEnable;
    }

   
}
