Option Explicit On
Option Strict On
Imports System.Collections.ObjectModel
Imports CapaControlador
Imports Orders

Public Class ProductosModificar

    Private cerrar As Boolean
    Private UriImagenMal As Uri
    Private UriImagenBien As Uri
    Private Main As MainWindow
    Private ProductosDB As ProductosDB
    Private Productos As ProductosDB
    Private ListaObProductos As ObservableCollection(Of Products)

    Public Sub New(Main As MainWindow)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        cerrar = False
        Me.Main = Main

        Dim Categorias As CategoriasDB = New CategoriasDB
        ProductosDB = New ProductosDB()

        Try
            comboBox.ItemsSource = Categorias.ObtenerCategorias.ToArray
            cbCategorias.ItemsSource = Categorias.ObtenerCategorias.ToArray
        Catch ex As Exception
            Main.TextBarraEstado.Text = ex.Message
            MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error)
        End Try

        UriImagenBien = New Uri("Resources/bien.png", UriKind.Relative)
        UriImagenMal = New Uri("Resources/mal.png", UriKind.Relative)

        Productos = New ProductosDB
        ListaObProductos = New ObservableCollection(Of Products)

        lvProductos.DataContext = ListaObProductos


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


    Private Sub tbTituloBuscar_TextChanged(sender As Object, e As TextChangedEventArgs)
        Try
            If (tbBuscarTitulo.Text.Trim.Length <> 0) Then
                Productos.ObtenerProductos(tbBuscarTitulo.Text, ListaObProductos)
                cbCategorias.SelectedValue = ""
            End If
        Catch ex As Exception
            Main.TextBarraEstado.Text = ex.Message
            MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error)
        End Try
    End Sub


    Private Sub lvProductos_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        gridProductos.DataContext = CType(lvProductos.SelectedItem, Products)
        If (CType(lvProductos.SelectedItem, Products) IsNot Nothing) Then
            comboBox.SelectedIndex = CType(lvProductos.SelectedItem, Products).Category - 1
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

    Private Sub cbCategorias_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        Try
            If cbCategorias.SelectedIndex <> -1 Then
                Productos.ObtenerProductos(cbCategorias.SelectedIndex + 1, ListaObProductos)
                tbBuscarTitulo.Text = ""
            End If
        Catch ex As Exception
            Main.TextBarraEstado.Text = ex.Message
            MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error)
        End Try
    End Sub

    Private Sub Cerrar_Ventana(sender As Object, e As RoutedEventArgs)
        Me.Close()
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

    Private Sub btModificar_Click(sender As Object, e As RoutedEventArgs)
        If (ValidarCampos(Campos.TODOS)) Then

            If lvProductos.SelectedIndex <> -1 Then
                Actualizar()
            Else
                MessageBox.Show("Tienes que seleccionar que producto quieres modificar.", "Error al actualizar", MessageBoxButton.OK, MessageBoxImage.Error)
            End If
        Else
            MessageBox.Show("Corrige los campos no válidos.", "Error al actualizar", MessageBoxButton.OK, MessageBoxImage.Error)
        End If
    End Sub

    Public Sub Actualizar()
        Dim id As Integer = CType(lvProductos.SelectedItem, Products).Prod_Id
        Dim titulo As String = tbTitulo.Text()
        Dim precio As Double = CDbl(tbPrecio.Text)
        Dim actor As String = tbActor.Text()
        Dim especial As Short = If(tbEspecial.Text <> "", CShort(tbEspecial.Text), Nothing)
        Dim categoria As Integer = comboBox.SelectedIndex + 1
        Dim idComun As Integer = CInt(tbIdComun.Text)

        Try
            ProductosDB.ActualizarProducto(id, categoria, titulo, actor, idComun, especial, precio)

            Main.TextBarraEstado.Text = "El producto ha sido actualizado correctamente."
            Dim Respuesta As MessageBoxResult = MessageBox.Show("El producto ha sido actualizado correctamente." + vbCrLf + "¿Quieres seguir actualizado?", "actualizado", MessageBoxButton.YesNo, MessageBoxImage.Question)

            If Respuesta = MessageBoxResult.Yes Then
                ReiniciarCampos()
            Else
                ForzarCerrar()
            End If
        Catch ex As Exception
            Main.TextBarraEstado.Text = "Error al actualizado."
            MessageBox.Show(ex.Message, "Error al actualizado", MessageBoxButton.OK, MessageBoxImage.Error)
        End Try
    End Sub

End Class
