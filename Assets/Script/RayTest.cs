using UnityEngine;
 
public class RayTest : MonoBehaviour
{
    private void FixedUpdate()
    {
        Vector3 pos = gameObject.transform.position;
        pos.y = -5.0f;
        Debug.DrawRay(gameObject.transform.position, pos, Color.red, 0.1f);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, pos);
        Debug.Log(hit.distance);
    }
}