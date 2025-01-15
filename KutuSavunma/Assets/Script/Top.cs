using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Top : MonoBehaviour
{
    float darbegucu;
   

    GameObject gameKontrol;
    GameObject Oyuncu;

    void Start()
    {
        darbegucu = 20;
        gameKontrol = GameObject.FindWithTag("GameKontrol");
        Oyuncu = GameObject.FindWithTag("Oyuncu_1");


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      

        if (collision.gameObject.CompareTag("Ortadaki_kutular"))
        {
            collision.gameObject.GetComponent<ortadaki_kutu>().darbeal(darbegucu);

            gameKontrol.GetComponent<GameKontrol>().Ses_ve_Efekt_Olustur(1,collision.gameObject);
            Oyuncu.GetComponent<Oyuncu>().PowerOynasin();

            Destroy(gameObject);
         
          
        }
        if (collision.gameObject.CompareTag("Oyuncu_2_Kule")||collision.gameObject.CompareTag("Oyuncu_2"))
        {
            gameKontrol.GetComponent<GameKontrol>().Ses_ve_Efekt_Olustur(1, collision.gameObject);
            gameKontrol.GetComponent<GameKontrol>().Darbe_vur(2, darbegucu);
            Oyuncu.GetComponent<Oyuncu>().PowerOynasin();
            Destroy(gameObject);

        }
        if (collision.gameObject.CompareTag("Oyuncu_1_Kule")||collision.gameObject.CompareTag("Oyuncu_1"))
        {
            gameKontrol.GetComponent<GameKontrol>().Ses_ve_Efekt_Olustur(1, collision.gameObject);
            gameKontrol.GetComponent<GameKontrol>().Darbe_vur(1, darbegucu);
            Oyuncu.GetComponent<Oyuncu>().PowerOynasin();
            Destroy(gameObject);

        }
        if (collision.gameObject.CompareTag("Zemin"))
        {
            gameKontrol.GetComponent<GameKontrol>().Ses_ve_Efekt_Olustur(1, collision.gameObject);
            Oyuncu.GetComponent<Oyuncu>().PowerOynasin();
            Destroy(gameObject);

        }
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
