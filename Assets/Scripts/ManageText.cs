using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageText : MonoBehaviour {

    public GameObject usaText;
    public GameObject usaText2;
    public Text usaText3;
    public GameObject urssText;
    public GameObject urssText2;
    public Text urssText3;
    public GameObject usaAnthem;
    public GameObject urssAnthem;

	void Start () {

		if(PlayerPrefs.GetInt("scoreP2")>= 10)
        {
            usaText.SetActive(true);
            usaText2.SetActive(true);
            usaText3.gameObject.SetActive(true);
            usaAnthem.gameObject.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("scoreP1") >= 10)
        {
            urssText.SetActive(true);
            urssText2.SetActive(true);
            urssText3.gameObject.SetActive(true);
            urssAnthem.gameObject.SetActive(true);
        }
	}

}
