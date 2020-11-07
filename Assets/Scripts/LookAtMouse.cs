using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    private void LateUpdate()
    {
        // get the mouse position in world space
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // change mouse Z position equal to this object's
        mousePos.z = transform.position.z;

        // get a rotation that points Z axis forward, and the Y axis towards the target
        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, (mousePos - transform.position));

        // apply new rotation
        transform.rotation = targetRotation;

        // rotate 90 degrees around the Z axis to point X axis instead of Y
        transform.Rotate(0, 0, 0);
    }
}