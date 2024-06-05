using UnityEngine;
using UnityEngine.AI;

public class RouteEnnemi : MonoBehaviour
{
    // Des positions choisis ou l'ennemi peut aller, de position en position
    public Transform[] passages;
    // Index du passage (Du tableau en haut)
    private int passageIndex = 0;
    // Le navmesh Agent de l'ennemi
    private NavMeshAgent agent;
    // Position du joueur
    public Transform Joueur;
    // La portée de la chasse de l'ennemi
    public float chassePortee = 10.0f;

    public AudioClip sonEnnemiMarche;
    public AudioClip sonEnnemiChasse;

    // Si l'ennemi est en train de chase le joueur ou pas pour éviter de mettre l'audio 50 fois
    private bool EnChasse = false;

    // Si l'ennemi est ralenti ou pas
    public bool attraper = false;

    public float viewRadius = 10f;
    public float viewAngle = 120f;

    void Start()
    {
        // Met l'agent ici pour raccourcir les futur ligne de code
        agent = GetComponent<NavMeshAgent>();
        // Appelle la fonction qui envoie l'ennemi au prochain passage
        allerAuProchainPassage();
    }

    void Update()
    {
        Debug.Log(voitJoueur());

        if (!attraper) {
            // Calcule la distance entre le joueur et l'ennemi
            float distanceJoueur = Vector3.Distance(Joueur.position, transform.position);
            // Si la distance est moins que la distance de la chasse (10 pour le coup), et qu'il voit le joueur
            if (voitJoueur())
            {
               

                if (!EnChasse) {

                    EnChasse = true;
                    // Met le son de chasse si il voit le joueur et le course
                    GetComponent<AudioSource>().enabled = false;
                    GetComponent<AudioSource>().clip = sonEnnemiChasse;
                    GetComponent<AudioSource>().enabled = true;
                }

                // Augmente la vitesse de l'ennemi si il voit le joueur
                agent.speed = 5f;
                // Il met comme destination la position du joueur
                Debug.Log("Suit joueur");
                agent.SetDestination(Joueur.position);
                 
                
            }
            // Sinon, si l'ennemi n'est pas entrain de marcher vers une destination (Donc il est arrivé),
            // et que la distance restante avant la fin est moins de 0.5, il va à la prochaine
            // Pour que ça soit fluide et qu'il s'arrête pas un instant sans rien faire
            else if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {   
                Debug.Log("Plus mtn");
                EnChasse = false;
                // Met le son de chasse si il ne voit plus le joueur / marche normalement
                GetComponent<AudioSource>().enabled = false;
                GetComponent<AudioSource>().clip = sonEnnemiMarche;
                GetComponent<AudioSource>().enabled = true;
                // Remet la vitesse de l'ennemi normale quand il marche vers son prochain passage
                agent.speed = 2.5f;
                // Appelle la fonction qui envoie l'ennemi au prochain passage
                allerAuProchainPassage();
            }
        } else if (attraper) {
            agent.speed = 0f;
        }
        
    }

    // Fonction qui envoie l'ennemi au prochain passage
    void allerAuProchainPassage()
    {   
        // Si il n'y a aucun passage de mis dans unity, arrête la fonction
        if (passages.Length == 0) {
            return;
        }
            
        // Envoie le personnage au passage avec l'index dans le tableau de tous les passages
        agent.SetDestination(passages[passageIndex].position);
        // Recalcule l'index du passage (Pour que ça fasse toujous de 0 à 6 puis recommence de 0 à 6),
        // 6 c'est le nombre de passage en ce moment, on peut ajouter+
        passageIndex = (passageIndex + 1) % passages.Length;
    }


    // Si il voit le joueur c'est true sinon c'est false
    bool voitJoueur()
    {
        Vector3 directionToPlayer = (Joueur.position - transform.position).normalized;

        // Check if the player is within the view angle
        if (Vector3.Angle(transform.forward, directionToPlayer) < viewAngle / 2)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, Joueur.position);

            // Check if the player is within the view radius
            if (distanceToPlayer < viewRadius)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, directionToPlayer, out hit, distanceToPlayer))
                {
                    if (hit.collider.gameObject.tag == "player")
                    {
                        Debug.Log("Player is in sight and no obstacles in the way.");
                        return true;
                    }
                    else if (hit.collider.gameObject.CompareTag("porte")) {
                        Debug.Log("il voit la porte");
                        return false;
                    } else {
                        Debug.Log($"View is blocked by: {hit.collider.gameObject.name} on layer {LayerMask.LayerToName(hit.collider.gameObject.layer)}");
                    }
                }
                else
                {
                    Debug.Log("Player is in sight and no obstacles in the way.");
                    return true;
                }
            }
        }
        return false;
    }

}
