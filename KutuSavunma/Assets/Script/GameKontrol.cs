using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameKontrol : MonoBehaviour
{
    
    [Header("TOP AYARLARI VE İŞLEMLERİ")]
    public GameObject TopYokOlmaEfekt;
    public AudioSource YokOlmaSesi;

    [Header("ORTADAKİ KUTULARIN AYARLARI VE İŞLEMLERİ")]
    public GameObject KutuYokOlmaEfekt;
    public AudioSource KutuYokOlmaSesi;
    [Header("OYUNCU SAĞLIK AYARLARI")]
    public Image Oyuncu_1_saglik_Bar;
    float Oyuncu_1_saglik=100;
    public Image Oyuncu_2_saglik_Bar;
    float Oyuncu_2_saglik=100;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Ses_ve_Efekt_Olustur(int kriter,GameObject objetransformu)
    {

        switch (kriter)
        {

            case 1:
                Instantiate(TopYokOlmaEfekt, objetransformu.gameObject.transform.position, objetransformu.gameObject.transform.rotation);
                YokOlmaSesi.Play();
                break;
            case 2:
                Instantiate(KutuYokOlmaEfekt, objetransformu.gameObject.transform.position, objetransformu.gameObject.transform.rotation);
                KutuYokOlmaSesi.Play();
                break;

        }
        
    }



    public void Darbe_vur(int kriter,float darbegucu)
    {

        switch (kriter)
        {

            case 1:
                Oyuncu_1_saglik -= darbegucu;

                Oyuncu_1_saglik_Bar.fillAmount = Oyuncu_1_saglik / 100;

                if (Oyuncu_1_saglik <= 0)
                {

                    Debug.Log("Oyuncu 1 yenildi");

                }
               
                break;
            case 2:
                Oyuncu_2_saglik -= darbegucu;

                Oyuncu_2_saglik_Bar.fillAmount = Oyuncu_2_saglik / 100;

                if (Oyuncu_2_saglik <= 0)
                {

                    Debug.Log("Oyuncu 2 yenildi");

                }
                break;

        }

    }
}
