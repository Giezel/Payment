Imports MySql.Data.MySqlClient

Public Class PaymentType

    Private Sub PaymentType_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        conn_str()

        txtName.Enabled = False
        btnAdd.Enabled = True
        btnUpdate.Enabled = True
        btnDelete.Enabled = True
        btnClear.Enabled = True

        PaymentTypeDG.ColumnCount = 2

        PaymentTypeDG.Columns(0).Name = "ID"
        PaymentTypeDG.Columns(1).Name = "NAME"

        PaymentTypeDG.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Retrieve_PaymentType()


    End Sub

    Private Sub ClearText()
        txtName.Text = ""
    End Sub

    Private Sub Insert_PaymentType()
        If txtName.Text = "" Then
            MsgBox("Please Fill Name Field")
        Else
            Dim sql As String = "insert into payment_type_info(name) values (@name)"
            Dim cmd = New MySqlCommand(sql, conn)

            cmd.Parameters.AddWithValue("@name", txtName.Text)

            Try
                conn.Open()
                If cmd.ExecuteNonQuery() > 0 Then
                    MsgBox("Record has been successfully Added")
                    ClearText()
                End If
                conn.Close()
                Retrieve_PaymentType()
            Catch ex As Exception
                MsgBox(ex.Message)
                conn.Close()
            End Try
        End If
        

    End Sub


    Private Sub Retrieve_PaymentType()
        PaymentTypeDG.Rows.Clear()

        Dim sql As String = "select * from payment_type_info"
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

        PaymentTypeDG.Rows.Add(row)

    End Sub


    Private Sub Delete_PaymentType(ByVal id As String)
        Dim sql As String = "delete from payment_type_info where id='" + id + "'"
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
            Retrieve_PaymentType()

        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
    End Sub

    Private Sub Update_PaymentType(ByVal id As String)
        Dim sql As String = "update payment_type_info set name='" + txtName.Text + "' where id='" + id + "'"
        Try
            conn.Open()
            adapter.UpdateCommand = conn.CreateCommand
            adapter.UpdateCommand.CommandText = sql
            If adapter.UpdateCommand.ExecuteNonQuery() > 0 Then
                MsgBox("Record has been successfully Updated")
                ClearText()
            End If
            conn.Close()
            Retrieve_PaymentType()

        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
    End Sub



    'BUTTONS

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If btnAdd.Text = "ADD" Then
            btnAdd.Text = "SAVE"
            txtName.Enabled = True
            btnUpdate.Enabled = False
            btnDelete.Enabled = False
            btnClear.Enabled = False

        Else
            btnAdd.Text = "ADD"
            txtName.Enabled = False
            btnUpdate.Enabled = True
            btnDelete.Enabled = True
            btnClear.Enabled = True
            Insert_PaymentType()
        End If

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim id As String = PaymentTypeDG.SelectedRows(0).Cells(0).Value
        Delete_PaymentType(id)
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Dim id As String = PaymentTypeDG.SelectedRows(0).Cells(0).Value

        If btnUpdate.Text = "UPDATE" Then
            btnUpdate.Text = "SAVE"
            txtName.Enabled = True
            btnAdd.Enabled = False
            btnDelete.Enabled = False
            btnClear.Enabled = False

        Else
            btnUpdate.Text = "UPDATE"
            txtName.Enabled = False
            btnAdd.Enabled = True
            btnDelete.Enabled = True
            btnClear.Enabled = True
            Update_PaymentType(id)
        End If

    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        ClearText()
    End Sub

    'EVENTS

    Private Sub PaymentTypeDG_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles PaymentTypeDG.CellClick
        Dim id As String = PaymentTypeDG.SelectedRows(0).Cells(0).Value

        Dim sql As String = "select * from payment_type_info where id='" + id + "'"
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
End Class