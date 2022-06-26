Imports System
Imports System.Collections.Generic
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Linq
Imports System.Web


Public Class SqlDbAccess

    public Function GetData As String
        dim connectionString = ConfigurationManager.ConnectionStrings("SqlDbAccess").ConnectionString
        dim dataResult As List(Of String) = New List(Of String)()
        Using sqlConnection As SqlConnection = new SqlConnection(connectionString)
            sqlConnection.Open()
            using sqlCommand = New SqlCommand("SELECT * FROM Table", sqlConnection)
                dim sqlDataReader = sqlCommand.ExecuteReader()
                While sqlDataReader.Read()
                    dataResult.Add(sqlDataReader("ColumnName").ToString())
                End While
                sqlConnection.Close()
            end Using 
        End Using

        return String.Join(",", dataResult)
    End Function
End Class
