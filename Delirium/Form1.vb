
Imports System.Data.SqlClient
Public Class Form1

    Dim WithEvents tmr As New Timer
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Public Property MultipleActiveResultSets As Boolean
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tmr.Interval = 500
        tmr.Start()



    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub
    Private Sub tmr_tick() Handles tmr.Tick
        Dim Connection As MySqlConnection
        Dim command As MySqlCommand
        Connection = New MySqlConnection

        Connection.ConnectionString = "Server=192.168.1.44;port=3306;Database=delirium;Uid=root;Pwd=root"
        MultipleActiveResultSets = True

        Try
            Connection.Open()
            Dim reader As MySqlDataReader
            Dim query As String

            query = "Select status from delirium.Delirium where id = 1"
            command = New MySqlCommand(query, Connection)
            reader = command.ExecuteReader
            'Do
            If reader.IsClosed = False Then
                command = New MySqlCommand(query, Connection)
                While reader.Read
                    Dim sname As String
                    sname = reader.GetString("status")
                    Label3.Text = sname
                End While
                reader.Close()
            ElseIf reader.IsClosed = True Then
                reader = command.ExecuteReader
            End If
            Label4.Text = 1
            'Loop Until 

            Connection.Close()
        Catch ex As MySqlException
            'MsgBox(ex.Message)
        Finally

            Connection.Dispose()
        End Try
    End Sub
End Class
