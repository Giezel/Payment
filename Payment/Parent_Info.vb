Imports MySql.Data.MySqlClient

Public Class Parent_Info

    Private Sub Parent_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        conn_str()
        ParentDG.ColumnCount = 4

        ParentDG.Columns(0).Name = "ID"
        ParentDG.Columns(0).Visible = False
        ParentDG.Columns(1).Name = "First Name"
        ParentDG.Columns(2).Name = "Middle Name"
        ParentDG.Columns(3).Name = "Last Name"

        ParentDG.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Retrieve()
    End Sub



    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Insert_Parent()
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Dim id As String = ParentDG.SelectedRows(0).Cells(0).Value()
        Update_Parent(id)
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim id As String = ParentDG.SelectedRows(0).Cells(0).Value()
        Delete_Parent(id)
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        ClearText()
    End Sub


    'PUBLIC METHODS'

    Private Sub Insert_Parent()
        Dim sql As String = "insert into parent_info(fname,mname,lname) values (@fname,@mname,@lname)"
        Dim cmd = New MySqlCommand(sql, conn)

        cmd.Parameters.AddWithValue("@fname", txtFname.Text)
        cmd.Parameters.AddWithValue("@mname", txtMname.Text)
        cmd.Parameters.AddWithValue("@lname", txtLname.Text)

        Try
            conn.Open()
            If cmd.ExecuteNonQuery() > 0 Then
                MsgBox("Record Successfully Added")
                ClearText()
            End If
            conn.Close()
            Retrieve()
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()

        End Try
    End Sub

    Private Sub Retrieve()
        ParentDG.Rows.Clear()

        Dim sql As String = "select * from parent_info"
        Dim cmd = New MySqlCommand(sql, conn)

        Try
            conn.Open()
            adapter = New MySqlDataAdapter(cmd)
            adapter.Fill(dt)

            For Each row In dt.Rows
                Populate(row(0), row(1), row(2), row(3))
            Next
            conn.Close()
            dt.Rows.Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try

    End Sub

    Private Sub Populate(ByVal id As String, ByVal fname As String, ByVal mname As String, ByVal lname As String)
        Dim row As String() = New String() {id, fname, mname, lname}
        ParentDG.Rows.Add(row)
    End Sub

    Private Sub ClearText()
        txtFname.Text = ""
        txtMname.Text = ""
        txtLname.Text = ""
    End Sub


    Private Sub Delete_Parent(ByVal id As String)
        Dim sql As String = "delete from parent_info where id='" + id + "'"
        Dim cmd = New MySqlCommand(sql, conn)

        Try
            conn.Open()
            adapter.DeleteCommand = conn.CreateCommand
            adapter.DeleteCommand.CommandText = sql
            If MessageBox.Show("Sure?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.OK Then
                If cmd.ExecuteNonQuery() > 0 Then
                    MsgBox("Record has been successfully Deleted")
                    ClearText()
                End If
            End If
            conn.Close()
            Retrieve()
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
    End Sub


    Private Sub Update_Parent(ByVal id As String)
        Dim sql As String = "update parent_info set fname='" + txtFname.Text + "',mname='" + txtMname.Text + "',lname='" + txtLname.Text + "' where id = '" + id + "'"

        Try
            conn.Open()
            adapter.UpdateCommand = conn.CreateCommand
            adapter.UpdateCommand.CommandText = sql
            If adapter.UpdateCommand.ExecuteNonQuery() > 0 Then
                MsgBox("Record has been successfully Updated")
            End If
            conn.Close()
            Retrieve()
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
    End Sub

    Private Sub ParentDG_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ParentDG.CellClick
        'Dim fname As String = ParentDG.SelectedRows(0).Cells(1).Value
        'Dim mname As String = ParentDG.SelectedRows(0).Cells(2).Value
        'Dim lname As String = ParentDG.SelectedRows(0).Cells(3).Value

        'txtFname.Text = fname
        'txtMname.Text = mname
        'txtLname.Text = lname
        Dim id As String = ParentDG.SelectedRows(0).Cells(0).Value
        Dim sql As String = "select * from parent_info where id='" + id + "'"
        Dim cmd = New MySqlCommand(sql, conn)

        Try
            conn.Open()
            reader = cmd.ExecuteReader
            Do While reader.Read()
                txtFname.Text = reader.GetString(1)
                txtMname.Text = reader.GetString(2)
                txtLname.Text = reader.GetString(3)
            Loop
            conn.Close()


        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try


    End Sub
End Class
