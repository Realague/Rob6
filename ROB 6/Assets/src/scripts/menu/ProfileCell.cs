using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

/**
 * ProfileCell.
 *
 * @author Julien Delane
 * @version 17.11.05
 * @since 17.11.05
 */
public class ProfileCell : MonoBehaviour
{
    /**
     * Name of the profile.
     *
  	 * @unityParam
     * @since 17.11.05
     */
     public GameObject profileName;

    /**
     * Update date of the profile.
     *
  	 * @unityParam
     * @since 17.11.05
     */
     public GameObject updateDate;

    /**
     * Creation date of the profile.
     *
  	 * @unityParam
     * @since 17.11.05
     */
     public GameObject creationDate;

    /**
     * Creation date of the profile.
     *
  	 * @unityParam
     * @since 17.11.05
     */
     public GameObject timeSpend;

    /**
     * Fill profile field.
     *
     * @since 17.11.05
     */
	public void setProfile(string name, DateTime lasUpdateDate, DateTime creationDate, long timeSpend)
    {
        this.profileName.GetComponent<Text>().text = name;
        this.updateDate.GetComponent<Text>().text = lasUpdateDate.ToString();
        this.creationDate.GetComponent<Text>().text = creationDate.ToString();
        this.timeSpend.GetComponent<Text>().text = timeSpend / 3600 + "h " + timeSpend % 3600 / 60 + "m";
	}

}
