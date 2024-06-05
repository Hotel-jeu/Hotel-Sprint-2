using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    // Objet dans l'UI de l'inventaire
    
    // Ce qui est affiché dans l'inspecteur
    [Header("UI")]
    // Sprite de l'item
    public Image image;
    // Texte qui montre combien de copie d'item, ce UI possède
    public Text countText;
    
    // Le script item lié à cet objet
    [HideInInspector] public Item item;
    // Le nombre d'objets, 1 par defaut
    public int count = 1;
    // Variable qui stocke le parent, avant et apres dépendamment du contexte
    [HideInInspector] public Transform parentAfterDrag;

    private void Start() {
        // Initialise l'objet selon l'item mis (Du gestionnaire d'inventaire / Inventory Manager)
        InitialiseItem(item);
    }
    // Initialise l'objet
    public void InitialiseItem(Item newItem) {
        // Donne a la valeur item, l'item qui a été donné depuis le gestionnaire
        item = newItem;
        // Met le sprite de l'item du gestionnaire à notre image
        image.sprite = newItem.image;
        // Appelle la fonction qui actualise le nombre d'objet dans chaque objet
        RefreshCount();
    }

    // Fonction qui actualise le nombre d'objet dans chaque objet
    public void RefreshCount() {
        // Donne au texte le nombre d'objet (Valeur de la variable count)
        countText.text = count.ToString();
        // Met true si le nombre est + que 1, sinon c'est false
        bool textActive = count > 1;
        // Si l'item est unique, donc aucune pile encore, le texte ne s'affiche juste pas
        countText.gameObject.SetActive(textActive);
    }
    // Glisser et déposer (Drag and drop)

    // Debut glissement
    public void OnBeginDrag(PointerEventData eventData) {
        // Met le parent actuel dans la variable parentAfterDrag afin de pouvoir l'utiliser plus tard
        parentAfterDrag = transform.parent;
        // Change le parent, afin de le mettre à la base de notre heirarchy, cela permet de voir l'objet en premier
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        // Désactive le raycastTarget de l'image, afin d'arrêter de prendre des pointer event
        image.raycastTarget = false;
    }

    // Pendant le glissement (Drag)
    public void OnDrag(PointerEventData eventData) {
        // Change la position de l'objet selon la position de la souris
        transform.position = Input.mousePosition;
    }
    
    // A la fin du glissement
    public void OnEndDrag(PointerEventData eventData) {
        // Si l'objet n'est glissé nulle part, ou là ou il est glissé, ne contient pas de Slot, donc place vide, ni rempli, donc InventoryItem
        if (!eventData.pointerEnter || !eventData.pointerEnter.GetComponent<InventorySlot>() && !eventData.pointerEnter.GetComponent<InventoryItem>()) {
            // Appelle la fonction qui jette l'objet dans le monde si il est glissé hors de l'inventaire
            DropItemInWorld();
        }
        // Si l'objet est glissé quelque part, met comme parent la variable parentAfterDrag
        // (Elle est changé dans le script du Inventory Slot, donc c'est le nouveau parent et non l'ancien)
        transform.SetParent(parentAfterDrag);
        // Reactive le raycastTarget 
        image.raycastTarget = true;
    }

    // Jette l'objet dans le monde
    private void DropItemInWorld() {
        // Prend la position de la camera et y ajoute la mm position en Z
        Vector3 position = Camera.main.transform.position + Camera.main.transform.forward;
        // Prend une rotation nulle
        Quaternion rotation = Quaternion.identity;

        // Cree une copie de l'item, en utilisant le prefab de l'item, la position prise avant ainsi que la rotation
        GameObject itemGO = Instantiate(item.prefab, position, rotation);
        // Joue le son de drop de l'item, en utilisant l'audio source du prefab
        itemGO.GetComponent<AudioSource>().PlayOneShot(item.sonDrop);
        // Donne à l'objet jeté, le même nom que l'item
        itemGO.name = item.name;

        // Prend le rigid body de l'item jeté
        Rigidbody rb = itemGO.GetComponent<Rigidbody>();
        // Si le rigidbody existe
        if (rb != null) {
            // Jette l'objet en avant en mettant une force
            rb.AddForce(Camera.main.transform.forward * 2, ForceMode.Impulse);
        }

        // Quand le joueur jette l'objet, le count est baissé de 1
        count--;
        // Si c'est à 0 ou moins, l'objet est supprimée
        if (count <= 0) {
            Destroy(gameObject);
        } 
        // Sinon met à jour le nombre d'objet affiché
        else {
            RefreshCount();
        }
    }


}
