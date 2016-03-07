Option Explicit On
Option Strict On

Imports Npgsql


Public Class ProductsADO
    Private _BD As BdPostgre

    Public Sub New()
        _BD = New BdPostgre
    End Sub


    Public Function Insertar(ByVal sql As String) As Integer

        Dim Lector As NpgsqlDataReader
        Dim ProductId As Integer = 0

        _BD.Abrir()

        Try
            Lector = _BD.EjecutarDML(sql)

            While Lector.Read()
                ProductId = Lector.GetInt32(0)
            End While

        Catch ex As Exception
            ProductId = 0
        Finally
            _BD.Cerrar()
        End Try

        Return ProductId
    End Function


    Public Function Borrar(ByVal sql As String) As Boolean

        Dim Lector As NpgsqlDataReader
        Dim Borrado As Boolean = True

        _BD.Abrir()

        Try
            Lector = _BD.EjecutarDML(sql)
        Catch ex As Exception
            Borrado = False
        Finally
            _BD.Cerrar()
        End Try

        Return Borrado
    End Function


    Public Function Actualizar(ByVal sql As String) As Boolean

        Dim Lector As NpgsqlDataReader
        Dim Actualizado As Boolean = True

        _BD.Abrir()

        Try
            Lector = _BD.EjecutarDML(sql)
        Catch ex As Exception
            Actualizado = False
        Finally
            _BD.Cerrar()
        End Try

        Return Actualizado
    End Function


    Public Function Obtener(categoria As Int32) As List(Of Products)

        Dim Lector As NpgsqlDataReader
        Dim Productos As New List(Of Products)

        _BD.Abrir()
        Dim Existe As Boolean = False

        Dim SQL As String = String.Format("SELECT Prod_Id ,category, title, actor, common_Prod_Id, special, price
            FROM PRODUCTS WHERE category = '{0}';",
                                          categoria)

        Try
            Lector = _BD.EjecutarDML(SQL)

            While Lector.Read()

                Existe = True

                Productos.Add(New Products(Lector.GetInt32(0),
                            Lector.GetInt32(1), Lector.GetString(2),
                            Lector.GetString(3), Lector.GetInt32(4),
                            CShort(Lector.GetString(5)), Lector.GetInt32(6)))

            End While

        Catch ex As Exception
            Throw New Exception("No hay ningún producto para esta categoría.")
        Finally
            _BD.Cerrar()
        End Try

        If Existe Then
            Return Productos
        Else
            Return Nothing
        End If
    End Function


    Public Function ObtenerPorTitulo(titulo As String) As List(Of Products)

        Dim Lector As NpgsqlDataReader
        Dim Productos As New List(Of Products)

        _BD.Abrir()
        Dim Existe As Boolean = False

        Dim SQL As String = String.Format("SELECT Prod_Id ,category, title, actor, common_Prod_Id, special, price
            FROM PRODUCTS WHERE LOWER(title) Like '%{0}%';",
                                          titulo.ToLower)

        Try
            Lector = _BD.EjecutarDML(SQL)

            While Lector.Read()

                Productos.Add(New Products(Lector.GetInt32(0),
                            Lector.GetInt32(1), Lector.GetString(2),
                            Lector.GetString(3), Lector.GetInt32(4),
                            CShort(Lector.GetString(5)), Lector.GetInt32(6)))

            End While

        Catch ex As Exception
            Return Productos
        Finally
            _BD.Cerrar()
        End Try

        Return Productos

    End Function


    Public Function Obtener(SQL As String) As Products

        Dim Lector As NpgsqlDataReader
        Dim Product As Products = Nothing

        _BD.Abrir()

        Try
            Lector = _BD.EjecutarDML(SQL)

            While Lector.Read()

                Product = New Products(Lector.GetInt32(0),
                            Lector.GetInt32(1), Lector.GetString(2),
                            Lector.GetString(3), Lector.GetInt32(4),
                            CShort(Lector.GetString(5)), Lector.GetDouble(6))
            End While

        Catch ex As Exception
            Throw New Exception("Error al obtener el producto, para añadirlo a la línea de pedido.")
        Finally
            _BD.Cerrar()
        End Try

        Return Product

    End Function


    Public Sub Dispose()
        If (Not _BD Is Nothing) Then
            _BD.dispose()
        End If
    End Sub
End Class
