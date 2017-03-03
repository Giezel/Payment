Imports System.Windows.Forms

Public Class Main

    Private Sub ShowStudentType(ByVal sender As Object, ByVal e As EventArgs) Handles NewToolStripMenuItem.Click, NewWindowToolStripMenuItem.Click
        ' Create a new instance of the child form.
        'Dim ChildForm As New System.Windows.Forms.Form
        ' Make it a child of this MDI form before showing it.
        StudentType.MdiParent = Me

        'm_ChildFormNumber += 1
        'ChildForm.Text = "Window " & m_ChildFormNumber

        StudentType.Show()
    End Sub

    Private Sub ParentInfoMenu_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ParentInfoMenu.Click
        Parent_Info.MdiParent = Me
        Parent_Info.Show()
    End Sub

  
    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CloseAllToolStripMenuItem.Click
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer

    Private Sub Payment_Type_Menu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Payment_Type_Menu.Click
        PaymentType.MdiParent = Me
        PaymentType.Show()
    End Sub


    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoginForm1.MdiParent = Me
        LoginForm1.Show()
        StudentMenu.Enabled = True
        PaymentMenu.Enabled = True
        ParentMenu.Enabled = True
    End Sub
End Class
