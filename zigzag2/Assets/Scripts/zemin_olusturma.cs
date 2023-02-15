using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zemin_olusturma : MonoBehaviour
{
    public GameObject son_zemin;    
    void Start()
    {
        for (int i = 0; i <= 40; i++)
        {
            zemin_olustur();
        }
    }
    public void zemin_olustur()
    {
        Vector3 yon;
        int random_sayi = Random.Range(0, 2);
        if (random_sayi==0)
        {
            yon = Vector3.left;
        }
        else
        {
            yon = Vector3.back;
        }
        son_zemin = Instantiate(son_zemin, son_zemin.transform.position + yon, son_zemin.transform.rotation);
    }
}
