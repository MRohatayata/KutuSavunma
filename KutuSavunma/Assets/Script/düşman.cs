using System.Collections;
using UnityEngine;

public class Dusman : MonoBehaviour
{
    public GameObject top; // Fırlatılacak top prefabı
    public GameObject TopCikisNoktasi; // Top çıkış noktası
    public ParticleSystem TopAtisEfekt; // Top atış efekti
    public AudioSource TopAtmaSesi; // Top atış sesi
    public float minAtisGucu = 0f; // Minimum atış gücü
    public float maxAtisGucu = 12f; // Maksimum atış gücü
    public float minAtisSuresi = 1f; // Minimum atış süresi
    public float maxAtisSuresi = 2f; // Maksimum atış süresi

    void Start()
    {
        // Sürekli top atışı başlatılıyor
        StartCoroutine(DusmanTopAtisi());
    }

    IEnumerator DusmanTopAtisi()
    {
        while (true)
        {
            // Rastgele bir atış gücü seçiliyor
            float atisGucu = Random.Range(minAtisGucu, maxAtisGucu);

            // Rastgele bir bekleme süresi seçiliyor
            float beklemeSuresi = Random.Range(minAtisSuresi, maxAtisSuresi);

            // Top atışı
            TopAtisYap(atisGucu);

            // Belirlenen süre kadar bekleniyor
            yield return new WaitForSeconds(beklemeSuresi);
        }
    }

    void TopAtisYap(float atisGucu)
    {
        // Efekt ve ses oynatılıyor
        Instantiate(TopAtisEfekt, TopCikisNoktasi.transform.position, TopCikisNoktasi.transform.rotation);
        TopAtmaSesi.Play();

        // Yeni bir top oluşturuluyor
        GameObject topObjem = Instantiate(top, TopCikisNoktasi.transform.position, TopCikisNoktasi.transform.rotation);

        // Rigidbody2D alınıyor ve kuvvet uygulanıyor
        Rigidbody2D rg = topObjem.GetComponent<Rigidbody2D>();
        rg.AddForce(new Vector2(2f, 0f) *- atisGucu, ForceMode2D.Impulse);
    }
}
