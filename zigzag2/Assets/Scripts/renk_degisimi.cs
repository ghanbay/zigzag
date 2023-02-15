using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class renk_degisimi : MonoBehaviour
{
    public Color[] renkler;
    Color ilk_renk, ikinci_renk;
    int bir_renk;
    public Material zemin_mat;
    void Start()
    {
        bir_renk = Random.Range(0, renkler.Length);
        ikinci_renk = renkler[ikinci_renk_sec()];
        zemin_mat.color = renkler[bir_renk];
        Camera.main.backgroundColor = renkler[bir_renk];       
        
    }
    void Update()
    {
        Color fark = zemin_mat.color - ikinci_renk;
        if ((Mathf.Abs(fark.r)+Mathf.Abs(fark.g)+Mathf.Abs(fark.b))<0.2f)
        {
            ikinci_renk = renkler[ikinci_renk_sec()];
        }
        zemin_mat.color = Color.Lerp(zemin_mat.color, ikinci_renk, 0.003f);
        Camera.main.backgroundColor = Color.Lerp(Camera.main.backgroundColor, ikinci_renk, 0.007f);
    }
    int ikinci_renk_sec()
    {
        int ikincil_renk;
        ikincil_renk = Random.Range(0, renkler.Length);
        while (ikincil_renk == bir_renk)
        {
            ikincil_renk = Random.Range(0, renkler.Length);
        }
        return ikincil_renk;
    }
}
