using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * LangCell.
 *
 * @author Julien Delane
 * @version 17.11.10
 * @since 17.11.10
 */
public class LangCell : MonoBehaviour
{
    /**
     * Name of the lang.
     *
  	 * @unityParam
     * @since 17.11.10
     */
     public GameObject langName;

    /**
     * Fill lang name.
     *
     * @since 17.11.10
     */
	public void setLang(string name)
    {
       this.langName.GetComponent<Text>().text = name;
	}

}
