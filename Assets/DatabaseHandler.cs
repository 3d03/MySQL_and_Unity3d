using System.Collections;
using System.Collections.Generic;
using System;
using System.Data;
using System.Text;

using UnityEngine;
using UnityEngine.UI;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

public class DatabaseHandler : MonoBehaviour {




	public InputField idIF;
	public InputField NameIF;
	public InputField LastNameIF;
	public InputField mailIF;
	public Button AddEntryBtn;

	//string Contring = "Server=127.0.0.1;Database=MyDB;Uid=mysql;Pwd=mysql;";   //CharSet=utf8;";//"host=127.0.0.1;port=3306;user=mysql;password=mysql;database=information_schema;";

	string Contring = "Server=127.0.0.1;Database=myfirstdb;Uid=root;Pwd=MYYYPASSSSWWORRD;";

	private MySqlCommand cmd = null;
    private MySqlDataReader rdr = null;
    private MD5 _md5hash;



	public void	AddEntry()
	{
	


		DontDestroyOnLoad(this.gameObject);

		

		MySqlConnection con = new MySqlConnection(Contring);
		Debug.Log("INSERT INTO subscribers VALUES(" + idIF.text + ", '" + NameIF.text + "', '" + LastNameIF.text + "', '" + mailIF.text + "')");
		MySqlCommand cmd = new MySqlCommand("INSERT INTO subscribers VALUES("+ idIF.text +", '"+ NameIF.text+"', '"+ LastNameIF.text+"', '"+ mailIF.text+"')");

		//MySqlCommand cmd = new MySqlCommand("DELETE FROM subscribers WHERE name='Igor'");

		cmd.Connection = con;


		con.Open();
		MySqlDataReader reader = cmd.ExecuteReader();
		
		string idInfo;
		string nameInfo;
		string lastnameInfo;
		string mailInfo;
		while (reader.Read())
		{

			idInfo = reader["id"].ToString();
			nameInfo = reader["name"].ToString();
			lastnameInfo = reader["lastname"].ToString();
			mailInfo = reader["email"].ToString();

			Debug.Log(idInfo +"   "+ nameInfo + "   " + lastnameInfo + "   " + mailInfo);
			

		}


		cmd.Connection.Close();
		cmd.Dispose();
		con.Close();

	}


	void Start()
	{
		RefreshReadDB();
	}

	public void RefreshReadDB()
    {


		AddEntryBtn.onClick.AddListener( AddEntry);




        DontDestroyOnLoad(this.gameObject);

        string someInfo;

        MySqlConnection con = new MySqlConnection(Contring);
        MySqlCommand cmd = new MySqlCommand("SELECT * FROM subscribers");
		//MySqlCommand cmd = new MySqlCommand("DELETE FROM subscribers WHERE name='Igor'");

		cmd.Connection = con;


        con.Open();
        MySqlDataReader reader = cmd.ExecuteReader();
		string idInfo;
		string nameInfo;
		string lastnameInfo;
		string mailInfo;
		while (reader.Read())
        {
            someInfo = reader["name"].ToString();
			idInfo = reader["id"].ToString();
			nameInfo = reader["name"].ToString();
			lastnameInfo = reader["lastname"].ToString();
			mailInfo = reader["email"].ToString();


			Debug.Log(idInfo + "   " + nameInfo + "   " + lastnameInfo + "   " + mailInfo);
		}


        cmd.Connection.Close();
        cmd.Dispose();
        con.Close();

    }

  
	
	// Update is called once per frame
	void Update () {
		
	}

 


     
}
