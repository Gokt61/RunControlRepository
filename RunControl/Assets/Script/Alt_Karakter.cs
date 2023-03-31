using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.PlayerLoop;

public class Alt_Karakter : MonoBehaviour
{
    GameObject Target;
    NavMeshAgent _Navmesh;
    
    void Start()
    {
        _Navmesh = GetComponent<NavMeshAgent>();
        Target = GameObject.FindWithTag("GameManager").GetComponent<GameManager>().VarisNoktasi;
    }

    void Update()
    {
        _Navmesh.SetDestination(Target.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("igneliKutu"))
        {
            Vector3 yeniPoz = new Vector3(transform.position.x, .23f, transform.position.z);

            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().YokOlmaEfektriOlustur(yeniPoz);
            gameObject.SetActive(false);

        }
        
        if (other.CompareTag("Testere"))
        {
            Vector3 yeniPoz = new Vector3(transform.position.x, .23f, transform.position.z);

            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().YokOlmaEfektriOlustur(yeniPoz);
            gameObject.SetActive(false);
        }
        
        if (other.CompareTag("PervaneIgneler"))
        {
            Vector3 yeniPoz = new Vector3(transform.position.x, .23f, transform.position.z);

            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().YokOlmaEfektriOlustur(yeniPoz);
            gameObject.SetActive(false);
        }

        if (other.CompareTag("Balyoz"))
        {
            Vector3 yeniPoz = new Vector3(transform.position.x, .23f, transform.position.z);

            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().YokOlmaEfektriOlustur(yeniPoz,true);
            gameObject.SetActive(false);
        }
    }
}