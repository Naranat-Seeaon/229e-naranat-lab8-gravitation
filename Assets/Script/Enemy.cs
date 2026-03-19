using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health = 50;
    [SerializeField] private int damage = 10;
    [SerializeField] private GameObject destroyVfaxPrefab;

    public void TakeDamage()
    {
        health -= damage;

        print($"{name} took {damage} damage");

        if (health <= 0)
        {
            Destroy(gameObject, 1f);
            Instantiate(destroyVfaxPrefab,transform);
        }
    }
}
