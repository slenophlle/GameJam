using UnityEngine;
using UnityEngine.AI;

public class TargetFollow : MonoBehaviour
{
    [Header("Transform")]
    public Transform Target;
    [SerializeField]
    public Transform[] Positions;

    private NavMeshAgent agent;
    private Animator animator;

    private int currentPatrolIndex = 0;
    private bool isFollowingPlayer = false;
    private float followTimer = 0f; // Takip s�resi i�in zamanlay�c�
    private float followDuration = 15f; // Player takip s�resi (saniye)

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        agent.updateRotation = false;
        agent.updateUpAxis = false;

        SetNextPatrolTarget();
    }

    private void Update()
    {
        if (isFollowingPlayer && Target != null)
        {
            agent.SetDestination(Target.position);
            if (followTimer > 0) followTimer -= Time.deltaTime; // Takip s�resi azalt�l�yor
            else StopFollowingPlayer(); // Zamanlay�c� bitti�inde devriye moduna ge�
        }
        else if (agent.remainingDistance < 0.5f)
        {
            SetNextPatrolTarget();
        }

        // Hareket y�n�n� hesapla ve animasyon parametrelerini g�ncelle
        Vector3 direction = agent.velocity;
        float horizontal = direction.x;
        float vertical = direction.y;

        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);
    }

    private void SetNextPatrolTarget()
    {
        if (Positions.Length == 0) return;

        Target = Positions[currentPatrolIndex].transform;
        agent.SetDestination(Target.position);
        currentPatrolIndex = (currentPatrolIndex + 1) % Positions.Length;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DetectionZone"))
        {
            // Player alan tetikleme collider'�na girdi
            Target = collision.transform;
            isFollowingPlayer = true;
            followTimer = followDuration; // Takip s�resini ba�lat
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("DetectionZone"))
        {
            // Player alan tetikleme collider'�ndan ��kt�
            followTimer = followDuration; // Saya� ba�lat
        }
    }

    private void StopFollowingPlayer()
    {
        isFollowingPlayer = false;
        SetNextPatrolTarget();
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(Positions[0].transform.position, 0.5f);
        Gizmos.DrawSphere(Positions[1].transform.position, 0.5f);
        Gizmos.DrawSphere(Positions[2].transform.position, 0.5f);
        Gizmos.DrawSphere(Positions[3].transform.position, 0.5f);
        Gizmos.DrawSphere(Positions[4].transform.position, 0.5f);
        Gizmos.color = Color.red;
    }
}
