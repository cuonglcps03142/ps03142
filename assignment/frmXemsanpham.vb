Imports System.Data.SqlClient
Imports System.Data.DataSet
Public Class frmXemsanpham
    Dim db As New DataTable
    Dim chuoiketnoi As String = "workstation id=ps03142.mssql.somee.com;packet size=4096;user id=cuongps03142;pwd=chicuong@512;data source=ps03142.mssql.somee.com;persist security info=False;initial catalog=ps03142"
    Dim connect As SqlConnection = New SqlConnection(chuoiketnoi)
    Private Sub btnXemall_Click(sender As Object, e As EventArgs) Handles btnXemall.Click
        Dim hienthi As New Class1
        dgvXemsp.DataSource = hienthi.Loadsanpham.Tables(0)
    End Sub

    Private Sub btnXem_Click(sender As Object, e As EventArgs) Handles btnXem.Click
        Dim connect As SqlConnection = New SqlConnection(chuoiketnoi)
        connect.Open()
        Dim timkiem As SqlDataAdapter = New SqlDataAdapter("select SANPHAMPS03142.MASP as 'Mã sản phẩm',SANPHAMPS03142.TENSP as 'Tên sản phẩm', LOAISANPHAMPS03142.MALOAI as 'Mã Loại', LOAISANPHAMPS03142.TENLOAI as 'Tên Loại',SANPHAMPS03142.SOLUONG as 'Số lượng' from SANPHAMPS03142 inner join LOAISANPHAMPS03142 on SANPHAMPS03142.MASP = LOAISANPHAMPS03142.MASP where SANPHAMPS03142.MASP ='" & txtMASP.Text & "' ", connect)
        Try
            If txtMASP.Text = "" Then
                MessageBox.Show("Bạn cần nhập mã sản phẩm", "Nhập thiếu", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                db.Clear()
                dgvXemsp.DataSource = Nothing
                timkiem.Fill(db)
                If db.Rows.Count > 0 Then
                    dgvXemsp.DataSource = db.DefaultView
                    txtMASP.Text = Nothing
                Else
                    MessageBox.Show("Không tìm được")
                    txtMASP.Text = Nothing
                End If
            End If
            connect.Close()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnDong_Click(sender As Object, e As EventArgs) Handles btnDong.Click
        Me.Close()
    End Sub
End Class