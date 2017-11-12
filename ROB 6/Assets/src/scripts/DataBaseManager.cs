using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;

/**
 * DataBaseManager.
 *
 * @author Julien Delane
 * @version 17.10.30
 * @since 17.10.30
 */
public class DataBaseManager : MonoBehaviour
{
	/**
     * Variable to reach this object from every where.
     *
     * @since 17.10.30
     */
    public static DataBaseManager instance;

	/**
     * Database connection.
     *
     * @since 17.10.30
     */
	public IDbConnection dbConnection;

    /**
     * Init the object instance.
     *
     * @since 17.10.30
     */

	private void Awake()
	{
		if (instance == null)
		{
            instance = this;

        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        if (dbConnection == null)
		{
			string dbPath = "URI=file:" + Application.dataPath + "/StreamingAssets/Rob6DataBase.sqlite";
			dbConnection = (IDbConnection) new SqliteConnection(dbPath);
        }
        DontDestroyOnLoad(gameObject);
	}

}
