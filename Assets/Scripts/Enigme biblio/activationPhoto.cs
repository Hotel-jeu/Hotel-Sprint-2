using System.Collections.Generic;
using UnityEngine;

public class activationPhoto : MonoBehaviour
{

    // Partie de la photo a activer dans la salle
    public GameObject Photo_A_Activer;
    // ID unique a chaque objet pour eviter de recommencer lenigme a chaque fois
    public int ID;
    // Un Hash Set statique auquel on ajout les ID des photos obtenus
    public static HashSet<int> Photos_Obtenus = new HashSet<int>();

    private void Start()
    {   
        // Si le Hash Set a l'ID de l'item, on active la photo a activer, et on detruit cet objet
        if (Photos_Obtenus.Contains(ID))
        {
            Photo_A_Activer.SetActive(true);
            Destroy(gameObject);
        } 
        // Si il ne contient pas l'id, desactive la photo A activer comme d'habitude
        else {
            Photo_A_Activer.SetActive(false);
        }
    }


    // Quand cette fonction est appeler, active la photo, augmente le nombre de photos trouver de 1,
    // ajoute l'ID au Hash Set pour eviter de recommencer, et detruit l'objet
    public void ActiverPhoto()
    {
        Photo_A_Activer.SetActive(true);
        gestionEnigmeBiblio.Nbr_Photos_Trouver++;
        Photos_Obtenus.Add(ID);
        Destroy(gameObject);
    }
}
