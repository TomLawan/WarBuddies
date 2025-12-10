using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 2f; // Mawawala ang bala after 2 seconds kung walang tinamaan
    public int damage = 1; // Gaano kasakit ang bawat bala

    void Start()
    {
        // Kusang sisirain ang bala para hindi bumigat ang game
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        // Pagalawin ang bala paharap (Right or Up depende sa rotation ng player mo)
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    // Dito mangyayari ang detection ng tama
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // Check kung ang tinamaan ay Enemy
        if (hitInfo.CompareTag("Enemy"))
        {
            // Hanapin ang EnemyHealth script sa tinamaang object
            EnemyHealth enemy = hitInfo.GetComponent<EnemyHealth>();

            // Kung may EnemyHealth script siya, bawasan ang buhay
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            // Sirain ang sarili (Bala)
            Destroy(gameObject);
        }
    }
}