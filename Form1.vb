Imports System.Data.SqlClient

Public Class Form1
    Dim con As New SqlConnection("Data Source=RAJE\SQLEXPRESS;Initial Catalog=crudEmp;Integrated Security=True;")

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If ValidateInput() Then
            Dim id As Integer = Textid.Text
            Dim ename As String = Textname.Text
            Dim enumber As Integer = Convert.ToInt32(Textnumber.Text)
            Dim eemail As String = Textemail.Text
            Dim eaddress As String = Textaddress.Text
            Dim edob As String = DateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss")

            con.Open()
            Dim command As New SqlCommand("insert into emp_Tab values('" & id & "','" & ename & "','" & enumber & "','" & eemail & "','" & eaddress & "','" & edob & "')", con)
            command.ExecuteNonQuery()
            con.Close()

            MessageBox.Show("Record Successfully Inserted")
            LoadDataInGrid()
        End If
    End Sub

    Private Sub LoadDataInGrid()
        Dim command As New SqlCommand("select * from emp_Tab", con)
        Dim sds As New SqlDataAdapter(command)
        Dim dt As New DataTable
        sds.Fill(dt)
        DataGridView1.DataSource = dt
    End Sub

    Private Function ValidateInput() As Boolean
        If String.IsNullOrWhiteSpace(Textid.Text) Then
            MessageBox.Show("Please enter an ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        If String.IsNullOrWhiteSpace(Textname.Text) Then
            MessageBox.Show("Please enter a name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        If String.IsNullOrWhiteSpace(Textemail.Text) Then
            MessageBox.Show("Please enter an email.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        If String.IsNullOrWhiteSpace(Textaddress.Text) Then
            MessageBox.Show("Please enter an address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        If DateTimePicker1.Value > DateTime.Now Then
            MessageBox.Show("Date of birth cannot be in the future.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        If String.IsNullOrWhiteSpace(Textnumber.Text) OrElse Not IsNumeric(Textnumber.Text) Then
            MessageBox.Show("Please enter a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        Return True
    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDataInGrid()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If ValidateInput() Then
            Dim id As Integer = Textid.Text
            Dim ename As String = Textname.Text
            Dim enumber As Integer = Convert.ToInt32(Textnumber.Text)
            Dim eemail As String = Textemail.Text
            Dim eaddress As String = Textaddress.Text
            Dim edob As String = DateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss")

            con.Open()
            Dim command As New SqlCommand("update emp_Tab set ename = '" & ename & "', enumber = '" & enumber & "', eemail = '" & eemail & "', eaddress = '" & eaddress & "', edob = '" & edob & "' where id = '" & id & "'", con)
            command.ExecuteNonQuery()
            con.Close()

            MessageBox.Show("Record Successfully Updated")
            LoadDataInGrid()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If MessageBox.Show("Are You Sure To Delete?", "Delete Document", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Dim id As Integer = Textid.Text
            con.Open()
            Dim command As New SqlCommand("delete from emp_Tab where id = '" & id & "'", con)
            command.ExecuteNonQuery()
            con.Close()
            MessageBox.Show("Record deleted Successfully")
            LoadDataInGrid()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim id As Integer = Textid.Text
        Dim command As New SqlCommand("select * from emp_Tab where id = '" & id & "'", con)
        Dim sds As New SqlDataAdapter(command)
        Dim dt As New DataTable
        sds.Fill(dt)
        DataGridView1.DataSource = dt
    End Sub
End Class
