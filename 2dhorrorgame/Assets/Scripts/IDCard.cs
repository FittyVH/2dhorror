using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IDCard : MonoBehaviour
{
    [SerializeField] GameObject idCardDrawer;
    [SerializeField] GameObject cupboard;
    [SerializeField] GameObject idCardButton;
    [SerializeField] GameObject drawerButton;

    public void DrawerClicked()
    {
        //idCardDrawer.GetComponent<SpriteRenderer>().sortingLayerName = "drawers";
        cupboard.SetActive(false);
        //idCardButton.SetActive(true);
        //drawerButton.SetActive(false);
    }
}
