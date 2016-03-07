Option Explicit On
Option Strict On

Imports System.Collections.ObjectModel
Imports CapaControlador
Imports Orders

Public Class Pedidos

    Private Main As MainWindow
    Private cerrar As Boolean
    Private ListaLinesOrder As ObservableCollection(Of OrderLines)
    Private Productos As Productos
    Private PedidoDB As PedidosDB
    Private IdCliente As Integer
    Private Consultar As Boolean
    Private IdPedido As Integer
    Private Nick As String
    Private UriImagenMal As Uri
    Private UriImagenBien As Uri

    Public Sub New(Main As MainWindow, Consultar As Boolean, Nick As String,
                    IdPedido As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Me.Main = Main
        Main.Menu.IsEnabled = False
        Me.Consultar = Consultar
        cerrar = False
        Me.IdPedido = IdPedido
        Me.Nick = Nick
        Me.IdPedido = IdPedido

        UriImagenBien = New Uri("Resources/bien.png", UriKind.Relative)
        UriImagenMal = New Uri("Resources/mal.png", UriKind.Relative)

        tbCantidad.IsEnabled = False
        btCambiar.IsEnabled = False
        btBorrarLinea.IsEnabled = False

        Try
            If Consultar = False Then
                ObtenerCliente()
            End If

            CrearPedido()

            If Consultar Then
                ObtenerCliente()
            End If

        Catch ex As Exception
            ForzarCerrar()
            Throw New Exception(ex.Message)
        End Try

        ListaLinesOrder = PedidoDB.GetListaLinesOrdes
        Me.dataGridLinesOrders.DataContext = ListaLinesOrder

        Me.dgTotales.DataContext = PedidoDB.GetPedido()

        Productos = New Productos(Main, PedidoDB)
        Productos.Show()
        Productos.Visibility = Visibility.Hidden

    End Sub


    Public Sub CrearPedido()

        If (Consultar) Then
            PedidoDB = New PedidosDB(IdPedido)
            IdCliente = PedidoDB.GetPedido(0).CustomerId
        Else
            Dim Fecha As Date = My.Computer.Clock.LocalTime.Date
            PedidoDB = New PedidosDB(Fecha, IdCliente, 0, 0, 0)
        End If

        lbFecha.Content = PedidoDB.GetPedido(0).OrderDate
        lbNumFac.Content = PedidoDB.GetPedido(0).OrderId

    End Sub

    Public Sub ObtenerCliente()

        Dim AccionesBD As AccionesBDCliente = New AccionesBDCliente()

        Dim DatosCliente As Dictionary(Of String, String)

        If (Consultar) Then
            DatosCliente = AccionesBD.ObtenerCliente(IdCliente)
        Else
            DatosCliente = AccionesBD.ObtenerCliente(Nick)
        End If

        IdCliente = CInt(DatosCliente("ID"))
        lbNombre.Content = DatosCliente("NOMBRE")
        lbDir.Content = DatosCliente("DIR1")
        lbDir.Content = DatosCliente("DIR1")
        lbPais.Content = DatosCliente("PAIS")
        lbLocalidad.Content = DatosCliente("CIUDAD")

        IdCliente = CInt(DatosCliente("ID"))

    End Sub


    Private Sub AnyadirProducto(sender As Object, e As RoutedEventArgs)
        Productos.Visibility = Visibility.Visible
    End Sub


    Private Sub Window_Closing(sender As Object, e As ComponentModel.CancelEventArgs)

        If (cerrar = False) Then
            Dim result As MessageBoxResult = MessageBox.Show("¿Realmente quieres salir?", "¿Salir?", MessageBoxButton.YesNo, MessageBoxImage.Question)

            If result = MessageBoxResult.No Then
                e.Cancel = True
            Else
                If (Productos IsNot Nothing) Then Productos.ForzarCerrar()
                Main.Menu.IsEnabled = True
            End If
        Else
            If (Productos IsNot Nothing) Then Productos.ForzarCerrar()
            Main.Menu.IsEnabled = True
        End If

    End Sub

    Private Sub Cerrar_Ventana(sender As Object, e As RoutedEventArgs)
        Me.Close()
    End Sub

    Public Sub ForzarCerrar()
        cerrar = True
        Me.Close()
    End Sub

    Private Sub btBorrarPedido_Click(sender As Object, e As RoutedEventArgs)
        Dim Respuesta As MessageBoxResult = MessageBox.Show("¿Realmente quieres eliminar completamente este pedido?", "¿Borrar?",
                                                        MessageBoxButton.YesNo, MessageBoxImage.Question)
        If Respuesta = MessageBoxResult.Yes Then
            Try
                PedidoDB.BorrarPedido()
                MessageBox.Show("Pedido borrado.", "Info", MessageBoxButton.OK, MessageBoxImage.Information)
                ForzarCerrar()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error)
            End Try
        End If
    End Sub

    Private Sub btBorrarLinea_Click(sender As Object, e As RoutedEventArgs)

        Dim lineaPedido As OrderLines = CType(dataGridLinesOrders.SelectedItem, OrderLines)

        If lineaPedido IsNot Nothing Then

            Dim titulo As String = lineaPedido.Producto.Title

            Dim Respuesta As MessageBoxResult = MessageBox.Show("¿Realmente quieres borrar el artículo: " + titulo + "?", "¿Borrar?",
                                                            MessageBoxButton.YesNo, MessageBoxImage.Question)
            If Respuesta = MessageBoxResult.Yes Then
                Try
                    PedidoDB.BorrarLinea(lineaPedido)
                    If (dataGridLinesOrders.Items.Count = 1) Then
                        btBorrarLinea.IsEnabled = False
                    End If
                    MessageBox.Show("Línea de pedido borrada.", "Info", MessageBoxButton.OK, MessageBoxImage.Information)
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error)
                End Try
            End If
        End If
    End Sub


    Private Sub tbCantidad_TextChanged(sender As Object, e As TextChangedEventArgs)
        Dim validar As ValidarPedido = New ValidarPedido()
        imgCantidad.ToolTip = validar.ValidarCantidad(tbCantidad.Text)
        If (imgCantidad.ToolTip Is "Campo válido.") Then
            imgCantidad.Source = New BitmapImage(UriImagenBien)
            btCambiar.IsEnabled = True
        Else
            imgCantidad.Source = If(imgCantidad.ToolTip Is Nothing, Nothing, New BitmapImage(UriImagenMal))
            btCambiar.IsEnabled = False
        End If
    End Sub

    Private Sub dataGridLinesOrders_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        If (dataGridLinesOrders.Items.Count - 1 <> dataGridLinesOrders.SelectedIndex) Then
            tbCantidad.IsEnabled = True
            btBorrarLinea.IsEnabled = True
        Else
            tbCantidad.IsEnabled = False
            btBorrarLinea.IsEnabled = False
        End If

        tbCantidad.Text = ""
    End Sub

    Private Sub btCambiar_Click(sender As Object, e As RoutedEventArgs)

        Dim lineaPedido As OrderLines = CType(dataGridLinesOrders.SelectedItem, OrderLines)

        Dim titulo As String = lineaPedido.Producto.Title

        Dim Cantidad As Short = CShort(tbCantidad.Text)

        Try
            Dim Respuesta As MessageBoxResult = MessageBox.Show("¿Realmente quieres modificar la cantidad del artículo: " + titulo + "?", "¿Modificar?",
                                                        MessageBoxButton.YesNo, MessageBoxImage.Question)
            If Respuesta = MessageBoxResult.Yes Then
                PedidoDB.ModificarLinea(lineaPedido, Cantidad)

                MessageBox.Show("Cantidad modificada.", "Info", MessageBoxButton.OK, MessageBoxImage.Information)

                tbCantidad.Text = ""
            End If
        Catch ex As Exception
            Main.TextBarraEstado.Text = ex.Message
            MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error)
        End Try
    End Sub
End Class
