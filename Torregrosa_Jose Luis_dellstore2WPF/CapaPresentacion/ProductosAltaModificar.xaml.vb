Option Explicit On
Option Strict On

Imports CapaControlador

Public Class ProductosAltaModificar

    Private cerrar As Boolean
    Private UriImagenMal As Uri
    Private UriImagenBien As Uri
    Private Main As MainWindow
    Private ProductosDB As ProductosDB

    Public Sub New(Main As MainWindow)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        cerrar = False
        Me.Main = Main

        Dim Categorias As CategoriasDB = New CategoriasDB
        ProductosDB = New ProductosDB()

        Try
            comboBox.ItemsSource = Categorias.ObtenerCategorias.ToArray
        Catch ex As Exception
            Main.TextBarraEstado.Text = ex.Message
            MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error)
        End Try

        UriImagenBien = New Uri("Resources/bien.png", UriKind.Relative)
        UriImagenMal = New Uri("Resources/mal.png", UriKind.Relative)

        Main.Menu.IsEnabled = False

    End Sub


    Public Enum Campos
        TODOS = 0
        TITULO = 1
        PRECIO = 2
        ACTOR = 3
        ESPECIAL = 4
        CATEGORIA = 5
        ID_COMUN = 6
    End Enum


    Public Function ValidarCampos(campo As Integer) As Boolean

        Dim Validar As ValidarProductos = New ValidarProductos()

        Validar.Valido = True

        If campo = Campos.TITULO Or campo = Campos.TODOS Then
            imgTitulo.ToolTip = Validar.ValidarTitulo(tbTitulo.Text)
            imgTitulo.Source = If(imgTitulo.ToolTip Is "Campo válido.", New BitmapImage(UriImagenBien), New BitmapImage(UriImagenMal))
        End If
        If campo = Campos.PRECIO Or campo = Campos.TODOS Then
            imgPrecio.ToolTip = Validar.ValidarPrecio(tbPrecio.Text)
            imgPrecio.Source = If(imgPrecio.ToolTip Is "Campo válido.", New BitmapImage(UriImagenBien), New BitmapImage(UriImagenMal))
        End If
        If campo = Campos.ACTOR Or campo = Campos.TODOS Then
            imgActor.ToolTip = Validar.ValidarActor(tbActor.Text)
            imgActor.Source = If(imgActor.ToolTip Is "Campo válido.", New BitmapImage(UriImagenBien), New BitmapImage(UriImagenMal))
        End If
        If campo = Campos.ESPECIAL Or campo = Campos.TODOS Then
            imgEspecial.ToolTip = Validar.ValidarEspecial(tbEspecial.Text)
            imgEspecial.Source = If(imgEspecial.ToolTip Is "Campo válido.", New BitmapImage(UriImagenBien), New BitmapImage(UriImagenMal))
        End If
        If campo = Campos.CATEGORIA Or campo = Campos.TODOS Then
            imgCategoria.ToolTip = Validar.ValidarCategoria(comboBox.SelectedIndex)
            imgCategoria.Source = If(imgCategoria.ToolTip Is "Campo válido.", New BitmapImage(UriImagenBien), New BitmapImage(UriImagenMal))
        End If
        If campo = Campos.ID_COMUN Or campo = Campos.TODOS Then
            imgId.ToolTip = Validar.ValidarIdComun(tbIdComun.Text)
            imgId.Source = If(imgId.ToolTip Is "Campo válido.", New BitmapImage(UriImagenBien), New BitmapImage(UriImagenMal))
        End If
        Return Validar.Valido

    End Function

    Public Sub ForzarCerrar()
        cerrar = True
        Me.Close()
    End Sub

    Private Sub tbTitulo_LostFocus(sender As Object, e As RoutedEventArgs)
        ValidarCampos(Campos.TITULO)
    End Sub

    Private Sub tbPrecio_LostFocus(sender As Object, e As RoutedEventArgs)
        ValidarCampos(Campos.PRECIO)
    End Sub

    Private Sub tbEspecial_LostFocus(sender As Object, e As RoutedEventArgs)
        ValidarCampos(Campos.ESPECIAL)
    End Sub

    Private Sub tbActor_LostFocus(sender As Object, e As RoutedEventArgs)
        ValidarCampos(Campos.ACTOR)
    End Sub

    Private Sub tbIdComun_LostFocus(sender As Object, e As RoutedEventArgs)
        ValidarCampos(Campos.ID_COMUN)
    End Sub

    Private Sub comboBox_LostFocus(sender As Object, e As RoutedEventArgs)
        ValidarCampos(Campos.CATEGORIA)
    End Sub

    Private Sub btCancelar_Click(sender As Object, e As RoutedEventArgs)
        Me.Close()
    End Sub

    Private Sub btAceptar_Click(sender As Object, e As RoutedEventArgs)
        If (ValidarCampos(Campos.TODOS)) Then
            InsertarProducto()
        End If
    End Sub

    Public Sub ReiniciarCampos()
        tbTitulo.Text = Nothing
        tbPrecio.Text = Nothing
        tbActor.Text = Nothing
        tbEspecial.Text = Nothing
        comboBox.Text = ""
        tbIdComun.Text = Nothing
        imgActor.Source = Nothing
        imgCategoria.Source = Nothing
        imgEspecial.Source = Nothing
        imgId.Source = Nothing
        imgPrecio.Source = Nothing
        imgTitulo.Source = Nothing

    End Sub

    Private Sub InsertarProducto()

        Dim titulo As String = tbTitulo.Text()
        Dim precio As Double = CDbl(tbPrecio.Text)
        Dim actor As String = tbActor.Text()
        Dim especial As Short = If(tbEspecial.Text <> "", CShort(tbEspecial.Text), Nothing)
        Dim categoria As Integer = comboBox.SelectedIndex + 1
        Dim idComun As Integer = CInt(tbIdComun.Text)

        Try

            ProductosDB.InsertarProducto(categoria, titulo, actor, idComun, especial, precio)

            Main.TextBarraEstado.Text = "El producto ha sido insertado correctamente."
            Dim Respuesta As MessageBoxResult = MessageBox.Show("El producto ha sido insertado correctamente." + vbCrLf + "¿Quieres seguir insertando?", "Insertado", MessageBoxButton.YesNo, MessageBoxImage.Question)

            If Respuesta = MessageBoxResult.Yes Then
                ReiniciarCampos()
            Else
                ForzarCerrar()
            End If

        Catch ex As Exception
            Main.TextBarraEstado.Text = "Error al insertar."
            MessageBox.Show(ex.Message, "Error al insertar", MessageBoxButton.OK, MessageBoxImage.Error)
        End Try
    End Sub

    Private Sub Window_Closing(sender As Object, e As ComponentModel.CancelEventArgs)

        If (cerrar = False) Then
            Dim result As MessageBoxResult = MessageBox.Show("¿Realmente quieres salir?", "¿Salir?", MessageBoxButton.YesNo, MessageBoxImage.Question)

            If result = MessageBoxResult.No Then
                e.Cancel = True
            Else
                Main.Menu.IsEnabled = True
            End If
        Else
            Main.Menu.IsEnabled = True
        End If
    End Sub

End Class
