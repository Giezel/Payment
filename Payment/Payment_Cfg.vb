Imports MySql.Data.MySqlClient

Public Class Payment_Cfg


    Private Sub Payment_Cfg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        conn_str()

        PaymentCfgDG.ColumnCount = 5

        PaymentCfgDG.Columns(0).Name = "ID"
        PaymentCfgDG.Columns(1).Name = "DATE EFFECT"
        PaymentCfgDG.Columns(2).Name = "PAYMENT TYPE"
        PaymentCfgDG.Columns(3).Name = "STUDENT TYPE"
        PaymentCfgDG.Columns(4).Name = "AMOUNT"

        PaymentCfgDG.SelectionMode = DataGridViewSelectionMode.FullRowSelect


        Populate_PaymentType()
        Populate_StudentType()

        Retrieve_PaymentCfg()

    End Sub

    Private Sub Populate_PaymentType()
        Dim sql As String = "select id, name from payment_type_info"
        Dim adapter As New MySqlDataAdapter(sql, conn)
        Dim dt As New DataSet
        adapter.Fill(ds, "payment_type_info")
        With cmbPaymentType
            .DataSource = ds.Tables("payment_type_info")
            .DisplayMember = "name"
            .ValueMember = "id"
            .SelectedIndex = 0
        End With
    End Sub


    Private Sub Populate_StudentType()
        Dim sql As String = "select id, name from student_type_info"
        Dim adapter As New MySqlDataAdapter(sql, conn)
        Dim ds As New DataSet
        adapter.Fill(ds, "student_type_info")
        With cmbStudentType
            .DataSource = ds.Tables("student_type_info")
            .DisplayMember = "name"
            .ValueMember = "id"
            .SelectedIndex = 0
        End With
    End Sub

    Private Sub ClearText()
        dtpDateEffect.Text = ""
        cmbPaymentType.Text = ""
        cmbStudentType.Text = ""
        txtAmount.Text = ""
    End Sub



    Private Sub Insert_PaymentCfg()
        Dim sql As String = "insert into payment_cfg(effective_date,payment_type_id,stud_type_id, amount) values (@effective_date,@payment_type_id,@stud_type_id,@amount)"
        cmd = New MySqlCommand(sql, conn)

        cmd.Parameters.AddWithValue("@effective_date", dtpDateEffect.Value.ToString("yyyy-MM-dd"))
        cmd.Parameters.AddWithValue("@payment_type_id", cmbPaymentType.SelectedValue.ToString)
        cmd.Parameters.AddWithValue("@stud_type_id", cmbStudentType.SelectedValue.ToString)
        cmd.Parameters.AddWithValue("@amount", txtAmount.Text)

        Try
            conn.Open()
            If cmd.ExecuteNonQuery() > 0 Then
                MsgBox("Record has been successfully Added")
                ClearText()
            End If
            conn.Close()
            Retrieve_PaymentCfg()
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
    End Sub

    Private Sub Retrieve_PaymentCfg()
        PaymentCfgDG.Rows.Clear()

        Dim sql As String = "select id, effective_date, " + _
                            "(select name from payment_type_info where id = payment_type_id) payment, " + _
                            "(select name from student_type_info where id = stud_type_id) student," + _
                            "amount from payment_cfg"
        cmd = New MySqlCommand(sql, conn)

        Try
            adapter = New MySqlDataAdapter(cmd)
            adapter.Fill(dt)
            For Each row In dt.Rows
                Populate_PaymentCfg(row(0), row(1), row(2), row(3), row(4))
            Next
            conn.Close()
            dt.Rows.Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try

    End Sub


    Private Sub Delete_PaymentCfg(ByVal id As String)
        Dim sql As String = "delete from payment_cfg where id='" + id + "'"
        cmd = New MySqlCommand(sql, conn)

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
            Retrieve_PaymentCfg()
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try

    End Sub


    Private Sub Update_PaymentCfg(ByVal id As String)
        Dim sql As String = "update payment_cfg set effective_date ='" + dtpDateEffect.Value.ToString("yyyy-MM-dd") + "', " + _
                            "stud_type_id = '" + cmbStudentType.SelectedValue.ToString + "',payment_type_id ='" + cmbPaymentType.SelectedValue.ToString + "', " + _
                            "amount ='" + txtAmount.Text + "' where id='" + id + "'"
        Try
            conn.Open()
            adapter.UpdateCommand = conn.CreateCommand
            adapter.UpdateCommand.CommandText = sql
            If adapter.UpdateCommand.ExecuteNonQuery() > 0 Then
                MsgBox("Record has been successfully Updated")
                ClearText()
            End If
            conn.Close()
            Retrieve_PaymentCfg()
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try

    End Sub

    Private Sub Populate_PaymentCfg(ByVal id As String, ByVal effective_date As String, ByVal payment_type_id As String, ByVal stud_type_id As String, ByVal amount As String)
        Dim row As String() = New String() {id, effective_date, payment_type_id, stud_type_id, amount}
        PaymentCfgDG.Rows.Add(row)
    End Sub

   
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Insert_PaymentCfg()
    End Sub


    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Dim id As String = PaymentCfgDG.SelectedRows(0).Cells(0).Value
        Update_PaymentCfg(id)
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim id As String = PaymentCfgDG.SelectedRows(0).Cells(0).Value
        Delete_PaymentCfg(id)
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        ClearText()
    End Sub

    Private Sub PaymentCfgDG_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles PaymentCfgDG.CellClick
        Dim id As String = PaymentCfgDG.SelectedRows(0).Cells(0).Value
        Dim sql As String = "select id, effective_date, " + _
                            "(select name from payment_type_info where id = payment_type_id) payment, " + _
                            "(select name from student_type_info where id = stud_type_id) student," + _
                            "amount from payment_cfg where id='" + id + "'"
        cmd = New MySqlCommand(sql, conn)

        Try
            conn.Open()
            reader = cmd.ExecuteReader
            Do While reader.Read
                dtpDateEffect.Text = reader.GetString(1)
                cmbPaymentType.Text = reader.GetString(2)
                cmbStudentType.Text = reader.GetString(3)
                txtAmount.Text = reader.GetString(4)
            Loop
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()

        End Try

    End Sub
End Class