using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class player : MonoBehaviour
{
    Vector3 yon;
    [SerializeField]
    float hiz=1f;
    public zemin_olusturma zem_olustur;
    public static bool dustu_mu = true;
    public float hizlama_zorlugu;
    float skor=0f,art_mik=1f;
    [SerializeField]
    TextMeshProUGUI skor_text;
    int en_iyi_skor;
    public TextMeshProUGUI text_en_iyi_skor;
    public GameObject play_panel, restart_panel;
    // Start is called before the first frame update
    void Start()
    {
        if (restart_game.is_restart==true)
        {
            play_panel.SetActive(false);
            dustu_mu = false;
            skor_text.gameObject.SetActive(true);
            text_en_iyi_skor.gameObject.SetActive(true);
        }
        yon = Vector3.left;
        en_iyi_skor = PlayerPrefs.GetInt("en_iyi_skor");
        text_en_iyi_skor.text ="Best Score :"+ en_iyi_skor.ToString();
    }
    public void start_game()
    {
        dustu_mu = false;
        play_panel.SetActive(false);
        skor_text.gameObject.SetActive(true);
        text_en_iyi_skor.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {  if (dustu_mu)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
        if (yon.z==0)
        {
            yon = Vector3.back;
        }
        else
        {
            yon = Vector3.left;
        }
        }
        if (transform.position.y<0.1f)
        {
            dustu_mu = true;
            restart_panel.SetActive(true);
            Destroy(gameObject, 2f);
            if (en_iyi_skor<skor)
            {
                en_iyi_skor = (int)skor;
                PlayerPrefs.SetInt("en_iyi_skor", en_iyi_skor);
                PlayerPrefs.Save();
                
            }
        }
        
    }
    private void FixedUpdate()
    {
        if (dustu_mu)
        {
            return;
        }
        Vector3 hareket = yon * hiz * Time.deltaTime;
        transform.position += hareket;
        hiz += hizlama_zorlugu * Time.deltaTime;
        skor += art_mik * hiz * Time.deltaTime;
        skor_text.text = "Score : "+((int)skor).ToString();
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("zemin"))
        {
           StartCoroutine( yok_et(collision.gameObject));
            zem_olustur.zemin_olustur();        }
        
    }
    IEnumerator yok_et(GameObject obje)
    {
        yield return new WaitForSeconds(0.3f);
        obje.AddComponent<Rigidbody>();
        yield return new WaitForSeconds(1f);
        Destroy(obje);
    }
}
