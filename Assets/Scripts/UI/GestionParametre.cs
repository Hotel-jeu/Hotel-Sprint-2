using UnityEngine;
using UnityEngine.UI;

public class GestionParametre : MonoBehaviour
{
    public Slider sliderSensi;
    public Slider sliderSon;

    void Start()
    {
        // Prend les value des parametres inclut dans unity, et les met dans le slider
        sliderSensi.value = PlayerPrefs.GetFloat("MouseSensitivity", 0.5f);
        sliderSon.value = PlayerPrefs.GetFloat("SoundVolume", 0.5f);
        // Quand le slider change de valeur il appelle ces fonctions
        sliderSensi.onValueChanged.AddListener(delegate { ChangerSensi(); });
        sliderSon.onValueChanged.AddListener(delegate { ChangerVolume(); });
    }

    public void ChangerSensi()
    {
        // Prend la value du slider et la met en sensibilite dans les vrais parametre
        float sensibilite = sliderSensi.value;
        PlayerPrefs.SetFloat("MouseSensitivity", sensibilite);
    }

    public void ChangerVolume()
    {
        // Prend la value du slider et la met en volume dans les vrais parametre
        float volume = sliderSon.value;
        PlayerPrefs.SetFloat("SoundVolume", volume);
        AudioListener.volume = volume;
    }
}
