using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    [SerializeField]
    private int crystals = 0;

    public TextMeshProUGUI txt;

    private void Start()
    {
        txt.text = crystals.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            Destroy(collision.gameObject);
            crystals++;
            txt.text = crystals.ToString();
        }
    }
}
