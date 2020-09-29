using System;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;

public class DataBaseConnection
{
    string ConStr = string.Empty;
    public DataBaseConnection()
    {
        ConStr = ConfigurationManager.ConnectionStrings["ConStrMySql"].ConnectionString;
    }

    public DataTable ExecuteSelect(string Query, params MySqlParameter[] commandParameters)
    {
        DataTable dt = new DataTable();
        using (MySqlConnection _MySqlConnection = new MySqlConnection(ConStr))
        {
            using (MySqlCommand _MySqlCommand = new MySqlCommand(Query, _MySqlConnection))
            {
                using (MySqlDataAdapter _MySqlDataAdapter = new MySqlDataAdapter())
                {
                    _MySqlCommand.Parameters.Clear();
                    foreach (MySqlParameter PR in commandParameters)
                    {
                        _MySqlCommand.Parameters.Add(PR);
                    }
                    dt.Clear();
                    _MySqlDataAdapter.SelectCommand = _MySqlCommand;
                    _MySqlDataAdapter.Fill(dt);
                    if (_MySqlConnection.State != ConnectionState.Closed)
                        _MySqlConnection.Close();
                }
            }
        }
        return dt;
    }
    public Int32 ExecuteInsert(string Query, params MySqlParameter[] commandParameters)
    {
        Int32 ExecutedRows = 0;
        using (MySqlConnection _MySqlConnection = new MySqlConnection(ConStr))
        {
            using (MySqlCommand _MySqlCommand = new MySqlCommand(Query, _MySqlConnection))
            {
                foreach (MySqlParameter PR in commandParameters)
                {
                    _MySqlCommand.Parameters.Add(PR);
                }
                if (_MySqlConnection.State != ConnectionState.Open)
                    _MySqlConnection.Open();
                ExecutedRows = _MySqlCommand.ExecuteNonQuery();
                if (_MySqlConnection.State != ConnectionState.Closed)
                    _MySqlConnection.Close();
            }
        }
        return ExecutedRows;
    }
    public Int32 ExecuteUpdate(string Query, params MySqlParameter[] commandParameters)
    {
        return ExecuteInsert(Query, commandParameters);
    }
    public string FillList(string Query, DropDownList _list, params MySqlParameter[] commandParameters)
    {
        string ErrorMessage;
        DataTable dt = ExecuteSelect(Query, commandParameters);
        if (dt.Columns.Count != 2)
        {
            ErrorMessage = "this table do not have 2 columns";
        }
        else
        {
            _list.DataValueField = dt.Columns[0].ToString();
            _list.DataTextField = dt.Columns[1].ToString();
            _list.DataSource = dt;
            _list.DataBind();
            _list.Items.Insert(0, new ListItem("Select", "0"));
            ErrorMessage = "SUCCESS";
        }
        return ErrorMessage;
    }
    public string FillList(string Query, ListBox _list, params MySqlParameter[] commandParameters)
    {
        string ErrorMessage;
        DataTable dt = ExecuteSelect(Query, commandParameters);
        if (dt.Columns.Count != 2)
        {
            ErrorMessage = "this table do not have 2 columns";
        }
        else
        {
            _list.DataValueField = dt.Columns[0].ToString();
            _list.DataTextField = dt.Columns[1].ToString();
            _list.DataSource = dt;
            _list.DataBind();
            _list.Items.Insert(0, new ListItem("Select", "0"));
            ErrorMessage = "SUCCESS";
        }
        return ErrorMessage;
    }
    public string FillList(string Query, RadioButtonList _list, params MySqlParameter[] commandParameters)
    {
        string ErrorMessage;
        DataTable dt = ExecuteSelect(Query, commandParameters);
        if (dt.Columns.Count != 2)
        {
            ErrorMessage = "this table do not have 2 columns";
        }
        else
        {
            _list.DataValueField = dt.Columns[0].ToString();
            _list.DataTextField = dt.Columns[1].ToString();
            _list.DataSource = dt;
            _list.DataBind();
            _list.Items.Insert(0, new ListItem("Select", "0"));
            ErrorMessage = "SUCCESS";
        }
        return ErrorMessage;
    }
}