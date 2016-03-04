Imports System.Data.SqlClient
Imports System.Data
Public Class Class1
    Public Function Loadkhachang() As DataSet
        Dim chuoiketnoi As String = "workstation id=ps03142.mssql.somee.com;packet size=4096;user id=cuongps03142;pwd=chicuong@512;data source=ps03142.mssql.somee.com;persist security info=False;initial catalog=ps03142"
        Dim conn As SqlConnection = New SqlConnection(chuoiketnoi)
        Dim LoadKH As New SqlDataAdapter("select MAKH as 'Mã KH' ,TENKH as 'Tên Khách Hàng', DIACHI as 'Địa chỉ', SDT as 'SĐT', EMAIL from KHACHHANGPS03142", conn)
        Dim db As New DataSet
        conn.Open()
        LoadKH.Fill(db)
        conn.Close()
        Return db
    End Function
    Public Function Loadsanpham() As DataSet
        Dim chuoiketnoi As String = "workstation id=ps03142.mssql.somee.com;packet size=4096;user id=cuongps03142;pwd=chicuong@512;data source=ps03142.mssql.somee.com;persist security info=False;initial catalog=ps03142"
        Dim conn As SqlConnection = New SqlConnection(chuoiketnoi)
        Dim LoadSP As New SqlDataAdapter("select SANPHAMPS03142.MASP as 'Mã sản phẩm',SANPHAMPS03142.TENSP as 'Tên sản phẩm', LOAISANPHAMPS03142.MALOAI as 'Mã Loại', LOAISANPHAMPS03142.TENLOAI as 'Tên Loại',SANPHAMPS03142.SOLUONG as 'Số lượng' from SANPHAMPS03142 inner join LOAISANPHAMPS03142 on SANPHAMPS03142.MASP = LOAISANPHAMPS03142.MASP", conn)
        Dim db As New DataSet
        conn.Open()
        LoadSP.Fill(db)
        conn.Close()
        Return db
    End Function
End Class
