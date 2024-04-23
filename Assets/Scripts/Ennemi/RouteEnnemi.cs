using UnityEngine;
using UnityEngine.AI;

public class RouteEnnemi : MonoBehaviour
{
    public Transform[] passages;
    private int passageIndex = 0;
    private NavMeshAgent agent;
    public Transform Joueur;
    public float chassePortee = 10.0f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        allerAuProchainPassage();
    }

    void Update()
    {
        float distanceJoueur = Vector3.Distance(Joueur.position, transform.position);

        if (distanceJoueur < chassePortee && voitJoueur())
        {
            agent.SetDestination(Joueur.position);
        }
        else if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            allerAuProchainPassage();
        }
    }

    void allerAuProchainPassage()
    {
        if (passages.Length == 0)
            return;

        agent.SetDestination(passages[passageIndex].position);
        print("go : "+ passageIndex); 
        passageIndex = (passageIndex + 1) % passages.Length;
    }

    bool voitJoueur()
    {
        RaycastHit hit;
        Vector3 directionToJoueur = (Joueur.position - transform.position).normalized;

        if (Physics.Raycast(transform.position, directionToJoueur, out hit, chassePortee))
        {
            if (hit.transform.CompareTag("player"))
            {
                return true;
            }
        }
        return false;
    }
}
