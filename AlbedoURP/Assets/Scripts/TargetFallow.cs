using UnityEngine;
using UnityEngine.AI;

public class TargetFollow : MonoBehaviour
{
    public Transform Target;
    private NavMeshAgent agent;
    private Animator animator;

    private void Start()
    {
        if (Target == null)
        {
            GameObject player = GameObject.FindWithTag("Player"); // Player'� tag ile bul
            if (player != null)
            {
                Target = player.transform;
            }
        }

        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
        if (Target != null)
        {
            agent.SetDestination(Target.position);

            // D��man�n hareket y�n�n� hesapla
            Vector3 direction = agent.velocity;
            float horizontal = direction.x;
            float vertical = direction.y;

            // Animasyon parametrelerini g�ncelle
            animator.SetFloat("Horizontal", horizontal);
            animator.SetFloat("Vertical", vertical);
        }
    }
}
