Imports System.Data.SqlClient
Public Class Form1
    Public conn As New SqlConnection("Data Source=ALLMANKIND\MSSQLSERVER8; Database=db_vbtodo; Integrated Security=True")
    Public adapter As New SqlDataAdapter
    Dim ds As DataSet
    Dim currentid As String

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetRecords()
    End Sub

    Public Sub GetRecords()
        ds = New DataSet
        adapter = New SqlDataAdapter("select * from tbl_tasks", conn)
        adapter.Fill(ds, "tbl_tasks")
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "tbl_tasks"
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ds = New DataSet
        adapter = New SqlDataAdapter("insert into tbl_tasks (task_name) VALUES ('" & TextBox1.Text & "')", conn)
        adapter.Fill(ds, "tbl_tasks")
        GetRecords()
        TextBox1.Clear()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        currentid = DataGridView1.Item(0, i).Value.ToString()

        ds = New DataSet
        adapter = New SqlDataAdapter("delete from tbl_tasks where id = " & currentid, conn)
        adapter.Fill(ds, "tbl_tasks")
        GetRecords()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        currentid = DataGridView1.Item(0, i).Value.ToString()
        TextBox1.Text = DataGridView1.Item(1, i).Value.ToString()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ds = New DataSet
        adapter = New SqlDataAdapter("update tbl_tasks set task_name = '" & TextBox1.Text &
                                     "' where id = " & currentid, conn)
        adapter.Fill(ds, "tbl_tasks")
        TextBox1.Clear()
        GetRecords()
    End Sub
End Class
