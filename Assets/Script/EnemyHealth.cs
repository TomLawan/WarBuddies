using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3; // Ilang tira bago mamatay (pwede mong baguhin sa Inspector)
    private int currentHealth;

    void Start()
    {
        // Sa simula, ang health ay puno
        currentHealth = maxHealth;
    }

    // Function na tatawagin ng Bala kapag tinamaan ang Enemy
    public void TakeDamage(int damageAmount)
    {
        // Bawasan ang health
        currentHealth -= damageAmount;

        // Optional: Mag-print sa console para makita mo kung ilan na lang buhay
        Debug.Log("Enemy Health: " + currentHealth);

        // Check kung ubos na ang buhay
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Dito pwede ka mag-play ng death sound o explosion effect bago sirain
        Destroy(gameObject);
    }
}
