Imports MySql.Data.MySqlClient

Public Class StudentType

    Private Sub StudentType_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        conn_str()
        StudTypeDG.ColumnCount = 2

        StudTypeDG.Columns(0).Name = "ID"
        StudTypeDG.Columns(1).Name = "Name"

        StudTypeDG.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Retrieve_StudInfo()

    End Sub


    Private Sub ClearText()
        txtName.Text = ""
    End Sub

    Private Sub Insert_StudType()
        Dim sql As String = "insert into student_type_info(name) values (@fname)"
        Dim cmd = New MySqlCommand(sql, conn)

        cmd.Parameters.AddWithValue("@fname", txtName.Text)

        Try
            conn.Open()
            If cmd.ExecuteNonQuery() > 0 Then
                MsgBox("Record has been successfully added")
                ClearText()
            End If
            conn.Close()
            Retrieve_StudInfo()
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
    End Sub

    Private Sub Retrieve_StudInfo()
        StudTypeDG.Rows.Clear()
        Dim sql As String = "select * from student_type_info"
        Dim cmd = New MySqlCommand(sql, conn)

        Try
            conn.Open()
            adapter = New MySqlDataAdapter(cmd)
            adapter.Fill(dt)
            For Each row In dt.Rows
                Populate(row(0), row(1))
            Next
            conn.Close()
            dt.Rows.Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
    End Sub


    Private Sub Populate(ByVal id As String, ByVal name As String)
        Dim row As String() = New String() {id, name}

        StudTypeDG.Rows.Add(row)

    End Sub

    

    Private Sub StudTypeDG_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles StudTypeDG.CellClick
        Dim id As String = StudTypeDG.SelectedRows(0).Cells(0).Value()
        Dim sql As String = "select * from student_type_info where id='" + id + "'"
        Dim cmd = New MySqlCommand(sql, conn)

        Try
            conn.Open()
            reader = cmd.ExecuteReader
            Do While reader.Read()
                txtName.Text = reader.GetString(1)
            Loop
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try

    End Sub


    Private Sub Delete_StudType(ByVal id As String)
        Dim sql As String = "delete from student_type_info where id ='" + id + "'"
        Dim cmd = New MySqlCommand(sql, conn)

        Try
            conn.Open()
            adapter.DeleteCommand = conn.CreateCommand
            adapter.DeleteCommand.CommandText = sql
            If MessageBox.Show("Sure?", "DELETE", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.OK Then
                If cmd.ExecuteNonQuery() > 0 Then
                    MsgBox("Record has been successfully Deleted")
                    ClearText()
                End If
            End If
            conn.Close()
            Retrieve_StudInfo()

        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
    End Sub


    Private Sub Update_StudType(ByVal id As String)
        Dim sql As String = "update student_type_info set name='" + txtName.Text + "'"

        Try
            conn.Open()
            adapter.UpdateCommand = conn.CreateCommand
            adapter.UpdateCommand.CommandText = sql
            If adapter.UpdateCommand.ExecuteNonQuery() > 0 Then
                MsgBox("Record has been successfully Updated")
                ClearText()
            End If
            conn.Close()
            Retrieve_StudInfo()
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Insert_StudType()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim id As String = StudTypeDG.SelectedRows(0).Cells(0).Value
        Delete_StudType(id)
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Dim id As String = StudTypeDG.SelectedRows(0).Cells(0).Value
        Update_StudType(id)
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        ClearText()
    End Sub
End Class