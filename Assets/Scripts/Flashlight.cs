using UnityEngine;

public class Flashlight : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.transform.tag == "Enemy")
        {
            EnemyFollow enemy = other.gameObject.GetComponent<EnemyFollow>();
            enemy.SetHealth(-0.05f);
        }
    }
}
