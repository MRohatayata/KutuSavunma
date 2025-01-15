using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Oyuncu : MonoBehaviour
{
    public GameObject top;
    public GameObject TopCikisnoktasi;
    public ParticleSystem TopAtisEfekt;
    public AudioSource TopAtmaSesi;
    public Image PowerBar;

    private float powerSayi;
    private bool sonageldimi = false;
    private bool powerBarAktif = true;

    private Coroutine powerDongu;

    void Start()
    {
        powerDongu = StartCoroutine(PowerBarCalistir());
    }

    IEnumerator PowerBarCalistir()
    {
        sonageldimi = false;
        while (true)
        {
            if (powerBarAktif)
            {
                if (PowerBar.fillAmount < 1 && !sonageldimi)
                {
                    powerSayi = 0.01f; // Daha makul bir artış değeri
                    PowerBar.fillAmount += powerSayi;
                    yield return new WaitForSeconds(0.01f); // Performans açısından uygun
                }
                else
                {
                    sonageldimi = true;
                    powerSayi = 0.01f;
                    PowerBar.fillAmount -= powerSayi;
                    yield return new WaitForSeconds(0.01f);

                    if (PowerBar.fillAmount <= 0) // Float hassasiyet hatası engellenir
                    {
                        sonageldimi = false;
                    }
                }
            }
            else
            {
                yield return null; // Duraklatma işlemi
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Efekt ve ses oluştur
            Instantiate(TopAtisEfekt, TopCikisnoktasi.transform.position, TopCikisnoktasi.transform.rotation);
            TopAtmaSesi.Play();

            // Top objesi oluştur ve hareket ettir
            GameObject topobjem = Instantiate(top, TopCikisnoktasi.transform.position, TopCikisnoktasi.transform.rotation);
            Rigidbody2D rg = topobjem.GetComponent<Rigidbody2D>();
            rg.AddForce(new Vector2(2f, 0f) * 12f * PowerBar.fillAmount, ForceMode2D.Impulse);

            powerBarAktif = false; // PowerBar'ı durdur
        }
    }

    public void PowerOynasin()
    {
        powerBarAktif = true; // PowerBar'ı yeniden başlat
    }
}
