using UnityEngine;

public interface IScroller
{
    void ResetPosition();
    void Scroll(float deltaTime);
    void SetScrollSpeed(float newSpeed);
}
