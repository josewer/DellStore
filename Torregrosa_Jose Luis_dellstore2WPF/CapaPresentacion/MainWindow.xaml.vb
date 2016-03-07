Imports System ' EventArgs
Imports System.ComponentModel ' CancelEventArgs
Imports System.Windows ' window

Class MainWindow

    Private Clientes As Clientes
    Private Pedidos As Pedidos
    Private ProductosAlta As ProductosAltaModificar
    Private ProductosModificar As ProductosModificar

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub AbrirCliente(sender As Object, e As RoutedEventArgs)
        Clientes = New Clientes(Me, Nothing)
    End Sub


    Private Sub Form1_FormClosing(sender As Object, e As CancelEventArgs)

        Dim result As MessageBoxResult = MessageBox.Show("¿Realmente quieres salir? Se cerrarán todas las ventanas.", "¿Salir?", MessageBoxButton.YesNo, MessageBoxImage.Question)

        If result = MessageBoxResult.No Then
            e.Cancel = True
        Else
            If (Clientes IsNot Nothing) Then Clientes.ForzarCerrar()
            If (Pedidos IsNot Nothing) Then Pedidos.ForzarCerrar()
            If (ProductosAlta IsNot Nothing) Then ProductosAlta.ForzarCerrar()
            If (ProductosModificar IsNot Nothing) Then ProductosModificar.ForzarCerrar()
        End If

    End Sub

    Private Sub ModificarCliente(sender As Object, e As RoutedEventArgs)

        Dim Nick As String = InputBox("Introduce el nick del cliente que quieres modificar.", "Modificar")

        If Nick <> "" Then
            Try
                Clientes = New Clientes(Me, Nick)
            Catch ex As Exception
                TextBarraEstado.Text = ex.Message
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error)
            End Try
        End If

    End Sub

    Private Sub AltaPedido(sender As Object, e As RoutedEventArgs)

        Menu.IsEnabled = False

        Dim Nick As String = InputBox("Introduce el nick del cliente al que va ir dirigida la factura.", "Modificar")

        If Nick = "" Then
            Menu.IsEnabled = True
        Else
            Try
                Pedidos = New Pedidos(Me, False, Nick, Nothing)
                Pedidos.Show()
            Catch ex As Exception
                TextBarraEstado.Text = ex.Message
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error)

            End Try
        End If
    End Sub

    Private Sub ModificarPedido(sender As Object, e As RoutedEventArgs)

        Menu.IsEnabled = False

        Dim IdPedido As String = InputBox("Introduce el número de pedido que quieres consultar.", "Consultar")

        If IdPedido = "" Then
            Menu.IsEnabled = True
        ElseIf IsNumeric(IdPedido) Then
            Try
                Pedidos = New Pedidos(Me, True, "", CInt(IdPedido))
                Pedidos.Show()
            Catch ex As Exception
                TextBarraEstado.Text = ex.Message
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error)
                Menu.IsEnabled = True
            End Try
        Else
            MessageBox.Show("Número de pedido no valido", "Error", MessageBoxButton.OK, MessageBoxImage.Error)
            Menu.IsEnabled = True
        End If
    End Sub

    Private Sub AltaProducto(sender As Object, e As RoutedEventArgs)
        ProductosAlta = New ProductosAltaModificar(Me)
        ProductosAlta.Show()
    End Sub

    Private Sub ModificarProducto(sender As Object, e As RoutedEventArgs)
        ProductosModificar = New ProductosModificar(Me)
        ProductosModificar.Show()
    End Sub

    Private Sub Sin_implementar(sender As Object, e As RoutedEventArgs)
        MessageBox.Show("Esta funcionalidad esta sin implementar.", "Información", MessageBoxButton.OK, MessageBoxImage.Information)
    End Sub

End Class
