using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Goktug
{
    public class Kutuphane : MonoBehaviour
    {
        public static void Carpma(int GelenSayi,List<GameObject> Karakterler,Transform Pozisyon)
        {
            int DonguSayisi = (GameManager.AnlikKarakterSayisi * GelenSayi) - GameManager.AnlikKarakterSayisi;
            //                                    10                 3      -            10           =  20
            //                                     5                 6      -             5           =  25
            //                                     4                 5      -             4           =  16
             int sayi = 0;
            foreach (var item in Karakterler)
            {
                if (sayi < DonguSayisi)
                {
                    if (!item.activeInHierarchy)
                    {
                        item.transform.position = Pozisyon.position;
                        item.SetActive(true);
                        sayi++;
                    }
                }
                else
                {
                    sayi = 0;
                    break;
                }
            }
            GameManager.AnlikKarakterSayisi *= GelenSayi;
        }
    }
}