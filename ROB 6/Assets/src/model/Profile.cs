using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Mono.Data.Sqlite;
using System.Data;

/**
 * Profile.
 *
 * @author Julien Delane
 * @version 17.11.01
 * @since 17.11.04
 */
public class Profile
{
   /**
	* Unique id of the profile.
	*
	* @since 17.10.29
	*/	
	public long Id { get; }

   /**
	* Name of the profile.
	*
	* @since 17.10.29
	*/
	public string Name { set; get; }

   /**
	* Level id of the profile.
	*
	* @since 17.10.29
	*/
	public int LevelId { set; get; }

   /**
	* Creation date of the profile.
	*
	* @since 17.10.29
	*/
	public DateTime CreationDate { set; get; }

   /**
	* last update date of the profile.
	*
	* @since 17.10.29
	*/
	public DateTime LastUpdateDate { set; get; }

   /**
	* Time spend in this by the player profile.
	*
	* @since 17.10.29
	*/
	public long TimeSpend { set; get; }

	/**
	 * Basic constructor.
	 *
	 * @since 17.11.01
 	 */
	public Profile()
	{

	}

	/**
	 * Constructor.
	 *
	 * @since 17.11.01
 	 */
	public Profile(long id, string name, int levelId, DateTime creationDate, DateTime lastUpdateDate, long timeSpend)
	{
		this.Id = id;
		this.Name = name;
		this.LevelId = levelId;
		this.CreationDate = creationDate;
		this.LastUpdateDate = lastUpdateDate;
		this.TimeSpend = timeSpend;
	}

   /**
	* Add a profile in db.
	*
	* @param name of the profile
	* @since 17.10.30
	*/
	public static void insertProfile(string name)
	{
		DataBaseManager.instance.dbConnection.Open();
		using (IDbCommand dbCommand = DataBaseManager.instance.dbConnection.CreateCommand())
		{
			string sqlQuery =  "INSERT INTO Profile (name, level_id, time_spend, creation_date, last_update_date) VALUES (@name, @level_id, @time_spend, @current_date, @current_date)";
			dbCommand.Parameters.Add(new SqliteParameter("@name", name));
			dbCommand.Parameters.Add(new SqliteParameter("@level_id", 1));
			dbCommand.Parameters.Add(new SqliteParameter("@time_spend", 1));
			dbCommand.Parameters.Add(new SqliteParameter("@current_date", DateTime.Now));
			dbCommand.CommandText = sqlQuery;
			dbCommand.ExecuteNonQuery();
		}
		DataBaseManager.instance.dbConnection.Close();
	}

   /**
	* Update a profile in db.
	*
	* @since 17.11.02
	*/
	public void updateProfile()
	{
		DataBaseManager.instance.dbConnection.Open();
		using (IDbCommand dbCommand = DataBaseManager.instance.dbConnection.CreateCommand())
		{
			string sqlQuery =  "UPDATE Profile SET last_update_date = @current_date, time_spend = @time_spend, level_id = @level_id WHERE id = @id";
			this.TimeSpend = this.TimeSpend + (DateTime.Now.Ticks - LastUpdateDate.Ticks);
			this.LastUpdateDate = DateTime.Now;
			dbCommand.Parameters.Add(new SqliteParameter("@id", this.Id));
			dbCommand.Parameters.Add(new SqliteParameter("@current_date", this.LastUpdateDate));
			dbCommand.Parameters.Add(new SqliteParameter("@time_spend", this.TimeSpend));
			dbCommand.Parameters.Add(new SqliteParameter("@level_id", this.LevelId));
			dbCommand.CommandText = sqlQuery;
			dbCommand.ExecuteNonQuery();
		}
		DataBaseManager.instance.dbConnection.Close();
	}

   /**
	* Delete a profile in db.
	*
	* @since 17.11.04
	*/
	public static void deleteProfile(long id)
	{
		DataBaseManager.instance.dbConnection.Open();
		using (IDbCommand dbCommand = DataBaseManager.instance.dbConnection.CreateCommand())
		{
			string sqlQuery =  "Delete FROM Profile WHERE id = @id";
			dbCommand.Parameters.Add(new SqliteParameter("@id", id));
			dbCommand.CommandText = sqlQuery;
			dbCommand.ExecuteNonQuery();
		}
		DataBaseManager.instance.dbConnection.Close();
	}

   /**
	* Get a profile in db.
	*
	* @param name of the profile
	* @since 17.10.31
	*/
	public static Profile getProfile(IDataReader reader)
	{
		Profile profile = null;
		while (reader.Read())
		{
			profile = new Profile(reader.GetInt64(0), reader.GetString(1), reader.GetInt32(2), reader.GetDateTime(3), reader.GetDateTime(4), reader.GetInt64(5));
		}
		reader.Close();
		return profile;
	}

   /**
	* Get a profile in db.
	*
	* @param name of the profile
	* @since 17.10.31
	*/
	public static List<Profile> getProfiles(IDataReader reader)
	{
		List<Profile> profiles = new List<Profile>();
		while (reader.Read())
		{
			Profile profile = new Profile(reader.GetInt64(0), reader.GetString(1), reader.GetInt32(2), reader.GetDateTime(3), reader.GetDateTime(4), reader.GetInt64(5));
			profiles.Add(profile);
		}
		reader.Close();
		return profiles;
	}

   /**
	* Get the last updated profile in db.
	*
	* @since 17.11.02
	*/
	public static void getLastProfileEdited()
	{
		DataBaseManager.instance.dbConnection.Open();
        using (IDbCommand dbCommand = DataBaseManager.instance.dbConnection.CreateCommand())
		{
			string sqlQuery = "SELECT * FROM Profile ORDER BY last_update_date ASC LIMIT 1";
			dbCommand.CommandText = sqlQuery;
			using (IDataReader reader = dbCommand.ExecuteReader())
			{
				ProfileScript.instance.playerProfile = Profile.getProfile(reader);
				ProfileScript.instance.playerProfile.LastUpdateDate = DateTime.Now;
			}
		}
		DataBaseManager.instance.dbConnection.Close();
	}
	
   /**
	* Get all profile in db.
	*
	* @since 17.11.02
	*/
	public static List<Profile> getAllProfile()
	{
		List<Profile> profiles;
		DataBaseManager.instance.dbConnection.Open();
        using (IDbCommand dbCommand = DataBaseManager.instance.dbConnection.CreateCommand())
		{
			string sqlQuery = "SELECT * FROM Profile ORDER BY last_update_date DESC";
			dbCommand.CommandText = sqlQuery;
			using (IDataReader reader = dbCommand.ExecuteReader())
			{
				profiles = Profile.getProfiles(reader);
			}
		}
		DataBaseManager.instance.dbConnection.Close();
		return profiles;
	}

}
