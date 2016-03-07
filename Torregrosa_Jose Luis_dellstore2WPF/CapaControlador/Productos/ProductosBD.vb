Option Explicit On
Option Strict On
Imports System.Collections.ObjectModel
Imports Orders
Public Class ProductosDB

    Private ListaProductos As List(Of Products)

    Public Sub New()
        ListaProductos = New List(Of Products)
    End Sub

    Public Sub ActualizarProducto(id As Integer, category As Integer, title As String,
               actor As String, common_Prod_Id As Integer, special As Short,
               price As Double)
        Dim producto As Products = New Products(id, category, title, actor, common_Prod_Id, special, price)
        Try
            producto.Actualizar()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Sub InsertarProducto(category As Integer, title As String,
               actor As String, common_Prod_Id As Integer, special As Short,
               price As Double)
        Try
            Dim producto As Products = New Products(category, title, actor, common_Prod_Id, special, price)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Sub

    Public Sub ObtenerProductos(categoria As Int32,
                                     ByRef listaObProductos As ObservableCollection(Of Products))

        Dim Productos As ProductsADO = New ProductsADO
        ListaProductos = Productos.Obtener(categoria)
        ModificarListaOb(listaObProductos)

    End Sub

    Public Sub ObtenerProductos(titulo As String,
                                      ByRef listaObProductos As ObservableCollection(Of Products))

        Dim Productos As ProductsADO = New ProductsADO
        ListaProductos = Productos.ObtenerPorTitulo(titulo)
        ModificarListaOb(listaObProductos)

    End Sub

    Private Sub ModificarListaOb(ByRef listaObProductos As ObservableCollection(Of Products))

        listaObProductos.Clear()

        For i As Integer = 0 To ListaProductos.Count - 1 Step 1

            listaObProductos.Add(New Products(ListaProductos(i).Prod_Id, ListaProductos(i).Category,
                     ListaProductos(i).Title, ListaProductos(i).Actor,
                     ListaProductos(i).Common_Prod_Id, ListaProductos(i).Special,
                     ListaProductos(i).Price))
        Next
    End Sub

    Public Function GetProductos() As List(Of Products)

        Return ListaProductos

    End Function

End Class
