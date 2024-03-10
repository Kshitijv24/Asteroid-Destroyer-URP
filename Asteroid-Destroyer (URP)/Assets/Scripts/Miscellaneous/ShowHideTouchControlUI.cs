using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideTouchControlUI : MonoBehaviour
{
    [SerializeField] Canvas canvas;

    private void Update()
    {
        if(PlayerMovement.Instance.useMouseLook)
        {
            canvas.enabled = false;
        }
        else if(!PlayerMovement.Instance.useMouseLook)
        {
            canvas.enabled = true;
        }
    }
}
