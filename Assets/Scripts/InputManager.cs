using System;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    public UnityEvent<Vector2> OnMove = new UnityEvent<Vector2>();
    public UnityEvent OnSpacePressed = new UnityEvent();
    public UnityEvent OnResetPressed = new UnityEvent();

    private void Update()
    {
        // Debug.Log($"[InputManager] Update - Time.frameCount: {Time.frameCount}");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("[InputManager] Space Key Down");
            OnSpacePressed?.Invoke();
        }

        Vector2 input = Vector2.zero;
        if (Input.GetKey(KeyCode.A))
        {
            input += Vector2.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            input += Vector2.right;
        }
        if (input != Vector2.zero)
        {
            Debug.Log($"[InputManager] OnMove Invoke: {input}");
        }

        OnMove?.Invoke(input);

        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("[InputManager] R Key Down");

            OnResetPressed?.Invoke();
        }
    }
}
