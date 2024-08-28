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
            GameObject player = GameObject.FindWithTag("Player"); // Player'ý tag ile bul
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

            // Düþmanýn hareket yönünü hesapla
            Vector3 direction = agent.velocity;
            float horizontal = direction.x;
            float vertical = direction.y;

            // Animasyon parametrelerini güncelle
            animator.SetFloat("Horizontal", horizontal);
            animator.SetFloat("Vertical", vertical);
        }
    }
}
