using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Karakter : MonoBehaviour
{
    public GameManager _GameManager;
    public GameObject _Kamera;
    public bool SonaGeldikmi;
    public GameObject Gidecegiyer;

    private void FixedUpdate()
    {
        if (!SonaGeldikmi)
        {
            transform.Translate(Vector3.forward * 0.5f * Time.deltaTime);
        }
    }

    void Update()
    {
        if (SonaGeldikmi)
        {
            transform.position = Vector3.Lerp(transform.position, Gidecegiyer.transform.position, 0.05f);
        }
        else
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                if (Input.GetAxis("Mouse X") < 0)
                {
                    transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x - .1f, transform.position.y, transform.position.z), 0.3f);
                }
                if (Input.GetAxis("Mouse X") > 0)
                {
                    transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + .1f, transform.position.y, transform.position.z), 0.3f);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Carpma") || other.CompareTag("Toplama") || other.CompareTag("Bolme") || other.CompareTag("Cikartma"))
        {
            int sayi = int.Parse(other.name);
            _GameManager.AdamYonetimi(other.tag,sayi,other.transform);
        }
        else if (other.CompareTag("Sontetikleyici"))
        {
            _Kamera.GetComponent<Kamera>().SonaGeldikmi = true;
            _GameManager.DusmanlariTetikle();
            SonaGeldikmi = true;
        }
    }
}
