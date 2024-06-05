public class ItemData
{

    // Sauvegarde les données d'un item de l'inventaire

    // Son ID ainsi que son compte
    public int ID;
    public int count;

    // Fonction qui permet de stocker ces paramètres selon les données qui y sont envoyés
    public ItemData(int id, int count)
    {
        ID = id;
        this.count = count;
    }
}