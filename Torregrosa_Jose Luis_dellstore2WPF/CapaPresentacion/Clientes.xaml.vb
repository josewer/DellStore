Option Strict On

Imports CapaControlador

Public Class Clientes

    Private UriImagenMal As Uri
    Private UriImagenBien As Uri
    Private IdCliente As Integer
    Private AccionesBD As AccionesBDCliente
    Private Main As MainWindow
    Private cerrar As Boolean

    Public Sub New(Main As MainWindow, Nick As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Me.Show()

        Me.Main = Main
        UriImagenBien = New Uri("Resources/bien.png", UriKind.Relative)
        UriImagenMal = New Uri("Resources/mal.png", UriKind.Relative)
        cerrar = False
        IdCliente = Nothing

        AccionesBD = New AccionesBDCliente()

        cbPais.Items.Add("España")
        cbProvincia.ItemsSource = AccionesBD.ObtenerProvincias
        cbTipoTarjetas.ItemsSource = {"Visa", "Mastercard", "PayPal"}

        calendario.DisplayDateStart = My.Computer.Clock.LocalTime

        If (Not Nick Is Nothing) Then
            Try
                ObtenerCLiente(Nick)
                btAceptar.Content = "Modificar"
            Catch ex As Exception
                ForzarCerrar()
                Throw New Exception(ex.Message)
            End Try
        End If

        Main.Menu.IsEnabled = False

    End Sub


    Public Enum Campos
        TODOS = 0
        NICK = 1
        CONTRA = 2
        NOMBRE = 3
        APELLIDOS = 4
        DIR1 = 5
        DIR2 = 6
        CP = 7
        CORREO = 8
        NUMERO_DE_TARJETA = 9
        PAIS = 10
        PROVINCIA = 11
        CIUDAD = 12
        TELEFONO = 13
        GENERO = 14
        EDAD = 15
        TIPO_TARJETA = 16
        SUELDO = 17
        REGION = 18
        FECHA_CADUCIDA = 19
    End Enum


    Public Function ValidarCampos(campo As Integer) As Boolean

        Dim Validar As ValidarCliente = New ValidarCliente()

        Validar.Valido = True

        If campo = Campos.NICK Or campo = Campos.TODOS Then
            imageNick.ToolTip = Validar.ValidarNick(tbNick.Text)
            imageNick.Source = If(imageNick.ToolTip Is "Campo válido.", New BitmapImage(UriImagenBien), New BitmapImage(UriImagenMal))
        End If
        If campo = Campos.CONTRA Or campo = Campos.TODOS Then
            imageContra.ToolTip = Validar.ValidarContra(tbContra.Text)
            imageContra.Source = If(imageContra.ToolTip Is "Campo válido.", New BitmapImage(UriImagenBien), New BitmapImage(UriImagenMal))
        End If
        If campo = Campos.NOMBRE Or campo = Campos.TODOS Then
            imageNombre.ToolTip = Validar.ValidarNombre(tbNombre.Text)
            imageNombre.Source = If(imageNombre.ToolTip Is "Campo válido.", New BitmapImage(UriImagenBien), New BitmapImage(UriImagenMal))
        End If
        If campo = Campos.APELLIDOS Or campo = Campos.TODOS Then
            imageApellidos.ToolTip = Validar.ValidarApellidos(tbApellidos.Text)
            imageApellidos.Source = If(imageApellidos.ToolTip Is "Campo válido.", New BitmapImage(UriImagenBien), New BitmapImage(UriImagenMal))
        End If
        If campo = Campos.DIR1 Or campo = Campos.TODOS Then
            imageDir1.ToolTip = Validar.ValidarDir1(tbDir1.Text)
            imageDir1.Source = If(imageDir1.ToolTip Is "Campo válido.", New BitmapImage(UriImagenBien), New BitmapImage(UriImagenMal))
        End If
        If campo = Campos.DIR2 Or campo = Campos.TODOS Then
            imageDir2.ToolTip = Validar.ValidarDir2(tbDir2.Text)
            imageDir2.Source = If(imageDir2.ToolTip Is "Campo válido.", New BitmapImage(UriImagenBien), New BitmapImage(UriImagenMal))
        End If
        If campo = Campos.NUMERO_DE_TARJETA Or campo = Campos.TODOS Then
            imageNumeroTarjeta.ToolTip = Validar.ValidarNumeroTarjeta(tbNumeroTarjeta.Text)
            imageNumeroTarjeta.Source = If(imageNumeroTarjeta.ToolTip Is "Campo válido.", New BitmapImage(UriImagenBien), New BitmapImage(UriImagenMal))
        End If
        If campo = Campos.CP Or campo = Campos.TODOS Then
            imageCP.ToolTip = Validar.ValidarCP(tbCP.Text)
            imageCP.Source = If(imageCP.ToolTip Is "Campo válido.", New BitmapImage(UriImagenBien), New BitmapImage(UriImagenMal))
        End If
        If campo = Campos.CORREO Or campo = Campos.TODOS Then
            imageCorreo.ToolTip = Validar.ValidarCorreo(tbCorreo.Text)
            imageCorreo.Source = If(imageCorreo.ToolTip Is "Campo válido.", New BitmapImage(UriImagenBien), New BitmapImage(UriImagenMal))
        End If
        If campo = Campos.TELEFONO Or campo = Campos.TODOS Then
            imageTelefono.ToolTip = Validar.ValidarTelefono(tbTelefono.Text)
            imageTelefono.Source = If(imageTelefono.ToolTip Is "Campo válido.", New BitmapImage(UriImagenBien), New BitmapImage(UriImagenMal))
        End If
        If campo = Campos.PAIS Or campo = Campos.TODOS Then
            imagePais.ToolTip = Validar.ValidarPais(cbPais.SelectedIndex)
            imagePais.Source = If(imagePais.ToolTip Is "Campo válido.", New BitmapImage(UriImagenBien), New BitmapImage(UriImagenMal))
        End If
        If campo = Campos.PROVINCIA Or campo = Campos.TODOS Then
            imageProvincia.ToolTip = Validar.ValidarProvincia(cbProvincia.SelectedIndex)
            imageProvincia.Source = If(imageProvincia.ToolTip Is "Campo válido.", New BitmapImage(UriImagenBien), New BitmapImage(UriImagenMal))
        End If
        If campo = Campos.CIUDAD Or campo = Campos.TODOS Then
            imageCiudad.ToolTip = Validar.ValidarCiudad(cbCiudad.SelectedIndex)
            imageCiudad.Source = If(imageCiudad.ToolTip Is "Campo válido.", New BitmapImage(UriImagenBien), New BitmapImage(UriImagenMal))
        End If
        If campo = Campos.GENERO Or campo = Campos.TODOS Then
            imageGenero.ToolTip = Validar.ValidarGenero(CBool(rbMujer.IsChecked), CBool(rbHombre.IsChecked))
            imageGenero.Source = If(imageGenero.ToolTip Is "Campo válido.", New BitmapImage(UriImagenBien), New BitmapImage(UriImagenMal))
        End If
        If campo = Campos.EDAD Or campo = Campos.TODOS Then
            imageEdad.ToolTip = Validar.ValidarEdad(tbEdad.Text)
            imageEdad.Source = If(imageEdad.ToolTip Is "Campo válido.", New BitmapImage(UriImagenBien), New BitmapImage(UriImagenMal))
        End If
        If campo = Campos.TIPO_TARJETA Or campo = Campos.TODOS Then
            imageTipoTarjeta.ToolTip = Validar.ValidarTipoTarjetas(cbTipoTarjetas.SelectedIndex)
            imageTipoTarjeta.Source = If(imageTipoTarjeta.ToolTip Is "Campo válido.", New BitmapImage(UriImagenBien), New BitmapImage(UriImagenMal))
        End If
        If campo = Campos.SUELDO Or campo = Campos.TODOS Then
            imageSueldo.ToolTip = Validar.ValidarSueldo(tbSueldo.Text)
            imageSueldo.Source = If(imageSueldo.ToolTip Is "Campo válido.", New BitmapImage(UriImagenBien), New BitmapImage(UriImagenMal))
        End If
        If campo = Campos.REGION Or campo = Campos.TODOS Then
            imageRegion.ToolTip = Validar.ValidarRegion(tbRegion.Text)
            imageRegion.Source = If(imageRegion.ToolTip Is "Campo válido.", New BitmapImage(UriImagenBien), New BitmapImage(UriImagenMal))
        End If
        If campo = Campos.FECHA_CADUCIDA Or campo = Campos.TODOS Then
            imageCalendario.ToolTip = Validar.ValidarCalendario(calendario.Text)
            imageCalendario.Source = If(imageCalendario.ToolTip Is "Campo válido.", New BitmapImage(UriImagenBien), New BitmapImage(UriImagenMal))
        End If

        Return Validar.Valido
    End Function

    Public Sub ReiniciarCampos()
        tbNombre.Text = ""
        tbApellidos.Text = ""
        tbDir1.Text = ""
        tbDir2.Text = ""
        cbCiudad.Text = ""
        cbProvincia.Text = ""
        tbCP.Text = ""
        cbPais.Text = ""
        tbRegion.Text = ""
        tbCorreo.Text = ""
        tbTelefono.Text = ""
        cbTipoTarjetas.Text = ""
        tbNumeroTarjeta.Text = ""
        calendario.SelectedDate = Nothing
        tbNick.Text = ""
        tbContra.Text = ""
        tbEdad.Text = ""
        tbSueldo.Text = ""
        rbHombre.IsChecked = False
        rbMujer.IsChecked = False
        imageApellidos.Source = Nothing
        imageCiudad.Source = Nothing
        imageContra.Source = Nothing
        imageCorreo.Source = Nothing
        imageDir1.Source = Nothing
        imageDir2.Source = Nothing
        imageEdad.Source = Nothing
        imageGenero.Source = Nothing
        imageNick.Source = Nothing
        imageNombre.Source = Nothing
        imageNumeroTarjeta.Source = Nothing
        imagePais.Source = Nothing
        imageProvincia.Source = Nothing
        imageRegion.Source = Nothing
        imageSueldo.Source = Nothing
        imageTelefono.Source = Nothing
        imageTipoTarjeta.Source = Nothing
        imageCP.Source = Nothing
        imageCalendario.Source = Nothing
    End Sub

    Private Sub tbContra_LostFocus(sender As Object, e As RoutedEventArgs)
        ValidarCampos(Campos.CONTRA)
    End Sub

    Private Sub tbNick_LostFocus(sender As Object, e As RoutedEventArgs)
        ValidarCampos(Campos.NICK)
    End Sub

    Private Sub tbEdad_LostFocus(sender As Object, e As RoutedEventArgs)
        ValidarCampos(Campos.EDAD)
    End Sub

    Private Sub tbTelefono_LostFocus(sender As Object, e As RoutedEventArgs)
        ValidarCampos(Campos.TELEFONO)
    End Sub

    Private Sub tbDir1_LostFocus(sender As Object, e As RoutedEventArgs)
        ValidarCampos(Campos.DIR1)
    End Sub

    Private Sub tbApellidos_LostFocus(sender As Object, e As RoutedEventArgs)
        ValidarCampos(Campos.APELLIDOS)
    End Sub

    Private Sub tbNombre_LostFocus(sender As Object, e As RoutedEventArgs)
        ValidarCampos(Campos.NOMBRE)
    End Sub

    Private Sub tbDir2_LostFocus(sender As Object, e As RoutedEventArgs)
        ValidarCampos(Campos.DIR2)
    End Sub

    Private Sub tbCP_LostFocus(sender As Object, e As RoutedEventArgs)
        ValidarCampos(Campos.CP)
    End Sub

    Private Sub tbCorreo_LostFocus(sender As Object, e As RoutedEventArgs)
        ValidarCampos(Campos.CORREO)
    End Sub

    Private Sub tbRegion_LostFocus(sender As Object, e As RoutedEventArgs)
        ValidarCampos(Campos.REGION)
    End Sub

    Private Sub tbNumeroTarjeta_LostFocus(sender As Object, e As RoutedEventArgs)
        ValidarCampos(Campos.NUMERO_DE_TARJETA)
    End Sub

    Private Sub tbSueldo_LostFocus(sender As Object, e As RoutedEventArgs)
        ValidarCampos(Campos.SUELDO)
    End Sub

    Private Sub cbTipoTarjetas_LostFocus(sender As Object, e As RoutedEventArgs)
        ValidarCampos(Campos.TIPO_TARJETA)
    End Sub

    Private Sub cbPais_LostFocus(sender As Object, e As RoutedEventArgs)
        ValidarCampos(Campos.PAIS)
    End Sub

    Private Sub cbProvincia_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        ValidarCampos(Campos.PROVINCIA)
        If (cbProvincia.SelectedIndex <> -1) Then _
            cbCiudad.ItemsSource = AccionesBD.ObtenerPoblaciones(cbProvincia.SelectedIndex)
    End Sub
    Private Sub cbCiudad_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        ValidarCampos(Campos.CIUDAD)
    End Sub

    Private Sub rbHombre_LostFocus(sender As Object, e As RoutedEventArgs)
        ValidarCampos(Campos.GENERO)
    End Sub

    Private Sub rbMujer_LostFocus(sender As Object, e As RoutedEventArgs)
        ValidarCampos(Campos.GENERO)
    End Sub

    Private Sub calendario_LostFocus(sender As Object, e As RoutedEventArgs)
        ValidarCampos(Campos.FECHA_CADUCIDA)
    End Sub

    Private Sub btCancelar_Click(sender As Object, e As RoutedEventArgs)
        Me.Close()
    End Sub

    Private Sub btAceptar_Click(sender As Object, e As RoutedEventArgs)

        If (ValidarCampos(Campos.TODOS)) Then

            If (btAceptar.Content Is "Modificar") Then
                ModificarCliente()
            Else
                InsertarCliente()
            End If

        Else
            Main.TextBarraEstado.Text = "Campos no válidos."
            MessageBox.Show("Corrige los campos no válidos.", "Campos no válidos", MessageBoxButton.OK, MessageBoxImage.Error)
        End If
    End Sub

    Private Sub InsertarCliente()

        Dim Nombre As String = tbNombre.Text
        Dim Apellidos As String = tbApellidos.Text
        Dim Dir1 As String = tbDir1.Text
        Dim Dir2 As String = tbDir2.Text
        Dim Ciudad As String = cbCiudad.Text
        Dim Provincia As String = cbProvincia.Text
        Dim CP As Integer = If(tbCP.Text <> "", CInt(tbCP.Text), Nothing)
        Dim Pais As String = cbPais.Text
        Dim Region As Short = CShort(tbRegion.Text)
        Dim Correo As String = tbCorreo.Text
        Dim Telefono As String = tbTelefono.Text
        Dim TipoTarjeta As Integer = cbTipoTarjetas.SelectedIndex
        Dim NumeroTarjeta As String = tbNumeroTarjeta.Text
        Dim FechaCaducidadTarjeta As String = CStr(calendario.DisplayDate)
        Dim Nick As String = tbNick.Text
        Dim Contra As String = tbContra.Text
        Dim Edad As UShort = If(tbEdad.Text <> "", CUShort(tbEdad.Text), Nothing)
        Dim Sueldo As Integer = If(tbSueldo.Text <> "", CInt(tbSueldo.Text), Nothing)
        Dim Genero As Char = If(rbHombre.IsChecked, "H"c, "M"c)

        Try
            AccionesBD.InsertarCliente(Nombre, Apellidos, Dir1, Dir2, Ciudad, Provincia,
                CP, Pais, Region, Correo, Telefono, TipoTarjeta, NumeroTarjeta,
                FechaCaducidadTarjeta, Nick, Contra, Edad, Sueldo, Genero)

            Main.TextBarraEstado.Text = "El cliente ha sido insertado correctamente."
            Dim Respuesta As MessageBoxResult = MessageBox.Show("El cliente ha sido insertado correctamente." + vbCrLf + "¿Quieres seguir insertando?", "Insertado", MessageBoxButton.YesNo, MessageBoxImage.Question)

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


    Public Sub ObtenerCLiente(Nick As String)

        Dim AccionesBD As AccionesBDCliente = New AccionesBDCliente()

        Dim DatosCliente As Dictionary(Of String, String) =
            AccionesBD.ObtenerCliente(Nick)

        IdCliente = CInt(DatosCliente("ID"))
        tbNombre.Text = DatosCliente("NOMBRE")
        tbApellidos.Text = DatosCliente("APELLIDOS")
        tbDir1.Text = DatosCliente("DIR1")
        tbDir2.Text = DatosCliente("DIR2")
        tbCP.Text = If(DatosCliente("CP") = "0", "", DatosCliente("CP"))
        cbPais.Text = DatosCliente("PAIS")
        cbProvincia.Text = DatosCliente("PROVINCIA")
        cbCiudad.Text = DatosCliente("CIUDAD")
        tbRegion.Text = DatosCliente("REGION")
        tbCorreo.Text = DatosCliente("CORREO")
        tbTelefono.Text = DatosCliente("TELEFONO")

        Try
            cbTipoTarjetas.SelectedIndex = CInt(DatosCliente("TIPO_TARJETA"))
        Catch ex As Exception
            MessageBox.Show("El tipo de tarjeta de este cliente ya no es valido. Cambie de tipo de tarjeta.", "Error", MessageBoxButton.OK, MessageBoxImage.Error)
            Main.TextBarraEstado.Text = "El tipo de tarjeta de este cliente ya no es valido."
        End Try

        tbNumeroTarjeta.Text = DatosCliente("NUMERO_TARJETA")

        Try
            calendario.SelectedDate = CDate(DatosCliente("FECHA_CADUCIDAD"))
        Catch ex As Exception
            MessageBox.Show("La fecha de la tarjeta esta caducada.", "Error", MessageBoxButton.OK, MessageBoxImage.Error)
            Main.TextBarraEstado.Text = "La fecha de la tarjeta esta caducada."
        End Try

        tbNick.Text = DatosCliente("NICK")
        tbContra.Text = DatosCliente("CONTRA")
        tbEdad.Text = DatosCliente("EDAD")
        tbSueldo.Text = If(DatosCliente("SUELDO") = "0", "", DatosCliente("SUELDO"))
        rbHombre.IsChecked = If(DatosCliente("GENERO") = "H"c, True, False)
        rbMujer.IsChecked = If(DatosCliente("GENERO") = "M"c, True, False)

    End Sub

    Private Sub ModificarCliente()

        Dim AccionesBD As AccionesBDCliente = New AccionesBDCliente()

        Dim Nombre As String = tbNombre.Text
        Dim Apellidos As String = tbApellidos.Text
        Dim Dir1 As String = tbDir1.Text
        Dim Dir2 As String = tbDir2.Text
        Dim Ciudad As String = cbCiudad.Text
        Dim Provincia As String = cbProvincia.Text
        Dim CP As Integer = If(tbCP.Text <> "", CInt(tbCP.Text), Nothing)
        Dim Pais As String = cbPais.Text
        Dim Region As Short = CShort(tbRegion.Text)
        Dim Correo As String = tbCorreo.Text
        Dim Telefono As String = tbTelefono.Text
        Dim TipoTarjeta As Integer = cbTipoTarjetas.SelectedIndex
        Dim NumeroTarjeta As String = tbNumeroTarjeta.Text
        Dim FechaCaducidadTarjeta As String = CType(calendario.DisplayDate, String)
        Dim Nick As String = tbNick.Text
        Dim Contra As String = tbContra.Text
        Dim Edad As UShort = CUShort(tbEdad.Text)
        Dim Sueldo As Integer = If(tbSueldo.Text <> "", CInt(tbSueldo.Text), Nothing)
        Dim Genero As Char = If(rbHombre.IsChecked, "H"c, "M"c)

        Try
            AccionesBD.ModificarCliente(IdCliente, Nombre, Apellidos, Dir1, Dir2, Ciudad, Provincia,
                CP, Pais, Region, Correo, Telefono, TipoTarjeta, NumeroTarjeta,
                FechaCaducidadTarjeta, Nick, Contra, Edad, Sueldo, Genero)

            Main.TextBarraEstado.Text = "Cliente modificado."
            MessageBox.Show("El cliente ha sido modificado correctamente.", "Modificado", MessageBoxButton.OK, MessageBoxImage.Information)

            ForzarCerrar()

        Catch ex As Exception
            Main.TextBarraEstado.Text = ex.Message
            MessageBox.Show(ex.Message, "Error al Modificar", MessageBoxButton.OK, MessageBoxImage.Error)
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

    Public Sub ForzarCerrar()
        cerrar = True
        Me.Close()
    End Sub



End Class



