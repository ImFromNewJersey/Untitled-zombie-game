using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.AI;

public class Target : MonoBehaviour
{
    public float health;
    public NavMeshAgent Enemy;
    public Animator EnemyAnim;
    public float DespawnTimer = 2f;

    private void Start()
    {
        //walkCycle();
        health = GameObject.FindWithTag("Game Manager").GetComponent<Waves>().health;
        setRigidbodyState(true);
        setColliderState(false);
    }


    void Update()
    {
        Enemy.SetDestination(GameObject.FindWithTag("Player").transform.position);
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        GameObject.FindWithTag("Game Manager").GetComponent<Score>().score += 10;
        if (health <= 0f)
        {
            GameObject.FindWithTag("Game Manager").GetComponent<Score>().score += 50;
            Die();
        }
    }

    void Die()
    {
        GetComponent<Animator>().enabled = false;
        setRecursiveLayer(gameObject);
        setRigidbodyState(false);
        setColliderState(true);
        Enemy.isStopped = true;
        Destroy(gameObject, DespawnTimer);

    }

    void setRigidbodyState(bool state)
    {
        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();

        foreach(Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = state;
        }

        GetComponent<Rigidbody>().isKinematic = !state;

    }

    void setColliderState(bool state)
    {
        Collider[] colliders = GetComponentsInChildren<Collider>();

        foreach (Collider collider in colliders)
        {
            collider.enabled = state;
        }

        GetComponent<Collider>().enabled = !state;
    }

    void setRecursiveLayer(GameObject obj)
    {
        if(gameObject == null)
        {
            return;
        }
        else
            obj.layer = LayerMask.NameToLayer("DeadZombie");

        foreach (Transform child in obj.transform)
        {
            if(child == null)
            {
                continue;
            }
            setRecursiveLayer(child.gameObject);
        }
    }

    void walkCycle()
    {
        if (Random.Range(0.0f, 1.0f) < 0.5)
            EnemyAnim.SetInteger("WalkCycle", 1);
        else
            EnemyAnim.SetInteger("WalkCycle", 2);
    }

}
