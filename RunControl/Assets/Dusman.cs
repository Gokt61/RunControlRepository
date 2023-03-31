using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions.Must;

public class Dusman : MonoBehaviour
{
    public GameObject Saldiri_Hedefi;
    NavMeshAgent _NavMesh;
    bool saldiri_Basladimi;
    void Start()
    {
        _NavMesh = GetComponent<NavMeshAgent>();
    }

    public void AnimasyonTetikle()
    {
        GetComponent<Animator>().SetBool("Saldir", true);
        saldiri_Basladimi = true;
    }

    void LateUpdate()
    {
        if (saldiri_Basladimi)
        {
            _NavMesh.SetDestination(Saldiri_Hedefi.transform.position);
        }
    }
}