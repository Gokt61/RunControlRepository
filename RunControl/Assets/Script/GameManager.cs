using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Goktug;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    public static int AnlikKarakterSayisi = 1;


    public List<GameObject> Karakterler;
    public List<GameObject> OlusmaEfektleri;
    public List<GameObject> YokOlmaEfekleri;
    public List<GameObject> AdamLekesiEfektleri;

    [Header("LEVEL VERÝLERÝ")]
    public List<GameObject> Dusmanlar;
    public int KacDusmanOlsun;
    public GameObject _AnaKarakter;
    public bool OyunBittimi;

    void Start()
    {
        DusmanlariOlustur();
    }

    private  void DusmanlariOlustur()
    {
        for (int i = 0; i < KacDusmanOlsun; i++)
        {
            Dusmanlar[i].SetActive(true);
        }
    }

    public void DusmanlariTetikle()
    {
        foreach (var item in Dusmanlar)
        {
            if (item.activeInHierarchy)
            {
                item.GetComponent<Dusman>().AnimasyonTetikle();
            }
        }
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    foreach (var item in Karakterler)
        //    {
        //        if (!item.activeInHierarchy)
        //        {
        //            item.transform.position = DogmaNoktasi.transform.position;
        //            item.SetActive(true);
        //            AnlikKarakterSayisi++;
        //            break;
        //        }
        //    }
        //}
    }

    void SavasDurumu()
    {
        if (AnlikKarakterSayisi == 1 || KacDusmanOlsun == 0)
        {
            OyunBittimi = true;

            foreach (var item in Dusmanlar)
            {
                if (item.activeInHierarchy)
                {
                    item.GetComponent<Animator>().SetBool("Saldir", false);
                    item.GetComponent<NavMeshAgent>().stoppingDistance = 0.3f;
                }
            }

            foreach (var item in Karakterler)
            {
                if (item.activeInHierarchy)
                {
                    item.GetComponent<Animator>().SetBool("Saldir", false);
                    item.GetComponent<NavMeshAgent>().stoppingDistance = 0.3f;
                }
            }

            _AnaKarakter.GetComponent<Animator>().SetBool("Saldir", false);

            if (AnlikKarakterSayisi < KacDusmanOlsun || AnlikKarakterSayisi == KacDusmanOlsun)
            {
                Debug.Log("Kaybettin");
            }
            else
            {
                Debug.Log("Kazandýn");
            }
        }
    }

    public void AdamYonetimi(string islemTuru,int GelenSayi, Transform Pozisyon)
    {
        switch (islemTuru)
        {
            case "Carpma":
                Matematiksel_islemler.Carpma(GelenSayi, Karakterler, Pozisyon,OlusmaEfektleri);
                break;

            case "Toplama":
                Matematiksel_islemler.Toplama(GelenSayi, Karakterler, Pozisyon, OlusmaEfektleri);

                break;

            case "Cikartma":
                Matematiksel_islemler.Cikartma(GelenSayi, Karakterler,YokOlmaEfekleri);
                break;

            case "Bolme":
                Matematiksel_islemler.Bolme(GelenSayi, Karakterler,YokOlmaEfekleri);
                break;
        }
    }

    public void YokOlmaEfektiOlustur(Vector3 Pozisyon,bool Balyoz = false,bool Durum=false)
    {
        foreach (var item in YokOlmaEfekleri)
        {
            if (!item.activeInHierarchy)
            {
                item.SetActive(true);
                item.transform.position = Pozisyon;
                item.GetComponent<ParticleSystem>().Play();
                if (!Durum)
                {
                    AnlikKarakterSayisi--;
                }
                else
                {
                    KacDusmanOlsun--;
                }
                break;
            }
        }

        if (Balyoz)
        {
            Vector3 yeniPoz = new Vector3(Pozisyon.x, .005f, Pozisyon.z);
            foreach (var item in AdamLekesiEfektleri)
            {
                if (!item.activeInHierarchy)
                {
                    item.SetActive(true);
                    item.transform.position = yeniPoz;
                    break;
                }
            }
        }
        if (!OyunBittimi)
        {
            SavasDurumu();
        }
    }
}