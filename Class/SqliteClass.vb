Public Class SqliteClass
    Private _dbPath As String
    Public Property DBPath As String
        Get
            Return _dbPath
        End Get
        Set(value As String)
            _dbPath = value
        End Set
    End Property
    Public Sub New()

    End Sub
    ''' <summary>
    ''' Initialize Class with Dbpath
    ''' </summary>
    ''' <param name="dbpath"></param>
    Public Sub New(ByVal dbpath As String)
        _dbPath = dbpath
    End Sub
    Private ReadOnly Property ConnectionString As String
        Get
            Dim myConnString As String
            myConnString = "Data Source=" & _dbPath & ";" & "New=False;Compress=True;Synchronous=Off"
            Return myConnString
        End Get
    End Property
    Public Function SetPassword(ByVal password As String, ByVal path As String) As Boolean
        Dim conn As SQLite.SQLiteConnection
        Dim myConnString As String
        myConnString = "Data Source=" & path & ";" & "New=False;Compress=True;Synchronous=Off"
        conn = New SQLiteConnection(myConnString)
        conn.Open()
        conn.ChangePassword(password)
        If conn.State = ConnectionState.Open Then
            Return True
        Else
            Return False
        End If
    End Function
    'Public Function RemovePassword(ByVal path As String) As Boolean
    '    Dim conn As SQLite.SQLiteConnection
    '    Dim myConnString As String
    '    myConnString = "Data Source=" & path & ";" & "New=False;Compress=True;password=" & My.Settings.dbpassword & ";" & "Synchronous=Off"
    '    conn = New SQLiteConnection(myConnString)
    '    conn.Open()
    '    conn.ChangePassword(String.Empty)
    '    If conn.State = ConnectionState.Open Then
    '        Return True
    '    Else
    '        Return False
    '    End If
    'End Function
    ''' <summary>
    ''' Reads data from sqlite database
    ''' </summary>
    ''' <param name="ReadFields"></param>
    ''' <param name="tableName"></param>
    ''' <param name="Condition"></param>
    ''' <param name="SortField"></param>
    ''' <param name="SortOrder"></param>
    ''' <param name="GroupByValue"></param>
    ''' <returns> dataTable </returns>
    ''' <remarks></remarks>
    Public Function ReadDataFromTable(ByVal ReadFields As String,
           ByVal tableName As String, Optional ByVal Condition _
           As String = "", Optional ByVal SortField As String = "",
           Optional ByVal SortOrder As String = "ASC",
           Optional ByVal GroupByValue As String = "") As System.Data.DataTable
        Dim myconn As SQLiteConnection = New SQLiteConnection
        Dim Cmd As String
        Cmd = "SELECT " + ReadFields + " FROM " + tableName
        If Condition <> "" Then
            Cmd = Cmd + " WHERE " + Condition
        End If
        If Trim(GroupByValue) <> "" Then
            Cmd = Cmd + " GROUP BY " + GroupByValue
        End If
        If SortField <> "" Then
            Cmd = Cmd + " ORDER BY " + SortField + " " + SortOrder
        End If
        Try
            Dim tbl As New System.Data.DataTable
            myconn.ConnectionString = Me.ConnectionString
            myconn.Open()
            Dim OAdapter As New SQLite.SQLiteDataAdapter(Cmd, myconn)
            OAdapter.Fill(tbl)
            Return tbl
        Catch ex As SQLiteException
            MsgBox(ex.Message)
            Return Nothing
        Finally
            myconn.Dispose()
        End Try

    End Function
    ''' <summary>
    ''' Reads Data From sqlite database.
    ''' </summary>
    ''' <param name="cmdStr"></param>
    ''' <returns> Datatable</returns>
    ''' <remarks></remarks>
    Public Function ReadDataFromTable(ByVal cmdStr As String) As System.Data.DataTable
        Dim myconn As SQLiteConnection = New SQLiteConnection
        Try
            myconn.ConnectionString = Me.ConnectionString
            myconn.Open()
            Dim tbl As New System.Data.DataTable
            Dim OAdapter As New SQLite.SQLiteDataAdapter(cmdStr, myconn)
            OAdapter.Fill(tbl)
            Return tbl
        Catch ex As SQLiteException
            MsgBox(ex.Message)
            Return Nothing
        Finally
            myconn.Dispose()
        End Try
    End Function
    ''' <summary>
    ''' Delete Record from Sqlite Database.
    ''' </summary>
    ''' <param name="sTableName"></param>
    ''' <param name="sCondition"></param>
    ''' <returns></returns>
    Public Function DeleteRecord(ByVal sTableName As String, Optional ByVal sCondition As String = "") As Boolean
        Dim Cmd As String
        Try
            Cmd = "DELETE FROM " + sTableName
            If sCondition <> "" Then
                Cmd = Cmd + " WHERE " + sCondition
            End If
            ExecuteByQuery(Cmd)
            Return True
        Catch
            Return False
        End Try
    End Function
    ''' <summary>
    ''' Insert Record to Sqlite Database.
    ''' </summary>
    ''' <param name="sTableName"></param>
    ''' <param name="sFieldValue"></param>
    ''' <param name="sFieldName"></param>
    ''' <returns></returns>
    Public Function InsertRecord(ByVal sTableName As String, ByVal sFieldValue As String, Optional ByVal sFieldName As String = "") As Boolean
        Dim Cmd As String
        Try
            Cmd = "INSERT INTO " + sTableName
            If sFieldName <> "" Then
                Cmd = Cmd + " ( " + sFieldName + " )"
            End If
            Cmd = Cmd + " VALUES("
            Cmd = Cmd + sFieldValue + ")"
            ExecuteByQuery(Cmd)
            Return True
        Catch
            Return False
        End Try
    End Function
    ''' <summary>
    ''' Update data in Sqlite Database.
    ''' </summary>
    ''' <param name="sTableName"></param>
    ''' <param name="sFieldValue"></param>
    ''' <param name="condition"></param>
    ''' <returns></returns>
    Public Function UpdateRecord(ByVal sTableName As String, ByVal sFieldValue As String, Optional ByVal condition As String = "") As Boolean
        Dim Cmd As String
        Try
            Cmd = "UPDATE " + sTableName + " SET " + sFieldValue
            If condition <> "" Then
                Cmd = Cmd + " WHERE " + condition
            End If
            ExecuteByQuery(Cmd)
            Return True
        Catch
            Return False
        End Try
    End Function
    Public Sub ExecuteByQuery(ByVal sCmd As String)
        Dim myconn As SQLiteConnection = New SQLiteConnection
        Try
            myconn.ConnectionString = Me.ConnectionString
            myconn.Open()
            Dim oSqlCmd As SQLiteCommand
            oSqlCmd = New SQLiteCommand(sCmd, myconn)
            oSqlCmd.ExecuteNonQuery()
        Catch ex As Exception
        Finally
            myconn.Dispose()
        End Try
    End Sub
    Public Function UserVersion() As Long
        'Dim uv As Long
        'Dim dt As DataTable = ReadDataFromTable("SELECT * FROM pragma_user_version;")
        'If dt.Rows.Count > 0 Then
        '    For Each drow As DataRow In dt.Rows
        '        uv = CLng(drow("user_version"))
        '    Next
        'End If
        'Return uv
        Dim myconn As SQLiteConnection = New SQLiteConnection
        Try
            myconn.ConnectionString = Me.ConnectionString
            myconn.Open()
            Using cmd As SQLiteCommand = New SQLiteCommand(myconn)
                cmd.CommandText = "pragma user_version;"
                Return CLng(cmd.ExecuteScalar())
            End Using
        Catch ex As Exception
        Finally
            myconn.Close()
        End Try
    End Function
    Public Function IncreaseUserVersion() As Long

        Dim myconn As SQLiteConnection = New SQLiteConnection
        Try
            myconn.ConnectionString = Me.ConnectionString
            myconn.Open()
            Dim version As Long = UserVersion()

            Using cmd As SQLiteCommand = New SQLiteCommand(myconn)
                cmd.CommandText = String.Format("PRAGMA user_version={0}", version + 1)
                cmd.ExecuteNonQuery()
            End Using
            Return UserVersion()
        Catch ex As Exception
        Finally
            myconn.Close()
        End Try

    End Function
    Public Function Transaction(ByVal sSQLCmd As String()) As Boolean
        Dim myconn As SQLiteConnection = New SQLiteConnection
        Dim sqlTrans As SQLiteTransaction = Nothing
        Dim oSqlCmds As New SQLiteCommand()
        myconn.ConnectionString = Me.ConnectionString
        myconn.Open()
        sqlTrans = myconn.BeginTransaction(IsolationLevel.ReadCommitted)
        Try
            Dim i As Integer = 0
            oSqlCmds.Connection = myconn
            oSqlCmds.Transaction = sqlTrans
            i = 0
            While i <= sSQLCmd.Length - 1
                oSqlCmds.CommandText = sSQLCmd(i)
                oSqlCmds.ExecuteNonQuery()
                System.Math.Max(System.Threading.Interlocked.Increment(i), i - 1)
            End While
            sqlTrans.Commit()
            Return True
        Catch ex As Exception
            Try
                sqlTrans.Rollback()
            Catch ex2 As SQLiteException
            End Try
            Return False
        Finally
            sSQLCmd = Nothing
            myconn.Dispose()
        End Try
    End Function
    'Public Function LastID(ByVal tblname As String, ByVal idcolumn As String) As String
    '    Dim dt As DataTable = objPostsql.ReadDataFromTable("max(" & idcolumn & ")", tblname)
    '    Dim [last] As String
    '    If dt.Rows.Count > 0 Then
    '        last = dt.Rows(0)(0).ToString
    '        Return last
    '    Else
    '        Return String.Empty
    '    End If
    'End Function

End Class
