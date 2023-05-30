using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileShooter : MonoBehaviour
{
   public GameObject projectilePrefab;
   public GameObject TrashBagPrefab;
    public Transform projectileSpawnPoint; 
    public float shootingInterval = 5f;
    public float TrashBagInterval = 15f;
    public GameObject playerCharacter; 
    private float timer = 0f;
    private float timer2 = 0f;
    private bool alive;

    void Start()
    {
        alive = true;
    } 

    private void Update()
    {
        if(alive){
        timer += Time.deltaTime; // Increment the timer
        timer2 += Time.deltaTime;
        // Check if it's time to shoot
        if (timer >= shootingInterval)
        {
            ShootProjectile();
            timer = 0f; // Reset the timer
        }else if(timer2 >= TrashBagInterval)
        {
            ShootTrashBag();
            timer2 = 0f;
        }}
    }

    private void ShootProjectile()
    {
        Vector2 direction = playerCharacter.transform.position - projectileSpawnPoint.position;
        direction.Normalize();

        GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity);
        Rigidbody2D projectileRigidbody = projectile.GetComponent<Rigidbody2D>();
        projectileRigidbody.velocity = direction * 10f;
        projectileRigidbody.AddForce(direction * 14f, ForceMode2D.Impulse);
    }

    private void ShootTrashBag()
    {
        GameObject TrashBagProjectile = Instantiate(TrashBagPrefab, transform.position, Quaternion.identity);
        float randomAngle = Random.Range(0f, Mathf.PI * 2);
        Vector2 randomDirection = new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle));
        randomDirection.Normalize();
        Rigidbody2D TrashprojectileRigidbody = TrashBagProjectile.GetComponent<Rigidbody2D>();
        TrashprojectileRigidbody.velocity = randomDirection * 10f;
        TrashprojectileRigidbody.AddForce(randomDirection * 14f, ForceMode2D.Impulse);
    }


    public void setAliveFalse(){
        alive = false;
    }
}
