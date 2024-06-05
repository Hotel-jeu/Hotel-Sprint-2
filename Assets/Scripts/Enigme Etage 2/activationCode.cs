using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activationCode : MonoBehaviour
{
    // Le code qui existe dans l'affiche au début
    public GameObject codeAffiche;
    // ID unique a chaque objet pour eviter de recommencer lenigme a chaque fois
    public int ID;
    // Un Hash Set statique auquel on ajout les ID des codes obtenus
    public static HashSet<int> codesObtenus = new HashSet<int>();
    // Start is called before the first frame update
    void Start()
    
    {   // Si le Hash Set a l'ID de l'item, on active la photo a activer, et on detruit cet objet
        if (codesObtenus.Contains(ID)) {
            codeAffiche.SetActive(true);
            Destroy(gameObject);
        } 
        // Si il ne contient pas l'id, desactive le code a activer comme d'habitude
        else {
            codeAffiche.SetActive(false);
        }
        
    }

    // Fonction publique qui peut être appelé d'autre script qui sert à activer le code
    public void ActiverCode() {
        // Affiche le code de l'affiche
        codeAffiche.SetActive(true);
        // Rajoute un point caché (À 6 points, donc 6 code trouvé il a réussi)
        gestionEnigme2.codesTrouver++;
        // Ajoute l'id du code dans les codes obtenus
        codesObtenus.Add(ID);
        // Détruit l'objet (Car on appelle la fonction quand il prend le code dans la chambre)
        Destroy(gameObject);
    }
}
