using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    // Variable qui décide combien de pile par objet maximum (3 dans notre cas)
    public int maxStackedItems = 3;
    // Les Slot (Place) d'objets, dans un tableau de script Inventory Slot
    public InventorySlot[] inventorySlots;
    // Prefab de l'objet contenant le scrip Inventory Item, c'est lui qui selon l'item, il change, c'est l'objet de notre UI
    public GameObject inventoryItemPrefab;

    // Liste statique qui stocke tous les items de l'inventaire
    public static List<ItemData> savedItemsData = new List<ItemData>();

    // Référence au script d'ItemManager (Sert à récuper l'item selon le ID)
    public ItemManager itemManager;

    // Référence à la main du joueur
    public GameObject MainJoueur;

    private void Start() {
        // Appelle la fonction qui met l'inventaire sauvegardé dans l'inventaire vide au début de la scène
        MettreInventaireSauvegarder();
    }

    // Fonction qui ajoute un objet dans le UI
    public bool AddItem(Item item) {

        // Regarde si le même objet est présent dans le UI afin d'Ajouter un count si c'est possible
        for (int i = 0; i < inventorySlots.Length; i++) {
            // Récupère l'objet dans chaque Slot
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            // Si l'objet existe, et que cet objet est le même que celui qu'on veut ajouter
            // Que sa pile est moins que la pile maximum possible, et qu'il est considéré comme stackable, donc empilable
            if (itemInSlot != null && 
                itemInSlot.item == item &&
                itemInSlot.count < maxStackedItems &&
                itemInSlot.item.stackable == true) {
                // Augmente le nombre d'objet de 1
                itemInSlot.count++;
                // Et rafraichit le nombre affiché en texte
                itemInSlot.RefreshCount();
                return true;    
            }
        }

        // Si aucune copie de l'objet utilisable n'est trouvé, cherche un slot vide dans lequel mettre l'objet
        for (int i = 0; i < inventorySlots.Length; i++) {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            // Si l'item à l'intérieur est null, donc n'existe pas
            if (itemInSlot == null) {
                // Utilise la fonction SpawnNewItem qui sert à rentrer un nouvel objet dans le UI
                // L'item est celui utilisé au début de la fonction, le slot, le premier vide trouvé
                SpawnNewItem(item, slot);
                return true;
            }
        }

        return false;
    }
    // Met un nouveau item dans le UI
    void SpawnNewItem(Item item, InventorySlot slot) {
        // Instantiate un nouveau objet, en utilisant le prefab d'objet, et lui donne la même position que le slot
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        // (Rendu là, le prefab est dessus) On prend le script Inventory Item, et on lance InitialiseItem de son script InventoryItem
        // En lui donnant l'item comme valeur (Lui donne la valeur d'item, et son image pour être correctement utilisé et affiché)
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item);
    }

    // Récupère l'info de l'objet en main
    public Item GetSelectedItem(bool use) {
        // Prend le premier slot, celui qui est considéré comme celui de la main principale
        // Et récupère l'objet à l'intérieur, son script Inventory Item surtout
        InventorySlot slot = inventorySlots[0];
        InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
        // Si cet objet existe
        if (itemInSlot != null) {
            // Crée une variable item, à laquelle on donne la valeur de l'objet dans le slot (Attribué dans le InitaliseItem plus tôt)
            Item item = itemInSlot.item;
            // Si la booleenne passée, est true, ça veut dire qu'on doit utilisé l'item
            if (use == true) {
                // Réduit le nombre d'objet de 1
                itemInSlot.count--;
                // Active l'animation de boire (Les seuls item qu'on ''use'' sont des objets qu'on boit)
                MainJoueur.GetComponent<Animator>().SetBool("Boire", true);
                // Si le son d'utilisation exist dans Item, joue le son
                if (item.sonUtilisation) {
                    GetComponent<AudioSource>().PlayOneShot(item.sonUtilisation);
                }
                // Si le nombre de la pile est à 0 ou moins, détruit l'objet après 1 seconde
                if (itemInSlot.count <= 0) {
                    Destroy(itemInSlot.gameObject, 1f);
                } else {
                    // Sinon rafraichit le compte
                    itemInSlot.RefreshCount();
                }
            }

            return item;
        }
        
        return null;
    }

    // Sauvegarde l'inventaire
    public void SauvegardeInventaire() {
        // Supprime tous les objets dans notre liste statique
        savedItemsData.Clear();
        // Pour chaque script InventorySlot dans notre tableau de slot
        foreach (InventorySlot slot in inventorySlots)
        {   
            // Prend l'objet à l'intérieur
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            // Si l'objet existe et que cet objet a une valeur d'item
            if (itemInSlot != null && itemInSlot.item != null)
            {   
                // Ajoute à la liste une classe, qui stocke l'ID ainsi que le compte de l'objet
                savedItemsData.Add(new ItemData(itemInSlot.item.ID, itemInSlot.count));
            }
        }
    }

    // Supprime l'inventaire
    public void SupprimerInventaire() {
        // Supprime tous les objets dans notre liste statique
        savedItemsData.Clear();
    }
    
    
    // Met l'inventaire sauvegardé dans l'inventaire vide au début de la scène
    public void MettreInventaireSauvegarder() {
        // Pour chaque ItemData dans la liste qui stocke les données des item à sauvegarder
        foreach (ItemData itemData in savedItemsData)
        {
            // Cherche l'item selon l'ID stocké dans le ItemData grâce au script ItemManager
            Item itemToAdd = itemManager.FindItemByID(itemData.ID);
            // Si l'item existe
            if (itemToAdd != null)
            {   
                // Cherche un slot libre où mettre l'objet
                foreach (InventorySlot slot in inventorySlots)
                {   
                    // Prend l'item à l'intérieur
                    InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
                    // S'il n'existe pas
                    if (itemInSlot == null) {
                        // Ajoute l'item dans le slot
                        SpawnNewItem(itemToAdd, slot);
                        // Prend le nouveau item dans le slot
                        itemInSlot = slot.GetComponentInChildren<InventoryItem>();
                        // Met comme compte de la pile, celui du ItemData
                        itemInSlot.count = itemData.count;
                        // Rafraichit le compte
                        itemInSlot.RefreshCount();
                        // Arrête la loop
                        break;
                    }
                }
                
            }
        }
        
    }


}



