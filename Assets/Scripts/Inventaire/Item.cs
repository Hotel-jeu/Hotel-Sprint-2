using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Scriptable object/Item")]
public class Item : ScriptableObject
{
    // Affichage dans l'inspector

    [Header("Only gameplay")]
    // ID de l'item
    public int ID;
    // Type de l'item, outil ou consumable
    public ItemType type;
    // Prefab de l'item, afin de pouvoir l'instantiate
    public GameObject prefab;
    // Son quand l'item est utilisé
    public AudioClip sonUtilisation;
    // Son quand l'item est jeté
    public AudioClip sonDrop;

    [Header("Only UI")]
    // Est-ce possible d'empiler l'item
    public bool stackable = true;

    [Header("Both")]
    // Sprite de l'item dans l'inventaire
    public Sprite image;

}

// Les options de type d'item
public enum ItemType {
    Consumable,
    Outil
}