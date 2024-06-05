using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    // Liste qui contient une référence à tous les item du jeu
    public List<Item> allItems;

    // Trouve un item selon son ID
    public Item FindItemByID(int id)
    {
        // Regarde tous les item de la liste des objets
        foreach (Item item in allItems)
        {
            // Si l'ID envoyé est égal à l'un deux
            if (item.ID == id)
            {
                // Retourne l'item (Qui sera utilisé)
                return item;
            }
        }
        // Retourne null si aucune ressemblance est trouvé
        return null;
    }
}
