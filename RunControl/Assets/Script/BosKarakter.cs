using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class BosKarakter : MonoBehaviour
{
    public SkinnedMeshRenderer _Renderer;
    public Material AtanacakMaterial;
    public NavMeshAgent _Navmesh;
    public Animator _Animator;
    public GameObject Target;
    public GameManager _GameManager;
    bool Temasvar;


    void LateUpdate()
    {
        if (Temasvar)
        {
            _Navmesh.SetDestination(Target.transform.position);
        }
    }

    Vector3 PozisyonVer()
    {
        return new Vector3(transform.position.x, .23f, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AltKarakterler") || other.CompareTag("Player"))
        {
            if (gameObject.CompareTag("BosKarakter"))
            {
                MaterialDegistirveAnimasyonTetikle();
                Temasvar = true;
            }
        }

        else if (other.CompareTag("igneliKutu"))
        {
            _GameManager.YokOlmaEfektiOlustur(PozisyonVer());
            gameObject.SetActive(false);

        }
        else if (other.CompareTag("Testere"))
        {
            _GameManager.YokOlmaEfektiOlustur(PozisyonVer());

            gameObject.SetActive(false);
        }
        else if (other.CompareTag("PervaneIgneler"))
        {
            _GameManager.YokOlmaEfektiOlustur(PozisyonVer());

            gameObject.SetActive(false);
        }
        else if (other.CompareTag("Balyoz"))
        {
            _GameManager.YokOlmaEfektiOlustur(PozisyonVer(), true);

            gameObject.SetActive(false);
        }

        else if (other.CompareTag("Dusman"))
        {
            _GameManager.YokOlmaEfektiOlustur(PozisyonVer(), false, false);

            gameObject.SetActive(false);
        }
    }

    void MaterialDegistirveAnimasyonTetikle()
    {
        Material[] mats = _Renderer.materials;
        mats[0] = AtanacakMaterial;
        _Renderer.materials = mats;
        _Animator.SetBool("Saldir", true);
        gameObject.tag = "AltKarakterler";
        GameManager.AnlikKarakterSayisi++;
    }
}
