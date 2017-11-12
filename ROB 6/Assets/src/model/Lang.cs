using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using Mono.Data.Sqlite;
using System.Data;

/**
 * Lang.
 *
 * @author Julien Delane
 * @version 17.11.12
 * @since 17.11.10
 */
public class Lang
{
    /**
 	 * Name.
 	 *
 	 * @since 17.11.10
	 */
	public string Name { get; set; }

	/**
 	 * Code.
 	 *
 	 * @since 17.11.10
	 */
	public string Code { get; set; }

	/**
 	 * Basic constructor.
 	 *
 	 * @since 17.11.11
	 */
	public Lang(string name, string code)
	{
		this.Name = name;
		this.Code = code;
	}

	/**
	 * getLangFile.
	 * 
	 * @return lang list that contain all the CODE key of lang file found and lang name
	 * @since 17.11.10
 	 */
	public static List<Lang> getLangFile()
	{
		List<Lang> langs = new List<Lang>();
		string [] fileEntries = Directory.GetFiles(Application.dataPath + "/StreamingAssets/lang/");
		foreach(string fileName in fileEntries)
		{
            if (fileName.Contains(".lang"))
			{
				string code = "";
				string name = "";
				string[] data = File.ReadAllText(fileName).Split('\n');
				string[] tmp;
				foreach (string str in data)
				{
                	if (str.Contains("LANGUAGE.CODE="))
                	{
				    	tmp = str.Split('=');
				    	code = tmp[1];
                	}
					if (str.Contains("LANGUAGE.NAME="))
                	{
				    	tmp = str.Split('=');
				    	name = tmp[1];
                	}
				}
				if (name.CompareTo("") != 0 && code.CompareTo("") != 0)
				{
					langs.Add(new Lang(name, code));
				}
			}
		}
		return langs;
	}

	/**
	 * Select language.
	 * 
	 * @since 17.11.11
 	 */
	public void selectLanguage()
	{
		DataBaseManager.instance.dbConnection.Open();
		using (IDbCommand dbCommand = DataBaseManager.instance.dbConnection.CreateCommand())
		{
			string sqlQuery =  "UPDATE Settings SET lang = @lang WHERE id = 0";
			dbCommand.Parameters.Add(new SqliteParameter("@lang", this.Code));
			dbCommand.CommandText = sqlQuery;
			dbCommand.ExecuteNonQuery();
		}
		DataBaseManager.instance.dbConnection.Close();
	}

	/**
	 * Get language.
	 * 
	 * @since 17.11.12
 	 */
	public static String getLanguage()
	{
		string lang = "fr_fr";

		DataBaseManager.instance.dbConnection.Open();
        using (IDbCommand dbCommand = DataBaseManager.instance.dbConnection.CreateCommand())
		{
			string sqlQuery = "SELECT * FROM Settings ORDER BY id ASC LIMIT 1";
			dbCommand.CommandText = sqlQuery;
			using (IDataReader reader = dbCommand.ExecuteReader())
			{
				while (reader.Read())
				{
					lang = reader.GetString(1);
				}
				reader.Close();
			}
		}
		DataBaseManager.instance.dbConnection.Close();
		return lang;
	}

}
