Option Explicit On
Option Strict On

Imports System.Collections.ObjectModel
Imports CapaControlador
Imports Orders

Public Class Productos

    Private Main As MainWindow
    Private Productos As ProductosDB
    Private ListaObProductos As ObservableCollection(Of Products)
    Private cerrar As Boolean
    Private PedidoDB As PedidosDB
    Private ListaLinesOrder As ObservableCollection(Of OrderLines)
    Private UriImagenMal As Uri
    Private UriImagenBien As Uri

    Public Sub New(Main As MainWindow, PedidoDB As PedidosDB)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        Me.Main = Main
        Me.PedidoDB = PedidoDB
        cerrar = False

        Dim Categorias As CategoriasDB = New CategoriasDB

        Try
            cbCategorias.ItemsSource = Categorias.ObtenerCategorias.ToArray
        Catch ex As Exception
            Main.TextBarraEstado.Text = ex.Message
            MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error)
        End Try

        Productos = New ProductosDB

        btAdd.IsEnabled = False
        tbCantidad.IsEnabled = False

        UriImagenBien = New Uri("Resources/bien.png", UriKind.Relative)
        UriImagenMal = New Uri("Resources/mal.png", UriKind.Relative)

        ListaObProductos = New ObservableCollection(Of Products)
        Me.DataContext = ListaObProductos

    End Sub

    Public Sub ForzarCerrar()
        cerrar = True
        Me.Close()
    End Sub


    Private Sub cbCategorias_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        Try
            If cbCategorias.SelectedIndex <> -1 Then
                Productos.ObtenerProductos(cbCategorias.SelectedIndex + 1, ListaObProductos)
                tbTitulo.Text = ""
            End If
        Catch ex As Exception
            Main.TextBarraEstado.Text = ex.Message
            MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error)
        End Try
    End Sub


    Private Sub btAdd_Click(sender As Object, e As RoutedEventArgs)
        Dim productoChecked = CType(lvProductos.SelectedItem, Products)
        Dim cantidad As Short = CShort(tbCantidad.Text)

        Try
            PedidoDB.AddOrderLine(productoChecked.Prod_Id, cantidad)

            MessageBox.Show("Producto añadido.", "Info", MessageBoxButton.OK, MessageBoxImage.Information)
            tbCantidad.Text = ""
            image.Source = Nothing
        Catch ex As Exception
            Main.TextBarraEstado.Text = ex.Message
            MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error)
        End Try
    End Sub


    Private Sub lvProductos_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        tbCantidad.IsEnabled = True
    End Sub


    Private Sub tbCantidad_TextChanged(sender As Object, e As TextChangedEventArgs)

        Dim validarProducto As ValidarProductos = New ValidarProductos

        image.ToolTip = validarProducto.ValidarCantidad(tbCantidad.Text)
        If (image.ToolTip Is "Campo válido.") Then
            image.Source = New BitmapImage(UriImagenBien)
            btAdd.IsEnabled = True
        Else
            image.Source = New BitmapImage(UriImagenMal)
            btAdd.IsEnabled = False
        End If
    End Sub


    Private Sub tbTitulo_TextChanged(sender As Object, e As TextChangedEventArgs)
        Try
            If (tbTitulo.Text.Trim.Length <> 0) Then
                Productos.ObtenerProductos(tbTitulo.Text, ListaObProductos)
                cbCategorias.SelectedValue = ""
            End If
        Catch ex As Exception
            Main.TextBarraEstado.Text = ex.Message
            MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error)
        End Try
    End Sub

    Private Sub btCerrar_Click(sender As Object, e As RoutedEventArgs)
        Me.Close()
    End Sub

    Private Sub Window_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        If (cerrar = False) Then
            Me.Visibility = Visibility.Hidden
            e.Cancel = True
        End If
    End Sub

End Class
