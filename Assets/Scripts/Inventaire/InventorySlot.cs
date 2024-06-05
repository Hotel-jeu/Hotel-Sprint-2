using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    // Quand un objet est glissé sur lui
    public void OnDrop(PointerEventData eventData) {
        // Référence au GameObject glissé sur lui (Le slot)
        GameObject droppedGameObject = eventData.pointerDrag;
        // Prend l'InventoryItem de cet objet
        InventoryItem draggedItem = droppedGameObject.GetComponent<InventoryItem>();
        // Stocke le transform de son parent
        Transform draggedItemParent = draggedItem.parentAfterDrag;

        // Si l'objet contient un script d'inventory Item
        if (draggedItem != null) {
            
            // Regarde si le slot a déjà un objet comme enfant
            InventoryItem existingItem = GetComponentInChildren<InventoryItem>();
            
            // Si il en possède un, et que l'objet glissé et existant ne sont pas pareils 
            if (existingItem != null && existingItem != draggedItem) {
                // Donne comme valeur au parentAfterDrag de l'objet glissé, ce slot
                draggedItem.parentAfterDrag = transform;
                // Et donne comme valeur au parentAfterDrag de l'objet existant, le slot de l'objet glissé
                // Pris auparavant
                existingItem.parentAfterDrag = draggedItemParent;
                // Appelle SwapItems pour interchanger la place des deux items
                SwapItems(draggedItem, existingItem);

            } else if (existingItem == null) {
                // Si le slot est vide, met comme nouveau parent à l'objet glissé ce slot
                draggedItem.parentAfterDrag = transform;
            }
        }
    }
    // Interchange deux objets en leur donnant comme parent leur variable parentAfterDrag
    private void SwapItems(InventoryItem Objet_1, InventoryItem Objet_2) {
        Objet_1.gameObject.transform.SetParent(Objet_1.parentAfterDrag);
        Objet_2.gameObject.transform.SetParent(Objet_2.parentAfterDrag);
    }
}


