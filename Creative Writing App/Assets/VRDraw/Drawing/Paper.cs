using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Paper : MonoBehaviour
{
    [SerializeField]
    private UnityEvent OnDraw = null;

    [SerializeField]
    private UnityEvent OnDrawExit = null;

    #region triggers
    

    private void OnTriggerEnter(Collider other)
    {
         Debug.Log(other.gameObject);
        
    }
    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "PenTip")
        {
            OnDraw?.Invoke();

            var position = new Vector3(other.transform.position.x, this.transform.position.y+0.001f, other.transform.position.z) ;

            DrawManager.Instance.Draw(position);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "PenTip")
        {
            OnDrawExit?.Invoke();

            DrawManager.Instance.StopDraw();
        }
    }
    
    #endregion

    /*
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject);
    }

    private void OnCollisionStay(Collision collision)
    {
        DebugManager.Instance.LogInfo($"Collided");

        if (collision.gameObject.tag == "PenTip")
        {
            DebugManager.Instance.LogInfo($"drawing");

            OnDraw?.Invoke();

            var position = collision.transform.position;

            DrawManager.Instance.Draw(position);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "PenTip")
        {
            OnDrawExit?.Invoke();
        }
    }
    */
}
