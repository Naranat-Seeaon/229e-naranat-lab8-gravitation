using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ShootRay : MonoBehaviour
{
    [SerializeField] private Transform shootPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    [SerializeField] private GameObject shootVfxPrefab;
    [SerializeField] private GameObject hitVfaxPrefab;

    void Shoot()
    {
        RaycastHit hit;

        Debug.DrawRay(shootPos.position,transform.forward * 30, Color.red);

        if (Physics.Raycast(shootPos.position, transform.forward,out hit,30  ))
        {
            Debug.DrawRay(shootPos.position, transform.forward * hit.distance, Color.blue);

            //Debug.Log($"Ray hits: {hit.collider.name}");

            if (Mouse.current.rightButton.wasPressedThisFrame)
            {
                var shootVfx = Instantiate(shootVfxPrefab, shootPos.position, Quaternion.identity);

                var hitVfx = Instantiate(hitVfaxPrefab, hit.point , Quaternion.identity);
                 
                Destroy(shootVfx, 3.5f);
                Destroy(hitVfx, 2f);

                if (hit.collider.tag == "Enemy")
                {
                    Enemy enemy= hit.collider.GetComponent<Enemy>();
                    if (enemy != null)
                    {
                        enemy.TakeDamage();
                    }
                }
            }

        }
        
    }
}
