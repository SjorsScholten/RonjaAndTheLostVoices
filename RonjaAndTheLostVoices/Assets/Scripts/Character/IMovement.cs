using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovement  {
    void Move(bool running, Vector2 motion);
    void Rotate(Vector2 direction);
    void Jump();
}
