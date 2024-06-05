using UnityEngine;
using UnityEngine.UI;

public class GestionParametre : MonoBehaviour
{
    public Slider sliderSensi;
    public Slider sliderSon;

    void Start()
    {
        // Initialise les sliders avec les valeurs sauvegardées ou avec des valeurs par défaut si elles n'existent pas
        if (!PlayerPrefs.HasKey("SensibiliteSouris"))
        {
            PlayerPrefs.SetFloat("SensibiliteSouris", 1f);  // Définir la valeur par défaut
        }
        if (!PlayerPrefs.HasKey("VolumeSon"))
        {
            PlayerPrefs.SetFloat("VolumeSon", 1f);  // Définir la valeur par défaut
        }

        sliderSensi.value = PlayerPrefs.GetFloat("SensibiliteSouris");
        sliderSon.value = PlayerPrefs.GetFloat("VolumeSon");
        ChangerSensibilite();
        ChangerVolume();

        // Ajoute les écouteurs pour les changements de valeur
        sliderSensi.onValueChanged.AddListener(delegate { ChangerSensibilite(); });
        sliderSon.onValueChanged.AddListener(delegate { ChangerVolume(); });
    }

    public void ChangerSensibilite()
    {
        // Met à jour la sensibilité de la souris dans les préférences utilisateur
        PlayerPrefs.SetFloat("SensibiliteSouris", sliderSensi.value);
        PlayerPrefs.Save();  // Assure la sauvegarde immédiate des préférences
    }

    public void ChangerVolume()
    {
        // Met à jour le volume du son dans les préférences utilisateur et applique le volume
        PlayerPrefs.SetFloat("VolumeSon", sliderSon.value);
        AudioListener.volume = sliderSon.value;
        PlayerPrefs.Save();  // Assure la sauvegarde immédiate des préférences
    }
}